#region Author & Version
/*******************************************************************
 ** 文件名:    
 ** 版  权:    (C) 深圳冰川网络技术有限公司 
 ** 创建人:     曾尔捷
 ** 日  期:    2018/11/23
 ** 版  本:    1.0
 ** 描  述:    奖励实体
 ** 应  用:    奖励逻辑         
 **
 **************************** 修改记录 ******************************
 ** 修改人:    
 ** 日  期:    
 ** 描  述:    
 ********************************************************************/

#endregion
namespace CubicWar
{
	using System.Collections.Generic;
	using System.Collections;
	using System;
	using DG.Tweening;
	using Sirenix.OdinInspector;
	using UniRx;
	using Unity.Entities;
	using Unity.Linq;
	using UnityEngine.SceneManagement;
	using UnityEngine;
	using UnityEngine.Profiling;

	public struct DespawningEntityData : IComponentData
	{
	}

	[DisableAutoCreation]
	public class DestroyDespawningSystem : ComponentSystem
	{
		ComponentGroup Group;

		protected override void OnCreateManager()
		{
			base.OnCreateManager();
			Group = GetComponentGroup(typeof(DespawningEntityData));
		}

		protected override void OnUpdate()
		{
			var entityArray = Group.GetEntityArray();
			for (var i = 0; i < entityArray.Length; i++)
			{
				PostUpdateCommands.DestroyEntity(entityArray[i]);
			}
		}
	}


	public class GameWorld
	{
		public static List<GameWorld> _worldList = new List<GameWorld>();
		public int lastServerTick;
		public float frameDuration;
		public double nextTickTime = 0;
		public GameObject SceneRoot { get; }

		public EntityManager entityManager { get; private set; }
		public World ecsWorld { get; private set; }


		DestroyDespawningSystem _destroyDespawningSystem;
		List<GameObject> _dynamicEntities = new List<GameObject>();
		List<GameObject> _DespawnRequests = new List<GameObject>(32);
		// SceneRoot can be used to organize crated gameobject in scene view. Is null in standalone.
		public GameWorld(World world)
		{
			ecsWorld = world;
			World.Active = ecsWorld;
			entityManager = ecsWorld.GetOrCreateManager<EntityManager>();
			GameDebug.Assert(entityManager.IsCreated);

			_worldList.Add(this);
			_destroyDespawningSystem = ecsWorld.CreateManager<DestroyDespawningSystem>();
		}

		public void Shutdown()
		{
			foreach (var entity in _dynamicEntities)
			{
				if (_DespawnRequests.Contains(entity))
					continue;
#if UNITY_EDITOR
				if (entity == null)
					continue;

				var gameObjectEntity = entity.GetComponent<GameObjectEntity>();
				if (gameObjectEntity != null && !entityManager.Exists(gameObjectEntity.Entity))
					continue;
#endif
				RequestDespawn(entity);
			}
			ProcessDespawns();
			ecsWorld.DestroyManager(_destroyDespawningSystem);
			_worldList.Remove(this);
			ecsWorld.Dispose();
			ecsWorld = null;

			GameObject.Destroy(SceneRoot);
		}

		public T Spawn<T>(GameObject prefab) where T : Component
		{
			return Spawn<T>(prefab, Vector3.zero, Quaternion.identity);
		}

		public T Spawn<T>(GameObject prefab, Vector3 position, Quaternion rotation) where T : Component
		{
			Entity entity;
			var gameObject = SpawnInternal(prefab, position, rotation, out entity);
			if (gameObject == null)
				return null;

			var result = gameObject.GetComponent<T>();
			if (result == null)
			{
				GameDebug.Log(string.Format("Spawned entity '{0}' didn't have component '{1}'", prefab, typeof(T).FullName));
				return null;
			}

			return result;
		}

		public GameObject Spawn(string name, params System.Type[] components)
		{
			var go = new GameObject(name, components);
			RegisterInternal(go, true);
			return go;
		}

		public GameObject SpawnInternal(GameObject prefab, Vector3 position, Quaternion rotation, out Entity entity)
		{
			Profiler.BeginSample("GameWorld.SpawnInternal");

			var go = UnityEngine.Object.Instantiate(prefab, position, rotation);

			entity = RegisterInternal(go, true);

			Profiler.EndSample();

			return go;
		}

		////////////////////////////////////////////////////////////////////////////////

		public void RequestDespawn(GameObject entity)
		{
			if (_DespawnRequests.Contains(entity))
			{
				GameDebug.Assert(false, "Trying to request depawn of same gameobject({0}) multiple times", entity.name);
				return;
			}

			var gameObjectEntity = entity.GetComponent<GameObjectEntity>();
			if (gameObjectEntity != null)
				entityManager.AddComponent(gameObjectEntity.Entity, typeof(DespawningEntityData));

			_DespawnRequests.Add(entity);
		}

		public void RequestDespawn(GameObject entity, EntityCommandBuffer commandBuffer)
		{
			if (_DespawnRequests.Contains(entity))
			{
				GameDebug.Assert(false, "Trying to request depawn of same gameobject({0}) multiple times", entity.name);
				return;
			}

			var gameObjectEntity = entity.GetComponent<GameObjectEntity>();
			if (gameObjectEntity != null)
				commandBuffer.AddComponent(gameObjectEntity.Entity, new DespawningEntityData());

			_DespawnRequests.Add(entity);
		}

		public void ProcessDespawns()
		{
			foreach (var gameObject in _DespawnRequests)
			{
				_dynamicEntities.Remove(gameObject);
				UnityEngine.Object.Destroy(gameObject);
			}

			_DespawnRequests.Clear();

			_destroyDespawningSystem.Update();
		}

		private Entity RegisterInternal(GameObject gameObject, bool isDynamic)
		{
			// If gameObject has GameObjectEntity it is already registered in entitymanager. If not we register it here  
			var gameObjectEntity = gameObject.GetComponent<GameObjectEntity>();
			if (gameObjectEntity == null)
				GameObjectEntity.AddToEntityManager(entityManager, gameObject);

			if (isDynamic)
				_dynamicEntities.Add(gameObject);

			return gameObjectEntity != null ? gameObjectEntity.Entity : Entity.Null;
		}
	}
}

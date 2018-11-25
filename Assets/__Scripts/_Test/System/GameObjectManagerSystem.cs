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
namespace CubicWarTest.Systems
{
	using Components;
	using System.Collections.Generic;
	using System.Linq;
	using Unity.Entities;
	using Unity.Jobs;
	using Unity.Transforms;
	using UnityEngine;
	using UnityEngine.Experimental.PlayerLoop;
	using System;
	using UnityEngine.AddressableAssets;
	//[AlwaysUpdateSystem]
	//[UpdateBefore(typeof(EarlyUpdate))]
	//public class GameObjectManagerSystem : ComponentSystem
	//{
	//	/// <summary>所有的GO，与entity一对一</summary>
	//	public static readonly Dictionary<Entity, GameObject> gos = new Dictionary<Entity, GameObject>();
	//	public static readonly Dictionary<Entity, Animator> anims = new Dictionary<Entity, Animator>();
	//	/// <summary>异步锁</summary>
	//	public static readonly HashSet<Entity> entityAsyncLockSet = new HashSet<Entity>();

	//	public struct Data
	//	{
	//		public ComponentDataArray<PrefabPathData> prefabs;
	//		public ComponentDataArray<Position> position;
	//		public ComponentArray<Animator> anim;
	//		public EntityArray Entities;
	//		public readonly int Length;
	//	}

	//	[Inject]
	//	private Data _data;

	//	private string _path;
	//	protected override void OnUpdate()
	//	{
	//		//Instantiate
	//		for (int i = 0; i != _data.Length; i++)
	//		{
	//			PrefabPathData prefab = _data.prefabs[i];
	//			Entity entity = _data.Entities[i];
	//			if (!entityAsyncLockSet.Contains(entity))
	//			{
	//				entityAsyncLockSet.Add(entity);

	//				var pos = _data.position[i].Value;
	//				var aop = AddressablesHelper.InstantiatePrefab<GameObject>(_data.prefabs[i].prefabPath);
	//				aop.Completed += x =>
	//				{
	//					gos.Add(entity, x.Result);

	//					x.Result.transform.position = pos;
	//					if (EntityManager.HasComponent<Rotation>(entity))
	//						EntityManager.SetComponentData(entity, new Rotation() { Value = x.Result.transform.rotation });
	//					if (EntityManager.HasComponent<Scale>(entity))
	//						EntityManager.SetComponentData(entity, new Scale() { Value = x.Result.transform.localScale });
	//					if (EntityManager.HasComponent<Animator>(entity))
	//						anims.Add(entity, x.Result.GetComponent<Animator>());
	//				};
	//			}
	//		}
	//		//Release
	//		if (gos.Count > _data.Length)
	//		{
	//			Entity[] toRemove = new Entity[_data.Length];
	//			for (int i = 0; i != _data.Length; i++)
	//			{
	//				toRemove[i] = _data.Entities[i];
	//			}
	//			var gameObjectsToRemove = gos.Keys.Except(toRemove).ToArray();

	//			foreach (var entity in gameObjectsToRemove)
	//			{
	//				AddressablesHelper.ReleaseInstance(gos[entity].gameObject);
	//				gos.Remove(entity);
	//				if (EntityManager.HasComponent<Animator>(entity))
	//					anims.Remove(entity);

	//				entityAsyncLockSet.Remove(entity);
	//			}
	//		}
	//	}
	//}
	//public class GameObjectManagerSystem2 : JobComponentSystem
	//{
	//	public static Dictionary<Entity, GameObject> gameObjectsDict = new Dictionary<Entity, GameObject>();
	//	public static HashSet<Entity> entityLocks = new HashSet<Entity>();

	//	public struct SyncGameEntityJob : IJobProcessComponentDataWithEntity<MyPrefab, Position>
	//	{
	//		public void Execute(Entity entity, int index, ref MyPrefab prefab, ref Position position)
	//		{
	//			if (!entityLocks.Contains(entity))
	//			{
	//				entityLocks.Add(entity);
	//				var pos = position.Value;
	//				var aop = Addressables.Instantiate<GameObject>(PrefabList.prefabsDict[prefab.prefabPath]);
	//				aop.Completed += x =>
	//				{
	//					x.Result.transform.position = pos;
	//					gameObjectsDict.Add(entity, x.Result);
	//				};
	//				//var instance = GameObject.Instantiate(PrefabList.instance.prefabs[prefab.prefabId]);
	//				//instance.transform.position =position.Value;
	//				//gameObjectsDict.Add(entity, instance);
	//				Debug.Log(entity);
	//			}
	//		}
	//	}
	//	protected override JobHandle OnUpdate(JobHandle inputDeps)
	//	{
	//		return new SyncGameEntityJob
	//		{
	//		}.Schedule(this, inputDeps);

	//	}
	//}
}

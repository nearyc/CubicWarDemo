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
namespace CubicWar.Systems
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

	[AlwaysUpdateSystem]
	[UpdateBefore(typeof(EarlyUpdate))]
	public class GameObjectManagerSystem : ComponentSystem
	{

		public  Dictionary<Entity, GameObject> gameObjectsDict = new Dictionary<Entity, GameObject>();

		public struct Data
		{
			public ComponentDataArray<MyPrefab> prefabs;
			public ComponentDataArray<Position> position;
			public EntityArray Entities;
			public readonly int Length;
		}

		[Inject]
		private Data _data;

		private string _path;
		protected override void OnUpdate ( )
		{
			for (int i = 0 ; i != _data.Length ; i++)
			{
				MyPrefab prefab = _data.prefabs[i];
				Entity entity = _data.Entities[i];
				if (!gameObjectsDict.ContainsKey(entity))
				{
					_path=PrefabList.prefabsDict[_data.prefabs[i].prefabPath];
					var asset = Resources.Load<GameObject>(_path);
					var instance=GameObject.Instantiate(asset);
					instance.transform.position = _data.position [i].Value;
					gameObjectsDict.Add(entity, instance);
				}
			}

			if (gameObjectsDict.Count > _data.Length)
			{
				Entity[] eee = new Entity[_data.Length];
				for (int i = 0 ; i != _data.Length ; i++)
				{
					eee [i] = _data.Entities [i];
				}
				var gameObjectsToRemove = gameObjectsDict.Keys.Except(eee).ToArray();

				foreach (var entity in gameObjectsToRemove)
				{
					GameObject.Destroy(gameObjectsDict [entity].gameObject); // destroy game object
					gameObjectsDict.Remove(entity); // and forget about it
				}
			}
		}
	}
	//public class GameObjectManagerSystem2 : JobComponentSystem
	//{
	//	public static  Dictionary<Entity, GameObject> gameObjectsDict = new Dictionary<Entity, GameObject>();
	
	//	public struct SyncGameEntityJob : IJobProcessComponentDataWithEntity<MyPrefab, Position>
	//	{
	//		public void Execute (Entity entity, int index, ref MyPrefab prefab, ref Position position)
	//		{
	//			if (!gameObjectsDict.ContainsKey(entity))
	//			{
	//				//var instance = GameObject.Instantiate(PrefabList.instance.prefabs[prefab.prefabId]);
	//				//instance.transform.position =position.Value;
	//				//gameObjectsDict.Add(entity, instance);
	//				Debug.Log(entity);
	//			}
	//		}
	//	}
	//	protected override JobHandle OnUpdate (JobHandle inputDeps)
	//	{
	//		return new SyncGameEntityJob
	//		{
	//		}.Schedule(this,inputDeps);
			
	//	}
	//}
}

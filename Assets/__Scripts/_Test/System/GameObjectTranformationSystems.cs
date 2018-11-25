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
	//using Components;
	//using System.Collections.Generic;
	//using System.Linq;
	//using Unity.Entities;
	//using Unity.Jobs;
	//using Unity.Transforms;
	//using UnityEngine;
	//using UnityEngine.Experimental.PlayerLoop;

	//public struct GoData
	//{
	//	public ComponentDataArray<PrefabPathData> pr;
	//	public ComponentDataArray<Position> pos;
	//	public EntityArray Entities;
	//	public readonly int Length;
	//}

	//[UpdateAfter(typeof(PostLateUpdate))]
	//public class GOTranformWriteSystem : ComponentSystem
	//{
	//	[Inject] private GoData _data;
	//	[Inject] private GameObjectManagerSystem _gameObjectManagerSys;
	//	GameObject _go;
	//	protected override void OnUpdate()
	//	{
	//		for (int i = 0; i != _data.Length; i++)
	//		{
	//			Entity ett = _data.Entities[i];
	//			//Debug.Log(e);
	//			if (GameObjectManagerSystem.gos.TryGetValue(ett, out _go))
	//			{
	//				_go.transform.position = _data.pos[i].Value;

	//				if (EntityManager.HasComponent<Rotation>(ett))
	//				{
	//					_go.transform.rotation = EntityManager.GetComponentData<Rotation>(ett).Value;
	//				}
	//				if (EntityManager.HasComponent<Scale>(ett))
	//				{
	//					_go.transform.localScale = EntityManager.GetComponentData<Scale>(ett).Value;
	//				}
	//			}
	//		}
	//	}
	//}

	//[UpdateAfter(typeof(FixedUpdate))]
	//public class GOTranformReadSystem : ComponentSystem
	//{
	//	[Inject] private GoData _data;
	//	[Inject] private GameObjectManagerSystem _gameObjectManagerSys;
	//	GameObject _go;
	//	protected override void OnUpdate()
	//	{
	//		for (int i = 0; i != _data.Length; i++)
	//		{
	//			Entity ett = _data.Entities[i];
	//			//Debug.Log(e);
	//			if (GameObjectManagerSystem.gos.TryGetValue(ett, out _go))
	//			{
	//				_data.pos[i] = new Position { Value = _go.transform.position };

	//				if (EntityManager.HasComponent<Rotation>(ett))
	//					EntityManager.SetComponentData(ett, new Rotation() { Value = _go.transform.rotation });

	//				if (EntityManager.HasComponent<Scale>(ett))
	//					EntityManager.SetComponentData(ett, new Scale() { Value = _go.transform.localScale });
	//			}
	//		}
	//	}
	//}

	////[UpdateAfter(typeof(GameObjectManagerSystem))]
	//public class GOTranformChangeSystem : JobComponentSystem
	//{
	//	struct TestJobs : IJobProcessComponentData<PrefabPathData, Position>
	//	{
	//		public bool bo;
	//		public float dtTime;

	//		public void Execute(ref PrefabPathData pr, ref Position pos)
	//		{
	//			if (bo)
	//			{
	//				var temp = pos;
	//				temp.Value.y += new Unity.Mathematics.Random(1).NextFloat(1, 10);
	//				pos = temp;
	//			}
	//		}
	//	}
	//	protected override JobHandle OnUpdate(JobHandle inputDeps)
	//	{
	//		return new TestJobs
	//		{
	//			bo = Input.GetKeyDown(KeyCode.M),
	//			dtTime = Time.deltaTime,
	//		}.Schedule(this, inputDeps);
	//	}
	//}
}
/*
// минус делать это поотдельности в том что
// для каждого свойства мы ищем геймобджек в словаре

public struct GoPositionsData{
  public ComponentDataArray<Prefab> GOs;
  public ComponentDataArray<Position> Positions;
  public EntityArray Entities;
  public int Length;
}

[UpdateAfter(typeof(GameObjectManagerSystem))]
public class GameObjectTranformationPositionWriteSystem:ComponentSystem{

  [Inject] private GoPositionsData _data;
  [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

  protected override void OnUpdate(){
	for( int i = 0; i != _data.Length; i++ ){
	  Entity e = _data.Entities[i];
	  GameObject go = _gameObjectManagerSys.GameObjects[e];
	  go.GetComponent<Transform>().position = _data.Positions[i].Value;
	}
  }
}

[UpdateAfter(typeof(FixedUpdate))]
public class GameObjectTranformationPositionReadSystem:ComponentSystem{

  [Inject] private GoPositionsData _data;
  [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

  protected override void OnUpdate(){
	for( int i = 0; i != _data.Length; i++ ){
	  Entity e = _data.Entities[i];
	  GameObject go = _gameObjectManagerSys.GameObjects[e];
	  Position p = new Position(){Value = go.GetComponent<Transform>().position};
	  EntityManager.SetComponentData(e, p);
	}
  }
}







public struct GoRotationData{
  public ComponentDataArray<Prefab> GOs;
  public ComponentDataArray<Rotation> Rotattions;
  public EntityArray Entities;
  public int Length;
}

[UpdateAfter(typeof(GameObjectManagerSystem))]
public class GameObjectTranformationRotationWriteSystem:ComponentSystem{

  [Inject] private GoRotationData _data;
  [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

  protected override void OnUpdate(){
	for( int i = 0; i != _data.Length; i++ ){
	  Entity e = _data.Entities[i];
	  GameObject go = _gameObjectManagerSys.GameObjects[e];
	  go.GetComponent<Transform>().rotation = _data.Rotattions[i].Value;
	}
  }
}

[UpdateAfter(typeof(FixedUpdate))]
public class GameObjectTranformationRotationReadSystem:ComponentSystem{

  [Inject] private GoRotationData _data;
  [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

  protected override void OnUpdate(){
	for( int i = 0; i != _data.Length; i++ ){
	  Entity e = _data.Entities[i];
	  GameObject go = _gameObjectManagerSys.GameObjects[e];
	  Rotation rotation = new Rotation(){Value = go.GetComponent<Transform>().rotation};
	  EntityManager.SetComponentData(e, rotation);
	}
  }
}






public struct GoScaleData{
  public ComponentDataArray<Prefab> GOs;
  public ComponentDataArray<Scale> Scales;
  public EntityArray Entities;
  public int Length;
}

[UpdateAfter(typeof(GameObjectManagerSystem))]
public class GameObjectTranformationScaleWriteSystem:ComponentSystem{

  [Inject] private GoScaleData _data;
  [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

  protected override void OnUpdate(){
	for( int i = 0; i != _data.Length; i++ ){
	  Entity e = _data.Entities[i];
	  GameObject go = _gameObjectManagerSys.GameObjects[e];
	  go.GetComponent<Transform>().localScale = _data.Scales[i].Value;
	}
  }
}

[UpdateAfter(typeof(FixedUpdate))]
public class GameObjectTranformationScaleReadSystem:ComponentSystem{

  [Inject] private GoScaleData _data;
  [Inject] private GameObjectManagerSystem _gameObjectManagerSys;

  protected override void OnUpdate(){
	for( int i = 0; i != _data.Length; i++ ){
	  Entity e = _data.Entities[i];
	  GameObject go = _gameObjectManagerSys.GameObjects[e];
	  Scale scale = new Scale(){Value = go.GetComponent<Transform>().localScale};
	  EntityManager.SetComponentData(e, scale);
	}
  }
}

*/



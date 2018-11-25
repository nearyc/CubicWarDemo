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
	using CubicWar.Components;
	using UnityEngine;
	using Sirenix.OdinInspector;
	using Unity.Entities;
	using Unity.Mathematics;
	[DisableAutoCreation]
	public class InstantiatePrefabSystem : BaseComponentDataSystem<InstantiateData>
	{
		public InstantiatePrefabSystem(GameWorld world) : base(world)
		{
		}
		protected override bool IsUseEntityArray => true;

		protected override void Update(int index, ref InstantiateData data)
		{
			var worldPosition = data.worldPos;
			var worldRotaiton = data.worldRotation;
			var aop = AddressablesHelper.InstantiatePrefab<GameObject>(data.prefabDefine, worldPosition.ToVector3(), worldRotaiton);
			aop.Completed += go =>
			{
				EntityManagerHelper.GOSetComponentDataIfContains(go.Result, new Position2DData
				{
					world = new float2(worldPosition.x, worldPosition.y)
				});
				EntityManagerHelper.GOAddComponentData(go.Result, new LifeTimeData
				{
					lifetime = 0
				});
			};
			PostUpdateCommands.DestroyEntity(entityArray[index]);
		}
	}
	[DisableAutoCreation]
	public class ReleasePrefabSystem : BaseComponentDataSystem<ReleaseData>
	{
		public ReleasePrefabSystem(GameWorld world) : base(world)
		{
		}

		protected override void Update(int index, ref ReleaseData data)
		{
			var entity = Group.GetEntityArray()[index];
			var obj = EntityManager.GetComponentObject<GameObjectEntity>(entity);
			AddressablesHelper.ReleaseInstance(obj.gameObject);
			PostUpdateCommands.DestroyEntity(entity);
		}
	}
	//[DisableAutoCreation]
	//public class InstantiatePrefabSystem : ComponentSystem
	//{
	//	public struct Data
	//	{
	//		public readonly int Length;
	//		public ComponentDataArray<InstantiateData> instantiateData;
	//		public EntityArray entities;
	//	}
	//	[Inject] Data _data;
	//	protected override void OnUpdate()
	//	{
	//		for (int i = 0; i < _data.Length; i++)
	//		{
	//			var position = _data.instantiateData[i].positon;
	//			var rotaiton = _data.instantiateData[i].rotation;
	//			var aop = AddressablesHelper.InstantiatePrefab<GameObject>(_data.instantiateData[i].prefabDefine, position.ToVector3(), rotaiton);
	//			aop.Completed += go =>
	//			{
	//				EntityManagerHelper.GOEntitySetComponentDataIfContains(EntityManager,go.Result,new Position2DData
	//				{
	//					value = new float2(position.x, position.y)
	//				});
	//			};
	//			PostUpdateCommands.DestroyEntity(_data.entities[i]);
	//		}
	//	}
	//}

}

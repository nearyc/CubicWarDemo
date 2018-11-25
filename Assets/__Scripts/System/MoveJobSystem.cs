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
	using System.Collections.Generic;
	using Unity.Entities;
	using Unity.Jobs;
	using UnityEngine;
	using UnityEngine.Profiling;
	[DisableAutoCreation]
	[UpdateAfter(typeof(PlayerInputJobSystem))]
	public class MoveJobSystem : JobComponentSystem
	{
		public struct MoveJob : IJobProcessComponentData<MoveSpeedData, PlayerInputData, Position2DData>
		{
			public float dt;
			public void Execute(ref MoveSpeedData moveSPeed, ref PlayerInputData input, ref Position2DData positon)
			{
				positon.world += input.move * moveSPeed.value * dt;
			}
		}
		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			return new MoveJob
			{
				dt = Time.deltaTime,
			}.Schedule(this, inputDeps);
		}
	}
	//[DisableAutoCreation]
	//public class LifeTimeJobSystem : JobComponentSystem
	//{
	//	public struct LifeJob : IJobProcessComponentDataWithEntity<LifeTimeData>
	//	{
	//		public float dt;
	//		public void Execute(Entity entity, int index, ref LifeTimeData data)
	//		{
	//			data.lifetime += dt;
	//			if (data.lifetime > 2)
	//			{
	//				GameWorld._worldList[0].entityManager.CreateEntity();
	//			}
	//		}
	//	}
	//	protected override JobHandle OnUpdate(JobHandle inputDeps)
	//	{
	//		return new LifeJob
	//		{
	//			dt = Time.deltaTime,
	//		}.Schedule(this, inputDeps);
	//	}
	//}
	//public class MoveSystem : ComponentSystem
	//{
	//	public struct Data
	//	{
	//		public readonly int Length;
	//		public ComponentDataArray<MoveSpeedData> moveSPeed;
	//		public ComponentDataArray<PlayerInputData> input;
	//		public ComponentDataArray<Position2DData> positon;
	//	}
	//	[Inject] Data _data;
	//	protected override void OnUpdate()
	//	{
	//		var dt = Time.deltaTime;
	//		for (int i = 0; i < _data.Length; i++)
	//		{
	//			var temp = _data.positon[i];
	//			temp.value += _data.input[i].move * _data.moveSPeed[i].value * dt;
	//			_data.positon[i] = temp;
	//		}
	//	}
	//}
}

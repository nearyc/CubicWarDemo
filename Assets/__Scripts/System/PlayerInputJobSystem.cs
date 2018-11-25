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
	using Unity.Entities;
	using Unity.Jobs;
	using Unity.Mathematics;
	using UnityEngine;
	using UnityEngine.Experimental.PlayerLoop;

	[DisableAutoCreation]
	[UpdateAfter(typeof(CopyFromTransformSystem))]
	public class PlayerInputJobSystem : JobComponentSystem
	{
		public struct InputJob : IJobProcessComponentData<PlayerInputData>
		{
			public float dt;
			public float2 move;
			//public float2 shoot;

			public void Execute(ref PlayerInputData pi)
			{
				pi.move = move;
				pi.fireCooldown = math.max(0.0f, pi.fireCooldown - dt);
			}
		}
		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			return new InputJob
			{
				dt = Time.deltaTime,
				move = new float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
				//shoot=new float2(Input.GetAxis("ShootX"), Input.GetAxis("ShootY")),
			}.Schedule(this, inputDeps);
		}
	}
	public class DragJobSystem : JobComponentSystem
	{
		public struct DragJob : IJobProcessComponentDataWithEntity<DragData, Position2DData>
		{
			public void Execute(Entity entity, int index, ref DragData drag, ref Position2DData pos)
			{
				pos.world = drag.position;
			}
		}
		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			return new DragJob().Schedule(this, inputDeps);
		}
	}
}
	//public class PlayerInputSystem : ComponentSystem
	//{
	//	public struct Data
	//	{
	//		public PlayerInputData playerInput;
	//	}
	//	protected override void OnUpdate()
	//	{
	//		var dt = Time.deltaTime;
	//		foreach (var e in GetEntities<Data>())
	//		{
	//			var pi = e.playerInput;

	//			pi.move.x = Input.GetAxis("Horizontal");
	//			pi.move.y = Input.GetAxis("Vertical");
	//			//pi.shoot.x = Input.GetAxis("ShootX");
	//			//pi.shoot.y = Input.GetAxis("ShootY");

	//			pi.fireCooldown = Mathf.Max(0.0f, pi.fireCooldown - dt);
	//		}
	//	}
	//}
//}

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
	using Unity.Mathematics;
	using UnityEngine;
	using UnityEngine.Experimental.PlayerLoop;

	[DisableAutoCreation]
	[UpdateAfter(typeof(PostLateUpdate))]
	public class CopyToTransformSystem : BaseComponentSystem
	{
		public struct TranData
		{
			public readonly int Length;
			public ComponentDataArray<Position2DData> position;
			//public ComponentDataArray<Heading2DData> heading;
			public ComponentArray<Transform> output;
		}
		public struct RectTranData
		{
			public readonly int Length;
			public ComponentDataArray<Position2DData> position;
			public ComponentArray<RectTransform> output;
		}
		[Inject] TranData _data;
		[Inject] RectTranData _rectData;

		public CopyToTransformSystem(GameWorld world) : base(world)
		{
		}
		protected override void OnUpdate()
		{
			for (int i = 0; i < _data.Length; i++)
			{
				var p = _data.position[i].world;
				//var h = _data.heading[i].value;

				_data.output[i].position = new float3(p.x, p.y, 0);

				//if (!h.Equals(new float2(0f, 0f)))
				//	_data.output[i].localRotation = quaternion.LookRotation(new float3(h.x, h.y, h.y), new float3(0f, 1f, 0f));
			}
			for (int i = 0; i < _rectData.Length; i++)
			{
				var p = _rectData.position[i].world;
				_rectData.output[i].position = new float3(p.x, p.y, 0);
			}
		}
	}
	[DisableAutoCreation]
	[UpdateBefore(typeof(PostLateUpdate))]
	public class CopyFromTransformSystem : BaseComponentHybirdSystem_11<Transform, Position2DData>
	{
		public CopyFromTransformSystem(GameWorld world) : base(world)
		{
		}

		protected override void Update(int index, Transform input, ref Position2DData output)
		{
			//output.local = input.localPosition.ToFloat2();
			output.world = input.position.ToFloat2();
		}
	}
	//[DisableAutoCreation]
	//[UpdateAfter(typeof(EarlyUpdate))]
	//public class CopyFromTransformSystem2 : BaseComponentHybirdSystem_11<Transform, Position2DData>
	//{
	//	public CopyFromTransformSystem2(GameWorld world) : base(world)
	//	{
	//	}

	//	protected override void Update(int index, Transform input, ref Position2DData output)
	//	{
	//		output.value = input.localPosition.ToFloat2();
	//	}
	//}
	[DisableAutoCreation]
	[UpdateAfter(typeof(FixedUpdate.Physics2DFixedUpdate))]
	public class Rigidbody2DSystem : BaseComponentHybirdSystem_21<Rigidbody2D, Transform, Position2DData>
	{
		public Rigidbody2DSystem(GameWorld world) : base(world)
		{
		}

		protected override void Update(int index, Rigidbody2D rb, Transform input, ref Position2DData output)
		{
			//output.local = input.localPosition.ToFloat2();
			//output.world = input.position.ToFloat2();
		}
	}
	//[DisableAutoCreation]
	//[UpdateAfter(typeof(EarlyUpdate))]
	//public class CopyFromTransformSystem : BaseComponentSystem
	//{
	//	public struct TranData
	//	{
	//		public readonly int Length;
	//		public ComponentDataArray<Position2DData> position;
	//		public ComponentArray<Transform> output;
	//	}
	//	[Inject] TranData _data;
	//	public CopyFromTransformSystem(GameWorld world) : base(world)
	//	{
	//	}
	//	protected override void OnUpdate()
	//	{
	//		for (int i = 0; i < _data.Length; i++)
	//		{
	//			//var p = _data.position[i].value;
	//			//_data.output[i].position = new float3(p.x, p.y, 0);
	//			var temp = _data.position[i];
	//			temp.value = _data.output[i].position.ToFloat2()*1.1f;
	//			_data.position[i] = temp;
	//		}
	//	}

	//}

	//}
	//[DisableAutoCreation]
	//[UpdateAfter(typeof(PostLateUpdate))]
	//public class SyncRectTransformSystem : ComponentSystem
	//{
	//	public struct Data
	//	{
	//		public readonly int Length;
	//		public ComponentDataArray<Position2DData> position;
	//		public ComponentArray<RectTransform> Output;
	//	}
	//	[Inject] Data _rectData;
	//	protected override void OnUpdate()
	//	{
	//		for (int i = 0; i < _rectData.Length; i++)
	//		{
	//			float2 p = _rectData.position[i].value;
	//			_rectData.Output[i].position = new float3(p.x, p.y, 0);
	//		}
	//	}
	//}
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


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
namespace CubicWarTest.Components
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Unity.Linq;
	using Sirenix.OdinInspector;
	using UniRx;
	using Unity.Mathematics;
	using Unity.Entities;
	using System;
	using Systems;
	using Unity.Jobs;
	using Unity.Transforms;

	[Serializable]
	public struct RotationSpeed : IComponentData
	{
		public float value;
	}
	public class RotationSpeedComponent : ComponentDataWrapper<RotationSpeed> { }

	public class RotationSpeedSystem : JobComponentSystem
	{
		/// <summary>
		/// 使用IJobProcessComponentData遍历符合条件的所有Entity。
		/// 此过程是单进程的并行计算（SIMD）
		/// IJobProcessComponentData 是遍历entity的简便方法，并且也比IJobParallelFor更高效
		/// </summary>
		struct RotationSpeedRotation : IJobProcessComponentData<Rotation, RotationSpeed>
		{
			/// <summary>
			/// deltaTime
			/// </summary>
			public float dt;
			/// <summary>
			/// 实现接口，在Excute中实现旋转
			/// </summary>
			public void Execute(ref Rotation rotation, ref RotationSpeed speed)
			{
				//读取speed，进行运算后，赋值给rotation
				var vaalue= math.mul(math.normalize(rotation.Value), quaternion.AxisAngle(Vector3.forward,speed.value * dt));
				rotation.Value = vaalue;
			}
		}

		/// <summary>
		/// 我们在这里，只需要声明我们将要用到那些job
		/// JobComponentSystem 携带以前定义的所有job
		/// 最后别忘了返回jobs，因为别的job system 可能还要用
		/// 完全独立于主进程，没有等待时间！
		/// </summary>
		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			var job = new RotationSpeedRotation() { dt = Time.deltaTime };
			return job.Schedule(this, inputDeps);
		}
	}
}

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
	//using CubicWar.Components;
	//using System.Collections;
	//using System.Collections.Generic;
	//using UnityEngine;
	//using Unity.Linq;
	//using Sirenix.OdinInspector;
	//using UniRx;
	//using Unity.Entities;
	//using System;
	//using Unity.Mathematics;
	//using System.Linq;
	//using Unity.Transforms;

	//public class GenerateCubeSystem : ComponentSystem
	//{
	//	EntityArchetype _cubeArchetype;
	//	protected override void OnCreateManager()
	//	{
	//		_cubeArchetype = EntityManager.CreateArchetype(
	//			typeof(PrefabPathData),
	//			typeof(Position),
	//			typeof(Rotation),
	//			typeof(Scale),
	//			typeof(Animator)
	//			);
	//	}
	//	public struct GenerateData
	//	{
	//		public readonly int Length;
	//		public ComponentDataArray<GenerateByPostionData> mousePressEvents;
	//		public ComponentDataArray<PrefabPathData> prefab;
	//		public EntityArray entities;
	//	}

	//	[Inject]
	//	private GenerateData _data;

	//	protected override void OnUpdate()
	//	{
	//		for (var i = 0; i != _data.Length; i++)
	//		{
	//			PostUpdateCommands.CreateEntity(_cubeArchetype);
	//			PostUpdateCommands.SetComponent(new PrefabPathData { prefabPath = _data.prefab[i].prefabPath });
	//			PostUpdateCommands.SetComponent(new Position { Value = _data.mousePressEvents[i].position });
	//			//PostUpdateCommands.SetComponent(new Rotation { Value =  quaternion.identity});
	//			//PostUpdateCommands.SetComponent(new Scale { Value = new float3(1,1,1)});

	//			PostUpdateCommands.DestroyEntity(_data.entities[i]);
	//		}
	//	}
	//}
	//public class RemoveCubeSystem : ComponentSystem
	//{
	//	public struct RemoveData
	//	{
	//		public readonly int Length;
	//		public ComponentDataArray<RemoveByTargetData> removeData;
	//		public EntityArray entities;
	//	}

	//	[Inject]
	//	private RemoveData _data;
	//	protected override void OnUpdate()
	//	{
	//		for (var i = 0; i != _data.Length; i++)
	//		{
	//			var target = _data.removeData[i].target;
	//			PostUpdateCommands.DestroyEntity(_data.entities[i]);
	//			PostUpdateCommands.DestroyEntity(target);
	//		}
	//	}
	//}
	//[UpdateBefore(typeof(GOTranformReadSystem))]
	//public class AnimateCubeSystem : ComponentSystem
	//{
	//	public struct RemoveData
	//	{
	//		public readonly int Length;
	//		public ComponentDataArray<AnimateTargetData> animTarget;
	//		public EntityArray entities;
	//	}

	//	[Inject]
	//	private RemoveData _data;
	//	protected override void OnUpdate()
	//	{
	//		for (var i = 0; i != _data.Length; i++)
	//		{
	//			var target = _data.animTarget[i].target;
	//			PostUpdateCommands.DestroyEntity(_data.entities[i]);
	//			GameObjectManagerSystem.anims[target].SetTrigger("Move");
	//		}
	//	}
	//}

	//public class AnimationTriggerSystem : ComponentSystem
	//{
	//	[Inject] private AnimationTriggerGroup _animatedEntities;

	//	protected override void OnUpdate()
	//	{
	//		for (var i = 0; i < _animatedEntities.Length; i++)
	//		{
	//			var animationTrigger = _animatedEntities.AnimationTriggers[i];
	//			var animator = _animatedEntities.Animators[i];
	//			var entity = _animatedEntities.Entities[i];

	//			PostUpdateCommands.RemoveComponent<SetAnimatorTrigger>(entity);

	//			animator.SetTrigger(animationTrigger.ParameterHash);
	//		}
	//	}

	//	private struct AnimationTriggerGroup
	//	{
	//		[ReadOnly] public ComponentDataArray<SetAnimatorTrigger> AnimationTriggers;
	//		[ReadOnly] public ComponentArray<Animator> Animators;
	//		[ReadOnly] public EntityArray Entities;
	//		public readonly int Length;
	//	}
	//}
}

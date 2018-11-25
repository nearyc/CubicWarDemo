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
	using UnityEngine;
	[DisableAutoCreation]
	public class AnimatorSystem : BaseComponentSystem
	{
		public struct TriggerData
		{
			public readonly int Length;
			public ComponentDataArray<AnimatorSetTriggerData> setTrigger;
			public EntityArray messageEntities;
		}
		public struct BoolData
		{

			public readonly int Length;
			public ComponentDataArray<AnimatorSetBoolData> setBool;
			public EntityArray messageEntities;
		}
		public struct FloatData
		{

			public readonly int Length;
			public ComponentDataArray<AnimatorSetFloatData> setFloat;
			public EntityArray messageEntities;
		}
		public struct IntData
		{

			public readonly int Length;
			public ComponentDataArray<AnimatorSetIntData> setInt;
			public EntityArray messageEntities;
		}
		[Inject] TriggerData _triggerData;
		[Inject] BoolData _boolData;
		[Inject] FloatData _floatData;
		[Inject] IntData _intData;

		public AnimatorSystem(GameWorld world) : base(world)
		{

		}

		protected override void OnUpdate()
		{
			
			Animator anim;
			Entity target;
			//
			for (int i = 0; i < _triggerData.Length; i++)
			{
				target = _triggerData.setTrigger[i].target;
				anim = EntityManager.GetComponentObject<Animator>(target);
				anim.SetTrigger(_triggerData.setTrigger[i].aimationDefine.ToString());

				PostUpdateCommands.DestroyEntity(_triggerData.messageEntities[i]);
			}
			//
			for (int i = 0; i < _boolData.Length; i++)
			{
				target = _boolData.setBool[i].target;
				anim = EntityManager.GetComponentObject<Animator>(target);
				anim.SetBool(_boolData.setBool[i].aimationDefine.ToString(), _boolData.setBool[i].value == 1);

				PostUpdateCommands.DestroyEntity(_boolData.messageEntities[i]);
			}
			//
			for (int i = 0; i < _floatData.Length; i++)
			{
				target = _floatData.setFloat[i].target;
				anim = EntityManager.GetComponentObject<Animator>(target);
				anim.SetFloat(_floatData.setFloat[i].aimationDefine.ToString(), _floatData.setFloat[i].value);

				PostUpdateCommands.DestroyEntity(_floatData.messageEntities[i]);
			}
			//
			for (int i = 0; i < _intData.Length; i++)
			{
				target = _intData.setInt[i].target;
				anim = EntityManager.GetComponentObject<Animator>(target);
				anim.SetInteger(_intData.setInt[i].aimationDefine.ToString(), _intData.setInt[i].value);

				PostUpdateCommands.DestroyEntity(_intData.messageEntities[i]);
			}
		}
	}
}

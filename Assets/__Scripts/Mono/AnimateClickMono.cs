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
namespace CubicWar
{
	using CubicWar.Components;
	using UnityEngine;
	using Unity.Entities;

	public enum EAimationDefine
	{
		Move,
	}
	public class AnimateClickMono : EntityMonoBase
	{
		private void OnMouseDown()
		{
			if (!Input.GetKey(KeyCode.M)) return;
			EntityManagerHelper.CreateMessageEntity(new AnimatorSetTriggerData
			{
				aimationDefine = EAimationDefine.Move,
				target = entity
			});
			//var em = World.Active.GetExistingManager<EntityManager>();
			//var entity = GetComponent<GameObjectEntity>()?.Entity;
			//if (entity.HasValue && em.HasComponent<Animator>(entity.Value))
			//{
			//var infoEntity = em.CreateEntity(typeof(AnimatorSetTriggerData));
			//em.SetComponentData(infoEntity, new AnimatorSetTriggerData
			//{
			//	aimationDefine = EAimationDefine.Move,
			//	target = entity.Value
			//});
			//}
		}
	}
}

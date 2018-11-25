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
	using CubicWarTest.Components;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Unity.Linq;
	using Sirenix.OdinInspector;
	using UniRx;
	using Unity.Entities;
	using System;
	using Unity.Mathematics;
	using System.Linq;
	using Unity.Transforms;

	public class AimSystem : ComponentSystem
	{
		public struct Data
		{
			public Animator anim;
			public AnimatorTriggeData animTrigger;
		}
		protected override void OnUpdate()
		{
			//if (Input.anyKeyDown)
			//	foreach (var item in GetEntities<Data>())
			//	{
			//		item.anim.SetTrigger(item.animTrigger.hash.ToString());
			//	}
		}
	}
}

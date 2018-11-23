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
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Unity.Linq;
	using Sirenix.OdinInspector;
	using UniRx;
	using Unity.Entities;
	using System;

	public class HealthUpdateSystem : ComponentSystem
	{
		public struct Data
		{
			public ComponentArray<HealthComponent> hp;
			public readonly int Length;
		}
		[Inject]
		private Data _data;
		protected override void OnUpdate ( )
		{
			var deltaTime=Time.deltaTime;
			for (int i = 0 ; i < _data.Length ; i++)
			{
				var h=_data.hp[i];
				h.value += Time.deltaTime;
			}
		}
	}
}

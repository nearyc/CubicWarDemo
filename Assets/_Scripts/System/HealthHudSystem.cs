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
	using Unity.Mathematics;

	public class HealthHudSystem : ComponentSystem
	{
		public struct Data
		{
			public HealthComponent hp;
			public Transform tran;
		}
		//[Inject]
		//private Data _data;
		public  TMPro.TextMeshProUGUI text;
		protected override void OnUpdate ( )
		{
			int hp;
			foreach (var entity in GetEntities<Data>( ))
			{
				hp = (int)math.floor(entity.hp.value);
				text.text = $"HP : {hp.ToString( )} \n Tran:{entity.tran.transform.position}";
			}
		}
		//public void SetupGameObjects ( )
		//{
		//	text=
		//}
	}
}

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
	using System.Collections.Generic;
	using System.Collections;
	using System;
	using CubicWarTest.Components;
	using Sirenix.OdinInspector;
	using UniRx;
	using Unity.Entities;
	using Unity.Linq;
	using Unity.Mathematics;
	using UnityEngine;
	using UnityEngine.UI;
	using UniRx.Triggers;
	using System.Linq;

	public class SquartRemoverMono : MonoBehaviour
	{
		private void OnMouseDown()
		{
			//if (!Input.GetKey(KeyCode.Space)) return;
			//var entity = GameObjectManagerSystem.gos.First(kvp => kvp.Value == gameObject).Key;
			//var em = World.Active.GetExistingManager<EntityManager>();

			//var evt = em.CreateEntity(typeof(AnimateTargetData));
			//em.SetComponentData(evt, new AnimateTargetData { target = entity });
		}
	}
}

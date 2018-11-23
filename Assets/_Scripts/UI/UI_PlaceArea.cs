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
	using System.Collections.Generic;
	using System.Collections;
	using System;
	using CubicWar.Components;
	using Sirenix.OdinInspector;
	using UniRx;
	using Unity.Entities;
	using Unity.Linq;
	using Unity.Mathematics;
	using UnityEngine;
	using UnityEngine.UI;
	using UniRx.Triggers;

	public class UI_PlaceArea : MonoBehaviour
	{
		private void Start ( )
		{
			var downObs=this.gameObject.AddComponent<ObservablePointerDownTrigger>();
			downObs.OnPointerDownAsObservable( ).Subscribe(x =>
			{
				if (!Input.GetKey(KeyCode.Space))
				{
					var em=World.Active.GetExistingManager<EntityManager>();
					var evt=em.CreateEntity(typeof(GenerateSquartPostionData),typeof(MyPrefab));
					var worldPos=Camera.main.ScreenToWorldPoint(x.position);
					worldPos.z = 0;
					em.SetComponentData(evt, new GenerateSquartPostionData { position = worldPos });
					var rd= UnityEngine.Random.Range(0, 2);
					if (rd == 0)
					{
						em.SetComponentData(evt, new MyPrefab { prefabPath = EPrefabDefine.Cube });
					}
					else
					{
						em.SetComponentData(evt, new MyPrefab { prefabPath = EPrefabDefine.Cube2 });
					}
				}
			}).AddTo(CubicWarWorld.instance);
		}
	}
}

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
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Unity.Linq;
	using UniRx;
	using System;
	using System.Linq;
	using Unity.Transforms;
	using UnityEngine.AddressableAssets;
	using UnityEngine.ResourceManagement;
	using UnityEngine.UI;
	using UniRx.Triggers;
	public class UI_InputArea : EntityMonoBase
	{
		private void Start()
		{
			var pdown = this.gameObject.AddComponent<ObservablePointerDownTrigger>();
			pdown.OnPointerDownAsObservable().Subscribe(x =>
			{
				if (!Input.GetKey(KeyCode.A))
				{
					for (int i = 0; i < 1; i++)
					{
						var worldPos = CameraMain.mainCam.ScreenToWorldPoint(x.position).ToFloat2();
						EntityManagerHelper.CreateMessageEntity(new InstantiateData
						{
							prefabDefine = EPrefabDefine.Cube3,
							worldPos = worldPos,
						});
					}
				}
			}).AddTo(this);
		}
	}
}

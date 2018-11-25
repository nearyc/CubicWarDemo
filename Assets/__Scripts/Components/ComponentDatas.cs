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
namespace CubicWar.Components
{
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
	using UnityEngine.AddressableAssets;
	using UnityEngine.ResourceManagement;
	using UnityEngine.UI;
	using UniRx.Triggers;

	public struct DragData : IComponentData
	{
		public float2 position;
	}
	public struct InstantiateData : IComponentData
	{
		public EPrefabDefine prefabDefine;
		public float2 worldPos;
		public quaternion worldRotation;
	}
	public struct ReleaseData : IComponentData
	{
		public Entity target;
	}
	public struct LifeTimeData : IComponentData
	{
		public float lifetime;
	}
}

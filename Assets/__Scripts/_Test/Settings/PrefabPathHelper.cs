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
	using UnityEngine.AddressableAssets;
	using UnityEngine.ResourceManagement;
	public enum EPrefabDefine : int
	{
		Cube = 0,
		Cube2 = 1,
	}
	public static class PrefabPathHelper
	{
		public static Dictionary<EPrefabDefine, string> paths = new Dictionary<EPrefabDefine, string>();

		public static void Init()
		{
			paths[EPrefabDefine.Cube] = "Test/Cube";
			paths[EPrefabDefine.Cube2] = "Test/Cube2";
		}
		public static string GetPath(EPrefabDefine prefabDefine)
		{
			return paths[prefabDefine];
		}
	}
	public static class AddressablesHelper
	{
		public static IAsyncOperation<T> InstantiatePrefab<T>(EPrefabDefine prefabDefine, Transform parent = null, bool instantiateInWorldSpace = false) where T : UnityEngine.Object
		{
			return Addressables.Instantiate<T>($"Assets/_Resources_moved/Prefabs/{PrefabPathHelper.paths[prefabDefine]}.prefab", parent, instantiateInWorldSpace);
		}
		public static IAsyncOperation<T> InstantiatePrefab<T>(EPrefabDefine prefabDefine, Vector3 position, Quaternion rotation, Transform parent = null) where T : UnityEngine.Object
		{
			return Addressables.Instantiate<T>($"Assets/_Resources_moved/Prefabs/{PrefabPathHelper.paths[prefabDefine]}.prefab", position, rotation, parent);
		}
		public static void ReleaseInstance(UnityEngine.Object obj,float delay=0)
		{
			Addressables.ReleaseInstance(obj, delay);
		}
	}
}

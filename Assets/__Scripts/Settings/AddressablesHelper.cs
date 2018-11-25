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
	using UnityEngine;
	using UnityEngine.AddressableAssets;
	using UnityEngine.ResourceManagement;

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
		public static void ReleaseInstance(UnityEngine.Object obj, float delay = 0)
		{
			Addressables.ReleaseInstance(obj, delay);
		}
	}
}

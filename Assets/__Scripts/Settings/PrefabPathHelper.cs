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
	using System.Collections.Generic;

	public enum EPrefabDefine : int
	{
		Cube1 = 0,
		Cube2 = 1,
		Cube3 = 2,
	}
	public static class PrefabPathHelper
	{
		public static Dictionary<EPrefabDefine, string> paths = new Dictionary<EPrefabDefine, string>();

		public static void Init()
		{
			paths[EPrefabDefine.Cube1] = "Test/Cube";
			paths[EPrefabDefine.Cube2] = "Test/Cube2";
			paths[EPrefabDefine.Cube3] = "Cube3";
		}
		public static string GetPath(EPrefabDefine prefabDefine)
		{
			return paths[prefabDefine];
		}
	}
}

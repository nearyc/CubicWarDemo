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
	using Unity.Mathematics;

	public static class FloatVectorConversionEx
	{
		public static float2 ToFloat2(this Vector3 v3)
		{
			return new float2(v3.x, v3.y);
		}
		public static Vector2 ToVector2(this float3 f3)
		{
			return new Vector2(f3.x, f3.y);
		}
		public static Vector3 ToVector3(this float2 f2, float z = 0)
		{
			return new Vector3(f2.x, f2.y, z);
		}
		public static float3 ToFloat3(this Vector2 v2, float z = 0)
		{
			return new float3(v2.x, v2.y, z);
		}
	}
}

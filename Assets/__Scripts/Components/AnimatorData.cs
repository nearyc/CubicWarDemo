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
	using Unity.Entities;

	public struct AnimatorSetBoolData : IComponentData
	{
		public EAimationDefine aimationDefine;
		public byte value;
		public Entity target;
	}
	public struct AnimatorSetTriggerData : IComponentData
	{
		public EAimationDefine aimationDefine;
		public Entity target;
	}
	public struct AnimatorSetFloatData : IComponentData
	{
		public EAimationDefine aimationDefine;
		public float value;
		public Entity target;
	}
	public struct AnimatorSetIntData : IComponentData
	{
		public EAimationDefine aimationDefine;
		public int value;
		public Entity target;
	}
}

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
namespace CubicWarTest
{
	using System.Collections.Generic;
	using System.Collections;
	using Systems;
	using DG.Tweening;
	using Sirenix.OdinInspector;
	using UniRx;
	using Unity.Entities;
	using Unity.Linq;
	using UnityEngine.SceneManagement;
	using UnityEngine;
	using Unity.Rendering;
	using Unity.Transforms;

	public class NoneWorld : BootstrapperBase
	{
		public static NoneWorld instance;
		protected override World OnCreateWorld ( )
		{
			instance = this;
			SetWorldActive = true;
			return new World("None World ");
		}

		protected override void OnRegisterSystems ( )
		{
			//RegisterSystem<AimSystem>( );
			//RegisterSystem<Components.RotationSpeedSystem>();
			//RegisterSystem<GameObjectManagerSystem>( );
			//RegisterSystem<RemoveSuqartSystem>( );
			//RegisterSystem<GameObjectTranformationReadSystem>( );
			//RegisterSystem<GameObjectTranformationWriteSystem>( );

			// Unity Systems
			//RegisterSystem<HeadingSystem>();
			//RegisterSystem<MoveForwardSystem>();
			//RegisterSystem<TransformInputBarrier>();
			//RegisterSystem<TransformSystem>();
			//RegisterSystem<MeshInstanceRendererSystem>();
			//RegisterSystem<MoveForward2DSystem>();
			//RegisterSystem<Transform2DSystem>();
			//RegisterSystem<CopyInitialTransformFromGameObjectSystem>();
			//RegisterSystem<CopyTransformFromGameObjectSystem>();
			//RegisterSystem<CopyTransformToGameObjectSystem>();
			//RegisterSystem<EndFrameTransformSystem>();

		}
	}
}

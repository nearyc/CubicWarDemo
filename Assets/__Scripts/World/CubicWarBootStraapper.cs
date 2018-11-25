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
	using System.Collections;
	using System;
	using DG.Tweening;
	using Sirenix.OdinInspector;
	using UniRx;
	using Unity.Entities;
	using Unity.Linq;
	using UnityEngine.SceneManagement;
	using UnityEngine;
	using CubicWar.Systems;

	public class CubicWarBootStraapper : BaseBootstrapper
	{
		public static CubicWarBootStraapper instance;
		protected override void InitWorld()
		{
			instance = this;
			var world = new World("CubicWar");
			base.world = new GameWorld(world);
		}

		protected override void OnRegisterSystems()
		{
			//同步transform
			TransormSyncSystem();
			//管理prefab生产销毁
			PrefabLifeSystem();
			//
			RegisterSystem<MoveJobSystem>();
			RegisterSystem<PlayerInputJobSystem>();
			RegisterSystem<AnimatorSystem>();
			RegisterSystem<DragJobSystem>();
		}
		private void PrefabLifeSystem()
		{
			RegisterSystem<InstantiatePrefabSystem>();
			RegisterSystem<ReleasePrefabSystem>();
			//RegisterSystem<LifeTimeJobSystem>();
		}
		private void TransormSyncSystem()
		{
			RegisterSystem<CopyFromTransformSystem>();
			RegisterSystem<CopyToTransformSystem>();
			//RegisterSystem<CopyFromTransformSystem2>();
			//RegisterSystem<Rigidbody2DSystem>();
		}
	}
}

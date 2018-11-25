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

	public abstract class BaseBootstrapper : MonoBehaviour
	{
		protected GameWorld world;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnBeforeSceneLoad()
		{
			var instances = FindObjectsOfType<BaseBootstrapper>();
			if (instances == null || instances.Length == 0)
				return;

			foreach (var ins in instances)
				ins.Initialize();
		}

		private void Initialize()
		{
			DontDestroyOnLoad(this);

			InitWorld();
			PrefabPathHelper.Init();
			PlayerLoopManager.RegisterDomainUnload(OnDomainUnloadShutdown, 10000);

			OnRegisterSystems();
			ScriptBehaviourUpdateOrder.UpdatePlayerLoop(world.ecsWorld);
		}

		protected ScriptBehaviourManager RegisterSystem<T>() where T : ComponentSystemBase
		{
			var type = typeof(T);
			if (type.IsAbstract || type.ContainsGenericParameters || !type.IsSubclassOf(typeof(ComponentSystemBase)))
				throw new Exception($"The System ({type.Name}) is abstract or has generic parameters. This is not allowed!");
			if (type.IsSubclassOf(typeof(BaseComponentSystem)))
				return RegisterBaseComponentSystem(type);
			else
				return world.ecsWorld.CreateManager<T>();
		}

		private ScriptBehaviourManager RegisterBaseComponentSystem(Type t)
		{
			return world.ecsWorld.CreateManager(t, world);
		}
		protected abstract void InitWorld();
		protected abstract void OnRegisterSystems();
		private static void OnDomainUnloadShutdown()
		{
			World.DisposeAllWorlds();
			ScriptBehaviourUpdateOrder.UpdatePlayerLoop();
		}
	}
}

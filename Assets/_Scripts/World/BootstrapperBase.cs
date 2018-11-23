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
    using Systems;
    using DG.Tweening;
    using Sirenix.OdinInspector;
    using UniRx;
    using Unity.Entities;
    using Unity.Linq;
    using UnityEngine.SceneManagement;
    using UnityEngine;

    public abstract class BootstrapperBase : MonoBehaviour
    {
        private World _world;

        public bool SetWorldActive { get; set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoad()
        {
            var instances = FindObjectsOfType<BootstrapperBase>();
            if (instances == null || instances.Length == 0)
                return;

            foreach (var ins in instances)
                ins.Initialize();
        }

        private void Initialize()
        {
            _world = OnCreateWorld();
            if (SetWorldActive)
                World.Active = _world;

            PlayerLoopManager.RegisterDomainUnload(OnDomainUnloadShutdown, 10000);

            OnRegisterSystems();
            ScriptBehaviourUpdateOrder.UpdatePlayerLoop(_world);
        }

        protected ScriptBehaviourManager RegisterSystem<T>() where T : ComponentSystemBase
        {
            return RegisterSystem(typeof(T));
        }

        protected ScriptBehaviourManager RegisterSystem(Type type)
        {
            if (type.IsAbstract || type.ContainsGenericParameters || !type.IsSubclassOf(typeof(ComponentSystemBase)))
                throw new Exception($"The System ({type.Name}) is abstract or has generic parameters. This is not allowed!");

            return _world.CreateManager(type);
        }

        protected abstract World OnCreateWorld();

        protected abstract void OnRegisterSystems();

        private static void OnDomainUnloadShutdown()
        {
            World.DisposeAllWorlds();
            ScriptBehaviourUpdateOrder.UpdatePlayerLoop();
        }
    }
}

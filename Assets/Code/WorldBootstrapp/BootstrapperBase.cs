using System;
using Unity.Entities;
using UnityEngine;

namespace Code.WorldBootstrapp
{
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

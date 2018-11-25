﻿#region Author & Version
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
namespace CubicWar.Systems
{
    using System.Collections.Generic;
    using CubicWar.Components;
    using Unity.Entities;
    using UnityEngine.Profiling;
    using UnityEngine;

    [DisableAutoCreation]
    public abstract class BaseComponentSystem : ComponentSystem
    {
        protected BaseComponentSystem(GameWorld world)
        {
            m_world = world;
        }

        readonly protected GameWorld m_world;
    }

    [DisableAutoCreation]
    public abstract class BaseComponentSystem<T1> : BaseComponentSystem
    where T1 : MonoBehaviour
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            var list = new List<ComponentType>(6);
            if (ExtraComponentRequirements != null)
                list.AddRange(ExtraComponentRequirements);
            list.AddRange(new ComponentType[] { typeof(T1) });
            Group = GetComponentGroup(list.ToArray());
        }

		protected EntityArray entityArray;
		protected virtual bool IsUseEntityArray => false;
		protected override void OnUpdate()
		{
			Profiler.BeginSample(name);
			if (IsUseEntityArray) entityArray = Group.GetEntityArray();

			var dataArray = Group.GetComponentArray<T1>();

            for (var i = 0; i < dataArray.Length; i++)
            {
                Update(i, dataArray[i]);
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentSystem<T1, T2> : BaseComponentSystem
    where T1 : Component
    where T2 : Component
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            var list = new List<ComponentType>(6);
            if (ExtraComponentRequirements != null)
                list.AddRange(ExtraComponentRequirements);
            list.AddRange(new ComponentType[] { typeof(T1), typeof(T2) });
            Group = GetComponentGroup(list.ToArray());
        }

		protected EntityArray entityArray;
		protected virtual bool IsUseEntityArray => false;
		protected override void OnUpdate()
		{
			Profiler.BeginSample(name);
			if (IsUseEntityArray) entityArray = Group.GetEntityArray();

			var dataArray1 = Group.GetComponentArray<T1>();
            var dataArray2 = Group.GetComponentArray<T2>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                Update(i, dataArray1[i], dataArray2[i]);
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data1, T2 data2);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentSystem<T1, T2, T3> : BaseComponentSystem
    where T1 : MonoBehaviour
    where T2 : MonoBehaviour
    where T3 : MonoBehaviour
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            var list = new List<ComponentType>(6);
            if (ExtraComponentRequirements != null)
                list.AddRange(ExtraComponentRequirements);
            list.AddRange(new ComponentType[] { typeof(T1), typeof(T2), typeof(T3) });
            Group = GetComponentGroup(list.ToArray());
        }

		protected EntityArray entityArray;
		protected virtual bool IsUseEntityArray => false;
		protected override void OnUpdate()
		{
			Profiler.BeginSample(name);
			if (IsUseEntityArray) entityArray = Group.GetEntityArray();

			var dataArray1 = Group.GetComponentArray<T1>();
            var dataArray2 = Group.GetComponentArray<T2>();
            var dataArray3 = Group.GetComponentArray<T3>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                Update(i, dataArray1[i], dataArray2[i], dataArray3[i]);
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data1, T2 data2, T3 data3);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentDataSystem<T1> : BaseComponentSystem
    where T1 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentDataSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            var list = new List<ComponentType>(6);
            if (ExtraComponentRequirements != null)
                list.AddRange(ExtraComponentRequirements);
            list.AddRange(new ComponentType[] { typeof(T1) });
            Group = GetComponentGroup(list.ToArray());
        }

		protected EntityArray entityArray;
		protected virtual bool IsUseEntityArray => false;
        protected override void OnUpdate()
        {
            Profiler.BeginSample(name);
			if (IsUseEntityArray) entityArray = Group.GetEntityArray();
            var dataArray = Group.GetComponentDataArray<T1>();
            for (var i = 0; i < dataArray.Length; i++)
            {
                var temp = dataArray[i];
                Update(i, ref temp);
                dataArray[i] = temp;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, ref T1 data);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentDataSystem<T1, T2> : BaseComponentSystem
    where T1 : struct, IComponentData
    where T2 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        private string name;

        public BaseComponentDataSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            name = GetType().Name;
            base.OnCreateManager();
            var list = new List<ComponentType>(6);
            if (ExtraComponentRequirements != null)
                list.AddRange(ExtraComponentRequirements);
            list.AddRange(new ComponentType[] { typeof(T1), typeof(T2) });
            Group = GetComponentGroup(list.ToArray());
        }

		protected EntityArray entityArray;
		protected virtual bool IsUseEntityArray => false;
		protected override void OnUpdate()
		{
			Profiler.BeginSample(name);
			if (IsUseEntityArray) entityArray = Group.GetEntityArray();

			var dataArray1 = Group.GetComponentDataArray<T1>();
            var dataArray2 = Group.GetComponentDataArray<T2>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp1 = dataArray1[i];
                var temp2 = dataArray2[i];
                Update(i, ref temp1, ref temp2);
                dataArray1[i] = temp1;
                dataArray2[i] = temp2;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, ref T1 data1, ref T2 data2);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentDataSystem<T1, T2, T3> : BaseComponentSystem
    where T1 : struct, IComponentData
    where T2 : struct, IComponentData
    where T3 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentDataSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            var list = new List<ComponentType>(6);
            if (ExtraComponentRequirements != null)
                list.AddRange(ExtraComponentRequirements);
            list.AddRange(new ComponentType[] { typeof(T1), typeof(T2), typeof(T3) });
            Group = GetComponentGroup(list.ToArray());
        }

		protected EntityArray entityArray;
		protected virtual bool IsUseEntityArray => false;
		protected override void OnUpdate()
		{
			Profiler.BeginSample(name);
			if (IsUseEntityArray) entityArray = Group.GetEntityArray();

			var dataArray1 = Group.GetComponentDataArray<T1>();
            var dataArray2 = Group.GetComponentDataArray<T2>();
            var dataArray3 = Group.GetComponentDataArray<T3>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp1 = dataArray1[i];
                var temp2 = dataArray2[i];
                var temp3 = dataArray3[i];
                Update(i, ref temp1, ref temp2, ref temp3);
                dataArray1[i] = temp1;
                dataArray2[i] = temp2;
                dataArray3[i] = temp3;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, ref T1 data1, ref T2 data2, ref T3 data3);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentDataSystem<T1, T2, T3, T4> : BaseComponentSystem
    where T1 : struct, IComponentData
    where T2 : struct, IComponentData
    where T3 : struct, IComponentData
    where T4 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentDataSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            var list = new List<ComponentType>(6);
            if (ExtraComponentRequirements != null)
                list.AddRange(ExtraComponentRequirements);
            list.AddRange(new ComponentType[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            Group = GetComponentGroup(list.ToArray());
        }

		protected EntityArray entityArray;
		protected virtual bool IsUseEntityArray => false;
		protected override void OnUpdate()
		{
			Profiler.BeginSample(name);
			if (IsUseEntityArray) entityArray = Group.GetEntityArray();

			var dataArray1 = Group.GetComponentDataArray<T1>();
            var dataArray2 = Group.GetComponentDataArray<T2>();
            var dataArray3 = Group.GetComponentDataArray<T3>();
            var dataArray4 = Group.GetComponentDataArray<T4>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp1 = dataArray1[i];
                var temp2 = dataArray2[i];
                var temp3 = dataArray3[i];
                var temp4 = dataArray4[i];
                Update(i, ref temp1, ref temp2, ref temp3, ref temp4);
                dataArray1[i] = temp1;
                dataArray2[i] = temp2;
                dataArray3[i] = temp3;
                dataArray4[i] = temp4;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, ref T1 data1, ref T2 data2, ref T3 data3, ref T4 data4);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentDataSystem<T1, T2, T3, T4, T5> : BaseComponentSystem
    where T1 : struct, IComponentData
    where T2 : struct, IComponentData
    where T3 : struct, IComponentData
    where T4 : struct, IComponentData
    where T5 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentDataSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            var list = new List<ComponentType>(6);
            if (ExtraComponentRequirements != null)
                list.AddRange(ExtraComponentRequirements);
            list.AddRange(new ComponentType[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            Group = GetComponentGroup(list.ToArray());
        }

		protected EntityArray entityArray;
		protected virtual bool IsUseEntityArray => false;
		protected override void OnUpdate()
		{
			Profiler.BeginSample(name);
			if (IsUseEntityArray) entityArray = Group.GetEntityArray();

			var dataArray1 = Group.GetComponentDataArray<T1>();
            var dataArray2 = Group.GetComponentDataArray<T2>();
            var dataArray3 = Group.GetComponentDataArray<T3>();
            var dataArray4 = Group.GetComponentDataArray<T4>();
            var dataArray5 = Group.GetComponentDataArray<T5>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp1 = dataArray1[i];
                var temp2 = dataArray2[i];
                var temp3 = dataArray3[i];
                var temp4 = dataArray4[i];
                var temp5 = dataArray5[i];
                Update(i, ref temp1, ref temp2, ref temp3, ref temp4, ref temp5);
                dataArray1[i] = temp1;
                dataArray2[i] = temp2;
                dataArray3[i] = temp3;
                dataArray4[i] = temp4;
                dataArray5[i] = temp5;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, ref T1 data1, ref T2 data2, ref T3 data3, ref T4 data4, ref T5 data5);
    }

    [DisableAutoCreation]
    [AlwaysUpdateSystem]
    public abstract class InitializeComponentSystem<T> : BaseComponentSystem
    where T : MonoBehaviour
    {
        struct SystemState : IComponentData { }
        protected ComponentGroup IncomingGroup;
        string name;

        public InitializeComponentSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            IncomingGroup = GetComponentGroup(typeof(T), ComponentType.Subtractive<SystemState>());
        }

        protected override void OnUpdate()
        {
            Profiler.BeginSample(name);

            var incomingEntityArray = IncomingGroup.GetEntityArray();
            if (incomingEntityArray.Length > 0)
            {
                var incomingComponentArray = IncomingGroup.GetComponentArray<T>();
                for (var i = 0; i < incomingComponentArray.Length; i++)
                {
                    var entity = incomingEntityArray[i];
                    PostUpdateCommands.AddComponent(entity, new SystemState());

                    Initialize(entity, incomingComponentArray[i]);
                }
            }

            Profiler.EndSample();
        }

        protected abstract void Initialize(Entity entity, T component);
    }

    [DisableAutoCreation]
    [AlwaysUpdateSystem]
    public abstract class InitializeComponentDataSystem<T> : BaseComponentSystem
    where T : struct, IComponentData
    {
        struct SystemState : IComponentData { }
        protected ComponentGroup IncomingGroup;
        string name;

        public InitializeComponentDataSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            IncomingGroup = GetComponentGroup(typeof(T), ComponentType.Subtractive<SystemState>());
        }

        protected override void OnUpdate()
        {
            Profiler.BeginSample(name);

            var incomingEntityArray = IncomingGroup.GetEntityArray();
            if (incomingEntityArray.Length > 0)
            {
                var incomingComponentDataArray = IncomingGroup.GetComponentDataArray<T>();
                for (var i = 0; i < incomingComponentDataArray.Length; i++)
                {
                    var entity = incomingEntityArray[i];
                    PostUpdateCommands.AddComponent(entity, new SystemState());

                    var temp1 = incomingComponentDataArray[i];
                    Initialize(entity, ref temp1);
                    incomingComponentDataArray[i] = temp1;
                }
            }

            Profiler.EndSample();
        }

        protected abstract void Initialize(Entity entity, ref T component);
    }

    [DisableAutoCreation]
    [AlwaysUpdateSystem]
    public abstract class DeinitializeComponentSystem<T> : BaseComponentSystem
    where T : MonoBehaviour
    {
        protected ComponentGroup OutgoingGroup;
        string name;

        public DeinitializeComponentSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            OutgoingGroup = GetComponentGroup(typeof(T), typeof(DespawningEntityData));
        }

        protected override void OnUpdate()
        {
            Profiler.BeginSample(name);

            var outgoingComponentArray = OutgoingGroup.GetComponentArray<T>();
            var outgoingEntityArray = OutgoingGroup.GetEntityArray();
            for (var i = 0; i < outgoingComponentArray.Length; i++)
            {
                Deinitialize(outgoingEntityArray[i], outgoingComponentArray[i]);
            }

            Profiler.EndSample();
        }

        protected abstract void Deinitialize(Entity entity, T component);
    }

    [DisableAutoCreation]
    [AlwaysUpdateSystem]
    public abstract class DeinitializeComponentDataSystem<T> : BaseComponentSystem
    where T : struct, IComponentData
    {
        protected ComponentGroup OutgoingGroup;
        string name;

        public DeinitializeComponentDataSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            OutgoingGroup = GetComponentGroup(typeof(T), typeof(DespawningEntityData));
        }

        protected override void OnUpdate()
        {
            Profiler.BeginSample(name);

            var outgoingComponentArray = OutgoingGroup.GetComponentDataArray<T>();
            var outgoingEntityArray = OutgoingGroup.GetEntityArray();
            for (var i = 0; i < outgoingComponentArray.Length; i++)
            {
                var temp = outgoingComponentArray[i];
                Deinitialize(outgoingEntityArray[i], ref temp);
                outgoingComponentArray[i] = temp;
            }

            Profiler.EndSample();
        }

        protected abstract void Deinitialize(Entity entity, ref T component);
    }

    [DisableAutoCreation]
    [AlwaysUpdateSystem]
    public abstract class InitializeComponentGroupSystem<T, S> : BaseComponentSystem
    where T : MonoBehaviour
    where S : struct, IComponentData
    {
        protected ComponentGroup IncomingGroup;
        string name;

        public InitializeComponentGroupSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            IncomingGroup = GetComponentGroup(typeof(T), ComponentType.Subtractive<S>());
        }

        protected override void OnUpdate()
        {
            Profiler.BeginSample(name);

            var incomingEntityArray = IncomingGroup.GetEntityArray();
            if (incomingEntityArray.Length > 0)
            {
                for (var i = 0; i < incomingEntityArray.Length; i++)
                {
                    var entity = incomingEntityArray[i];
                    PostUpdateCommands.AddComponent(entity, new S());
                }
                Initialize(ref IncomingGroup);
            }
            Profiler.EndSample();
        }

        protected abstract void Initialize(ref ComponentGroup group);
    }

    [DisableAutoCreation]
    [AlwaysUpdateSystem]
    public abstract class DeinitializeComponentGroupSystem<T> : BaseComponentSystem
    where T : MonoBehaviour
    {
        protected ComponentGroup OutgoingGroup;
        string name;

        public DeinitializeComponentGroupSystem(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            OutgoingGroup = GetComponentGroup(typeof(T), typeof(DespawningEntityData));
        }

        protected override void OnUpdate()
        {
            Profiler.BeginSample(name);

            if (OutgoingGroup.CalculateLength() > 0)
                Deinitialize(ref OutgoingGroup);

            Profiler.EndSample();
        }

        protected abstract void Deinitialize(ref ComponentGroup group);
    }
}

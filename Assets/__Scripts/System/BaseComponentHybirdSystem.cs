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
namespace CubicWar.Systems
{
    using System.Collections.Generic;
    using Unity.Entities;
    using UnityEngine.Profiling;
    using UnityEngine;

    [DisableAutoCreation]
    public abstract class BaseComponentHybirdSystem_11<T1, T2> : BaseComponentSystem
    where T1 : Component
    where T2 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentHybirdSystem_11(GameWorld world) : base(world) { }

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
            var dataArray2 = Group.GetComponentDataArray<T2>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp = dataArray2[i];
                Update(i, dataArray1[i], ref temp);
                dataArray2[i] = temp;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data1, ref T2 data2);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentHybirdSystem_12<T1, T2, T3> : BaseComponentSystem
    where T1 : MonoBehaviour
    where T2 : struct, IComponentData
    where T3 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentHybirdSystem_12(GameWorld world) : base(world) { }

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
            var dataArray2 = Group.GetComponentDataArray<T2>();
            var dataArray3 = Group.GetComponentDataArray<T3>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp2 = dataArray2[i];
                var temp3 = dataArray3[i];
                Update(i, dataArray1[i], ref temp2, ref temp3);
                dataArray2[i] = temp2;
                dataArray3[i] = temp3;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data1, ref T2 data2, ref T3 data3);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentHybirdSystem_13<T1, T2, T3, T4> : BaseComponentSystem
    where T1 : MonoBehaviour
    where T2 : struct, IComponentData
    where T3 : struct, IComponentData
    where T4 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentHybirdSystem_13(GameWorld world) : base(world) { }

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

			var dataArray1 = Group.GetComponentArray<T1>();
            var dataArray2 = Group.GetComponentDataArray<T2>();
            var dataArray3 = Group.GetComponentDataArray<T3>();
            var dataArray4 = Group.GetComponentDataArray<T4>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp2 = dataArray2[i];
                var temp3 = dataArray3[i];
                var temp4 = dataArray4[i];
                Update(i, dataArray1[i], ref temp2, ref temp3, ref temp4);
                dataArray2[i] = temp2;
                dataArray3[i] = temp3;
                dataArray4[i] = temp4;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data1, ref T2 data2, ref T3 data3, ref T4 data4);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentHybirdSystem_14<T1, T2, T3, T4, T5> : BaseComponentSystem
    where T1 : MonoBehaviour
    where T2 : struct, IComponentData
    where T3 : struct, IComponentData
    where T4 : struct, IComponentData
    where T5 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentHybirdSystem_14(GameWorld world) : base(world) { }

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

			var dataArray1 = Group.GetComponentArray<T1>();
            var dataArray2 = Group.GetComponentDataArray<T2>();
            var dataArray3 = Group.GetComponentDataArray<T3>();
            var dataArray4 = Group.GetComponentDataArray<T4>();
            var dataArray5 = Group.GetComponentDataArray<T5>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp2 = dataArray2[i];
                var temp3 = dataArray3[i];
                var temp4 = dataArray4[i];
                var temp5 = dataArray5[i];
                Update(i, dataArray1[i], ref temp2, ref temp3, ref temp4, ref temp5);
                dataArray2[i] = temp2;
                dataArray3[i] = temp3;
                dataArray4[i] = temp4;
                dataArray5[i] = temp5;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data1, ref T2 data2, ref T3 data3, ref T4 data4, ref T5 data5);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentHybirdSystem_21<T1, T2, T3> : BaseComponentSystem
    where T1 : Component
    where T2 : Component
    where T3 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentHybirdSystem_21(GameWorld world) : base(world) { }

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
            var dataArray3 = Group.GetComponentDataArray<T3>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp3 = dataArray3[i];
                Update(i, dataArray1[i], dataArray2[i], ref temp3);
                dataArray3[i] = temp3;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data1, T2 data2, ref T3 data3);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentHybirdSystem_22<T1, T2, T3, T4> : BaseComponentSystem
    where T1 : MonoBehaviour
    where T2 : MonoBehaviour
    where T3 : struct, IComponentData
    where T4 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentHybirdSystem_22(GameWorld world) : base(world) { }

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

			var dataArray1 = Group.GetComponentArray<T1>();
            var dataArray2 = Group.GetComponentArray<T2>();
            var dataArray3 = Group.GetComponentDataArray<T3>();
            var dataArray4 = Group.GetComponentDataArray<T4>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp3 = dataArray3[i];
                var temp4 = dataArray4[i];
                Update(i, dataArray1[i], dataArray2[i], ref temp3, ref temp4);
                dataArray3[i] = temp3;
                dataArray4[i] = temp4;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data1, T2 data2, ref T3 data3, ref T4 data4);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentHybirdSystem_23<T1, T2, T3, T4, T5> : BaseComponentSystem
    where T1 : MonoBehaviour
    where T2 : MonoBehaviour
    where T3 : struct, IComponentData
    where T4 : struct, IComponentData
    where T5 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentHybirdSystem_23(GameWorld world) : base(world) { }

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

			var dataArray1 = Group.GetComponentArray<T1>();
            var dataArray2 = Group.GetComponentArray<T2>();
            var dataArray3 = Group.GetComponentDataArray<T3>();
            var dataArray4 = Group.GetComponentDataArray<T4>();
            var dataArray5 = Group.GetComponentDataArray<T5>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp3 = dataArray3[i];
                var temp4 = dataArray4[i];
                var temp5 = dataArray5[i];
                Update(i, dataArray1[i], dataArray2[i], ref temp3, ref temp4, ref temp5);
                dataArray3[i] = temp3;
                dataArray4[i] = temp4;
                dataArray5[i] = temp5;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data1, T2 data2, ref T3 data3, ref T4 data4, ref T5 data5);
    }

    [DisableAutoCreation]
    public abstract class BaseComponentHybirdSystem_24<T1, T2, T3, T4, T5, T6> : BaseComponentSystem
    where T1 : MonoBehaviour
    where T2 : MonoBehaviour
    where T3 : struct, IComponentData
    where T4 : struct, IComponentData
    where T5 : struct, IComponentData
    where T6 : struct, IComponentData
    {
        protected ComponentGroup Group;
        protected ComponentType[] ExtraComponentRequirements;
        string name;

        public BaseComponentHybirdSystem_24(GameWorld world) : base(world) { }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            name = GetType().Name;
            var list = new List<ComponentType>(6);
            if (ExtraComponentRequirements != null)
                list.AddRange(ExtraComponentRequirements);
            list.AddRange(new ComponentType[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) });
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
            var dataArray3 = Group.GetComponentDataArray<T3>();
            var dataArray4 = Group.GetComponentDataArray<T4>();
            var dataArray5 = Group.GetComponentDataArray<T5>();
            var dataArray6 = Group.GetComponentDataArray<T6>();

            for (var i = 0; i < dataArray1.Length; i++)
            {
                var temp3 = dataArray3[i];
                var temp4 = dataArray4[i];
                var temp5 = dataArray5[i];
                var temp6 = dataArray6[i];
                Update(i, dataArray1[i], dataArray2[i], ref temp3, ref temp4, ref temp5, ref temp6);
                dataArray3[i] = temp3;
                dataArray4[i] = temp4;
                dataArray5[i] = temp5;
                dataArray6[i] = temp6;
            }

            Profiler.EndSample();
        }

        protected abstract void Update(int index, T1 data1, T2 data2, ref T3 data3, ref T4 data4, ref T5 data5, ref T6 data6);
    }
}

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
	using CubicWar.Components;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Unity.Linq;
	using Sirenix.OdinInspector;
	using UniRx;
	using Unity.Entities;
	using System;
	using Unity.Mathematics;
	using System.Linq;
	using Unity.Transforms;
	public class PrefabPaths
	{
		public string test="Prefabs/Cube";
	}
	public class GenerateSquartSystem : ComponentSystem
	{
		EntityArchetype squartArchetype;
		protected override void OnCreateManager ( )
		{
			squartArchetype = EntityManager.CreateArchetype(typeof(MyPrefab), typeof(Position));
		}
		public struct GenerateData
		{
			public readonly int Length;
			public ComponentDataArray<GenerateSquartPostionData> mousePressEvents;
			public ComponentDataArray<MyPrefab> prefab;
			public EntityArray entities;
		}

		[Inject]
		public GenerateData _data;

		protected override void OnUpdate ( )
		{
			for (var i = 0 ; i != _data.Length ; i++)
			{
				var target = _data.mousePressEvents[i].position;

				PostUpdateCommands.CreateEntity(squartArchetype);
				PostUpdateCommands.SetComponent(new MyPrefab { prefabPath = _data.prefab[i].prefabPath });
				PostUpdateCommands.SetComponent(new Position { Value = _data.mousePressEvents [i].position });
				//Debug.Log(_data.mousePressEvents [i].position);

				PostUpdateCommands.DestroyEntity(_data.entities [i]);
			}
		}
	}
	public class RemoveSuqartSystem : ComponentSystem
	{

		EntityArchetype squartArchetype;
		protected override void OnCreateManager ( )
		{
			squartArchetype = EntityManager.CreateArchetype(typeof(MyPrefab), typeof(Position));

		}
		public struct RemoveData
		{
			public readonly int Length;
			public ComponentDataArray<RemoveSquartEntityData> removeData;
			public EntityArray entities;
		}

		[Inject]
		public RemoveData _data;
		protected override void OnUpdate ( )
		{
			for (var i = 0 ; i != _data.Length ; i++)
			{
				var target = _data.removeData[i].target;
				PostUpdateCommands.DestroyEntity(_data.entities [i]);
				PostUpdateCommands.DestroyEntity(target);
			}
		}
	}
}

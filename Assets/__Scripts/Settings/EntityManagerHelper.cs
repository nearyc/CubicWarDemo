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
	using CubicWar.Components;
	using Unity.Entities;
	using UnityEngine;

	public static class EntityManagerHelper
	{
		public static EntityManager manager => World.Active.GetExistingManager<EntityManager>();
		private static Entity _messageEntity;
		/// <summary>
		/// 创造messageEnityt
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		/// <returns></returns>
		public static Entity CreateMessageEntity<T>(T data) where T : struct, IComponentData
		{
			_messageEntity = manager.CreateEntity(typeof(T));
			manager.SetComponentData(_messageEntity, data);
			return _messageEntity;
		}
		/// <summary>
		/// 如果goEntity存在有component，则返回entity，否则返回空entity
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static Entity GOEntityHasComponent<T>(UnityEngine.Component obj)
		{
			var entity = obj.GetComponent<GameObjectEntity>()?.Entity;
			if (entity.HasValue && manager.HasComponent<T>(entity.Value))
			{
				return entity.Value;
			}
			return Entity.Null;
		}
		/// <summary>
		/// 如果goEntity存在，则设置data
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="em"></param>
		/// <param name="obj"></param>
		/// <param name="data"></param>
		public static Entity GOSetComponentDataIfContains<T>(UnityEngine.GameObject obj, T data) where T : struct, IComponentData
		{
			var e = obj.GetComponent<GameObjectEntity>()?.Entity;
			if (e.HasValue)
			{
				manager.SetComponentData<T>(e.Value, data);
				return e.Value;
			}
			return Entity.Null;
		}

		public static void GOAddComponentData<T>(GameObject go, T t) where T : struct, IComponentData
		{
			var entity = go.GetComponent<GameObjectEntity>()?.Entity;
			if (entity.HasValue)
			{
				manager.AddComponentData(entity.Value, t);
			}
		}


	}
}

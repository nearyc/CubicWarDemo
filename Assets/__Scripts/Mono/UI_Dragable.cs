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
	using UniRx;
	using Unity.Mathematics;
	using UniRx.Triggers;

	public class UI_Dragable : EntityMonoBase
	{
		private void Start()
		{
			float2 offset = new float2();

			var beginDrag = this.gameObject.AddComponent<ObservableBeginDragTrigger>();
			beginDrag.OnBeginDragAsObservable().Subscribe(x =>
			{
				var worldPos = CameraMain.mainCam.ScreenToWorldPoint(x.position).ToFloat2();
				var pos2d = this.GetEntityComponentData<Position2DData>();
				offset = worldPos - pos2d.world;
				entityManager.AddComponentData(entity, new DragData
				{
					position = pos2d.world
				});
			}).AddTo(this);

			var onDrag = this.gameObject.AddComponent<ObservableDragTrigger>();
			onDrag.OnDragAsObservable().Subscribe(x =>
			{
				var worldPos = CameraMain.mainCam.ScreenToWorldPoint(x.position).ToFloat2();
				entityManager.SetComponentData(entity, new DragData
				{
					position = worldPos - offset
				});
			}).AddTo(this);

			var endDrag = this.gameObject.AddComponent<ObservableEndDragTrigger>();
			endDrag.OnEndDragAsObservable().Subscribe(x =>
			{
				offset = new float2();
				entityManager.RemoveComponent(entity, typeof(DragData));
			}).AddTo(this);
		}
	}
}

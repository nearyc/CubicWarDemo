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
    using DG.Tweening;
    using Sirenix.OdinInspector;
    using UniRx;
    using Unity.Linq;
    using UnityEngine;
	using UnityEngine.AddressableAssets;
	using CubicWarTest.Systems;

	public class UnirxWithEcsTest : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI _text;
        // Use this for initialization
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
        IEnumerator Start()
        {
			Observable.IntervalFrame(20).Subscribe(x => Debug.Log("----")).AddTo(this);
			//Observable.IntervalFrame(60).Subscribe(x => text.text = x.ToString()).AddTo(this);
			this.transform.DOMoveX(100, 1000);
			var aop=	Addressables.PreloadDependencies(PrefabPathHelper.paths[EPrefabDefine.Cube], x=> {
				Debug.Log(x.Result);
			});
			yield return aop;
			aop.Completed += x =>
			{
				Debug.Log("Complete all");
			};

			Observable.Interval(System.TimeSpan.FromMilliseconds(500)).Subscribe(__ =>
			{
				var aop2 = Addressables.Instantiate<GameObject>(PrefabPathHelper.paths[EPrefabDefine.Cube]);
				aop2.Completed += x =>
				{
					Debug.Log(x.Result.name);
					x.Result.transform.position = new Vector3(Random.Range(-2, 2), Random.Range(-2,2), 0);
				};
			}).AddTo(this);
		}
    }
}

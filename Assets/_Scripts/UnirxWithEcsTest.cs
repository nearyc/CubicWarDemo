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
    using DG.Tweening;
    using Sirenix.OdinInspector;
    using UniRx;
    using Unity.Linq;
    using UnityEngine;

    public class UnirxWithEcsTest : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI text;
        // Use this for initialization
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
        void Start()
        {
            //Observable.IntervalFrame(20).Subscribe(x => Debug.Log("----")).AddTo(this);
            Observable.IntervalFrame(60).Subscribe(x => text.text = x.ToString()).AddTo(this);
            //this.transform.DOMoveX(100, 1000);
        }

        // Update is called once per frame
        void Update() { }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using UniRx.Triggers;
using System;
using System.Linq;

public class InputController : MonoBehaviour
{
    public static Action _DoubleClickEventHandler = null;
    public static Action<Vector3> _DragEventHandler = null;
    private Camera _camera = null;
    // Use this for initialization
    void Start()
    {
#if UNITY_EDITOR
        var drag = Observable.EveryUpdate().Select(pos => Input.mousePosition);
        var stop = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0)).First();
        var start = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).First();
#elif UNITY_IOS || UNITY_ANDROID
    var drag = Observable.EveryUpdate ().Select (pos => Input.GetTouch(0).position);
    var stop = Observable.EveryUpdate ().Where(_ => Input.touchCount != 1).First();
#endif

        // 행동을 먼저 구현하고 받아야할 데이터를 가공한다.!!
        IDisposable onDrag = drag.Buffer(3)
            .SkipUntil(start)
            .TakeUntil(stop)
            .Repeat()
            .Subscribe(colPos => {
                float delPosx = Input.mousePosition.x - colPos.First().x;
                float delPosz = Input.mousePosition.z - colPos.First().y;
                Vector3 vec = new Vector3(delPosx, 0, delPosz);
                Debug.Log(vec);
            });
        //        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
        //            .Where(xs => xs.Count >= 2)
        //            .Subscribe(xs =>
        //            {
        //#if _DEBUG_
        //                Debug.Log("Double_Click");
        //#endif
        //                if (_DoubleClickEventHandler == null)
        //                    return;

        //                _DoubleClickEventHandler();
        //            });
    }
}

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
        var clickStream = Observable.EveryUpdate()
            .Select(_ => Input.GetMouseButtonDown(0));

        var clickUpStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonUp(0));

        var dragStream = Observable.EveryUpdate()
            .SkipUntil(clickStream)
            .Select(_ => new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"))) // 변화량
            .TakeUntil(clickUpStream)
            .Repeat()
            .Subscribe(_ =>
            {
#if _DEBUG_
                Debug.Log(string.Format("Drag : {0}", _));
#endif
                if (_DragEventHandler == null)
                    return;

                _DragEventHandler(_);
            });

        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
            .Where(xs => xs.Count >= 2)
            .Subscribe(xs =>
            {
#if _DEBUG_
                Debug.Log("Double_Click");
#endif
                if (_DoubleClickEventHandler == null)
                    return;

                _DoubleClickEventHandler();
            });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using UniRx.Triggers;
using System;
using System.Linq;
using HedgehogTeam.EasyTouch;

public class InputController : MonoBehaviour
{
    public static Action<Gesture> _ClickEventHandler = null;
    public static Action _DoubleClickEventHandler = null;
    public static Action<Vector2> _DragEventHandler = null;

    private Ray ray;
    private RaycastHit rayHit;

    Gesture current;
    // Use this for initialization
    void Start()
    {
        //Event.Instance.drag = Observable.EveryUpdate().Select(_ => Input.mousePosition);

        Observable.EveryUpdate()
            .Subscribe(x =>
            {
                current = EasyTouch.current;
                if (current == null)
                    return;
                if (current.type == EasyTouch.EvtType.On_SimpleTap)
                {
                    // Touch
#if _DEBUG_
                    Debug.Log("Touch");
#endif
                    if (_ClickEventHandler != null)
                        _ClickEventHandler(current);
                }
                else if (current.type == EasyTouch.EvtType.On_Drag)
                {
                    // Drag
#if _DEBUG_
                    Debug.Log("Touch");
#endif
                    if (_DragEventHandler != null)
                        _DragEventHandler(current.deltaPosition);
                }
            });
        //        Event.Instance.drag = Observable.EveryUpdate()
        //            .Select(x =>
        //            {
        //                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //                Physics.Raycast(ray, out rayHit);
        //                return rayHit.point;
        //            });
        //        Event.Instance.clickDown = Observable.EveryUpdate().Where(x => Input.GetMouseButtonDown(0))
        //            .Select(x =>
        //            {
        //                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //                Physics.Raycast(ray, out rayHit);
        //                return rayHit.point;
        //            });
        //        var clickUp = Observable.EveryUpdate().Where(x => Input.GetMouseButtonUp(0));

        //        Observable.CombineLatest(Event.Instance.clickDown, Event.Instance.drag)
        //            .TakeUntil(clickUp)
        //            .Repeat()
        //            .Select(point => new Vector3((point[1].z - point[0].z) / 10, 0, (point[1].x - point[0].x) / 10))
        //            .Subscribe(point =>
        //            {
        //#if _DEBUG_
        //                Debug.Log("CombineLatest :" + point);
        //#endif
        //                if (_DragEventHandler != null)
        //                {
        //                    _DragEventHandler(point);
        //                }
        //            });
        //    }
    }
}

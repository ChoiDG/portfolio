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

    private Ray ray;
    private RaycastHit rayHit;

    // Use this for initialization
    void Start()
    {
        var drag = Observable.EveryUpdate().Select(x =>
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out rayHit);
            return rayHit.point;
        });
        var clickDown = Observable.EveryUpdate().Where(x => Input.GetMouseButtonDown(0))
            .Select(x =>
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out rayHit);
                return rayHit.point;
            });

        Observable.CombineLatest(clickDown, drag)
            .TakeUntil(Observable.EveryUpdate().Where(x=>Input.GetMouseButtonUp(0)))
            .Repeat()
            .Select(point => new Vector3(point[1].x - point[0].x, 0, point[1].y - point[0].y))
            .Subscribe(point =>
            {
#if _DEBUG_
                Debug.Log("CombineLatest :" +  point);
#endif
                if(_DragEventHandler != null)
                {
                    _DragEventHandler(point);
                }
            });
    }

}

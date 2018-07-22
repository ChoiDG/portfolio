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
    private Camera mainCamera = null;

    private Ray ray;
    private RaycastHit rayHit;
    private Vector3 _buttondownPos;

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
        var drag = Observable.EveryUpdate().Select(_ => Input.mousePosition);
        var clickDown = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ =>
            {
                ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out rayHit);
                Debug.Log(rayHit.point);
                _buttondownPos = rayHit.point;
                return rayHit.point;
            });

        Observable.EveryUpdate().Select(_ => Input.mousePosition)
            .SkipUntil(Observable.EveryUpdate().Where(_=>Input.GetMouseButtonDown(0)))
            .TakeUntil(Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0)))
            .Repeat()
            .Subscribe(_ =>
            {
                Debug.Log(string.Format("{0} : {1}", _buttondownPos, _));
            });
    }

}

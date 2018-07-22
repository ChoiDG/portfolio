using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBase
{
    protected override void Start()
    {
        InputController._DragEventHandler += OnRecvDragPoint;
    }
    protected override void Activate()
    {
    }

    private void OnRecvDragPoint(Vector3 pos)
    {
        Debug.Log(pos);
        Move(pos);
    }
}

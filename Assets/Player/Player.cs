using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class Player : PlayerBase
{
    public enum State
    {
        Run,
        Jump,
        Fall,
        Die,
    }

    public IObservable<State> PlayerState;
    
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

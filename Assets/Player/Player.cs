using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

using HedgehogTeam.EasyTouch;
public class Player : PlayerBase
{
    protected override void Start()
    {
        InputController._ClickEventHandler += OnRecvClickEvent;
        InputController._DragEventHandler += OnRecvDragPoint;
        UniEvent.Instance.PlayerState.Subscribe(state =>
        {
            switch (state)
            {
                case UniEvent.EPlayerState.Run:
                    Debug.Log("Run");
                    break;
                case UniEvent.EPlayerState.Jump:
                    Debug.Log("jump");
                    break;
                case UniEvent.EPlayerState.Fall:
                    Debug.Log("fall");
                    break;
                case UniEvent.EPlayerState.Die:
                    Debug.Log("die");
                    break;
            }
        });
    }
    protected override void Activate()
    {
    }

    private void OnRecvDragPoint(Vector2 pos)
    {
        Move(pos);
    }

    private void OnRecvClickEvent(Gesture gesture)
    {
        Move(gesture.position);
    }
}

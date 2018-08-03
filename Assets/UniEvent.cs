using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniEvent : Singleton<UniEvent>
{
    public IObservable<Vector3> drag;
    public IObservable<Vector3> clickDown;

    // Player
    public enum EPlayerState
    {
        Run,
        Jump,
        Fall,
        Die,
    }
    public Subject<EPlayerState> PlayerState = new Subject<EPlayerState>();

    protected UniEvent()
    {

    }

    ~UniEvent()
    {

    }
}

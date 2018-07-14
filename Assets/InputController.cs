using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using UniRx.Triggers;

public class InputController : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        this.UpdateAsObservable()
            .SkipUntil(this.OnMouseDownAsObservable())
            .Select(_ => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")))
            .TakeUntil(this.OnMouseUpAsObservable())
            .Repeat()
            .Subscribe(move => { Debug.Log(move); });
        
    }
}

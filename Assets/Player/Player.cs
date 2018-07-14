using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBase
{
	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        _rigidbody = GetComponent<Rigidbody>();
        InputController._DragEventHandler += OnDragEvent;
    }

    private void OnDestroy()
    {
        InputController._DragEventHandler -= OnDragEvent;
    }
    protected override void Activate()
    {
    }

    private void OnDragEvent(Vector3 vec)
    {
        Move(vec);
    }
}

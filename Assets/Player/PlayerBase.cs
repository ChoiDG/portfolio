using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    protected Animator _animator = null;
    protected CharacterController _controller = null;
	// Use this for initialization
	protected virtual void Start ()
    {
        InputController._DragEventHandler += OnDragEvent;
	}

    private void OnDestroy()
    {
        InputController._DragEventHandler -= OnDragEvent;
    }
    protected void Move(Vector2 vec)
    {
    }

    private void OnDragEvent(Vector2 vec)
    {
        Move(vec);
    }
    protected abstract void Activate();
}

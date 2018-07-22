using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    protected Animator _animator = null;
    protected Rigidbody _rigidbody = null;
	// Use this for initialization
	protected virtual void Start ()
    {
	}

    protected void Move(Vector3 vec)
    {
        transform.localPosition = vec;
    }

    protected abstract void Activate();
}

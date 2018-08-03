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

    protected void Move(Vector2 vec)
    {
        transform.localPosition += new Vector3(vec.x, 0, vec.y);
    }

    protected abstract void Activate();
}

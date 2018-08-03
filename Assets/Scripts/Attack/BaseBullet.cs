using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    public IAttacker Attacker { get; set; }
    public float DamagePower { get; set; }
}

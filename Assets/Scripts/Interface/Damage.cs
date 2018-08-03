using System;
using UnityEngine;

namespace Assets.Portfolio.Scripts.Damages
{
    [Serializable]
    public struct Damage
    {
        public IAttacker Attacker;
        public float Value;
        public Vector3 Direction;
    }
}
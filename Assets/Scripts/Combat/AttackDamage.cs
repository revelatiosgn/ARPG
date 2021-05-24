using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Controller;

namespace ARPG.Combat
{
    public enum AttackDamageType
    {
        Physic,
        Magic
    }

    public class AttackDamage
    {
        AttackDamageType damageType;
        float damage = 0f;
        Vector3 direction = Vector3.forward;
        bool isReduced = false;
        BaseController source = null;

        public AttackDamageType DamageType { get => damageType; }
        public float Damage { get => damage; set => damage = value; }
        public Vector3 Direction { get => direction; set => direction = value; }
        public bool IsReduced { get => isReduced; set => isReduced = value; }
        public BaseController Source { get => source; set => source = value; }

        public AttackDamage(AttackDamageType damageType, float damage)
        {
            this.damageType = damageType;
            this.damage = damage;
        }

        public AttackDamage(AttackDamageType damageType, float damage, Vector3 direction) : this(damageType, damage)
        {
            this.direction = direction;
        }
    }
}
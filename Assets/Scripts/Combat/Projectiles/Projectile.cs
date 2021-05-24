using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Stats;
using ARPG.Controller;

namespace ARPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        float speed;
        AttackDamage attackDamage;

        public float Speed { get => speed; set => speed = value; }
        public AttackDamage AttackDamage { get => attackDamage; set => attackDamage = value; }

        private bool isLaunched;

        public void Launch()
        {
            isLaunched = true;
            Destroy(gameObject, 5f);
        }

        void Update()
        {
            if (!isLaunched)
                return;

            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        }

        void OnTriggerEnter(Collider collider)
        {
            if (!isLaunched)
                return;

            BaseController baseController = collider.GetComponent<BaseController>();
            if ((attackDamage.Source == null) ||
                (baseController != null && baseController.CharacterGroup != attackDamage.Source.CharacterGroup))
            {
                attackDamage.Direction = transform.forward;
                baseController.GetComponent<BaseCombat>()?.TakeDamage(attackDamage);
            }

            Destroy(gameObject);
        }
    }
}



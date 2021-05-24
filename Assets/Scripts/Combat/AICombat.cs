using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARPG.Controller;

namespace ARPG.Combat
{
    public class AICombat : BaseCombat
    {
        AIController aiController;

        BaseController target = null;
        public BaseController Target { get => target; set => target = value; }
        
        protected override void Awake()
        {
            base.Awake();

            aiController = GetComponent<AIController>();
        }

        void Update()
        {
            if (target == null && aiController.AILook.Targets.Count > 0)
                target = aiController.AILook.Targets[0];
        }

        public override void TakeDamage(AttackDamage attackDamage)
        {
            base.TakeDamage(attackDamage);

            if (target == null && attackDamage.Source != null)
                target = attackDamage.Source;
        }
    }
}
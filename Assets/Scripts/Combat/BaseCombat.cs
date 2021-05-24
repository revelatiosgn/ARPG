using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using ARPG.Core;
using ARPG.Stats;
using Animancer;
using ARPG.Controller;
using ARPG.Gear;

namespace ARPG.Combat
{
    [System.Serializable]
    public class ICombatingReference : InterfaceReference<ICombating>
    {
        public ICombatingReference(ICombating obj)
        {
            this.Object = obj;
        }
    }

    [System.Serializable]
    public class IProjectileReference : InterfaceReference<IProjectile>
    {
        public IProjectileReference(IProjectile obj)
        {
            this.Object = obj;
        }
    }

    public abstract class BaseCombat : MonoBehaviour
    {
        public enum State
        {
            Idle,
            Action
        }

        State combatState = State.Idle;
        public State CombatState { get => combatState; set => combatState = value; }

        public Quaternion aimRotation;
        public Vector3 targetPosition;

        bool isAttacking = false;
        bool isDefending = false;

        public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
        public bool IsDefending { get => isDefending; set => isDefending = value; }

        protected BaseController baseController;
        protected Animatrix animatrix;
        protected CharacterStats characterStats;
        protected Equipment equipment;

        public Animatrix Animatrix { get => animatrix; }
        public CharacterStats CharacterStats { get => characterStats; }
        public Equipment Equipment { get => equipment; }

        [SerializeField] List<ICombatingReference> combatings = new List<ICombatingReference>();
        [SerializeField] IProjectileReference projectile = null;

        public List<ICombatingReference> Combatings { get => combatings; }
        public IProjectileReference Projectile { get => projectile; set => projectile = value; }

        ICombatAction attackAction;
        ICombatAction defenceAction;
        List<ICombatAction> showActions = new List<ICombatAction>();
        List<ICombatAction> hideActions = new List<ICombatAction>();

        public ICombatAction AttackAction { get => attackAction; set => attackAction = value; }
        public ICombatAction DefenceAction { get => defenceAction; set => defenceAction = value; }
        public List<ICombatAction> ShowActions { get => showActions; }
        public List<ICombatAction> HideActions { get => hideActions; }

        float attackRange = 0f;
        public float AttackRange { get => attackRange; set => attackRange = value; }

        public UnityAction<AttackDamage> onTakeDamage;

        public ClipState.Transition damageAnimation;
        public AnimancerLayer damageLayer;

        protected virtual void Awake()
        {
            baseController = GetComponent<BaseController>();
        }

        void Start()
        {
            damageLayer = baseController.Animatrix.GetLayer(Animatrix.LayerName.TorsoAdditive);
            animatrix = baseController.Animatrix;
            characterStats = baseController.CharacterStats;
            equipment = baseController.Equipment;
        }

        public virtual void AttackBegin()
        {
            if (combatState == State.Action)
                isAttacking = true;
        }

        public virtual void AttackEnd()
        {
            isAttacking = false;
        }

        public virtual void DefenceBegin()
        {
            if (combatState == State.Action)
                isDefending = true;
        }

        public virtual void DefenceEnd()
        {
            isDefending = false;
        }

        public void ClearActions()
        {
            attackAction?.Interrupt();
            attackAction = null;
            
            defenceAction?.Interrupt();
            defenceAction = null;

            showActions.ForEach(action => action.Interrupt());
            showActions.Clear();
            
            hideActions.ForEach(action => action.Interrupt());
            hideActions.Clear();
            
            attackRange = 0f;
        }

        public virtual void AimBegin()
        {
        }

        public virtual void AimEnd()
        {
        }

        public virtual void TakeDamage(AttackDamage attackDamage)
        {
            if (characterStats == null)
                return;

            onTakeDamage?.Invoke(attackDamage);

            if (!attackDamage.IsReduced)
            {
                AnimancerState state = damageLayer.Play(damageAnimation);
                state.Weight = 1f;
                state.Time = 0f;
                state.StartFade(0f, 0.5f);
            }

            if (attackDamage.DamageType == AttackDamageType.Physic)
                attackDamage.Damage -= characterStats.GetPhysicArmor();
            else
                attackDamage.Damage -= characterStats.GetMagicArmor();

            characterStats.GetStat(StatType.Damage).AddEffect(new StatEffect(attackDamage.Damage, 0f));
        }

        public void AddCombating(ICombating combating)
        {
            combatings.Add(new ICombatingReference(combating));
        }

        public void RemoveCombating(ICombating combating)
        {
            combatings.RemoveAll(c => c.Object.Equals(combating));
        }
    }
}



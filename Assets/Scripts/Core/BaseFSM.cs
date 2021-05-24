using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPG.Core
{
    public abstract class BaseFSM<StateType> : MonoBehaviour where StateType : BaseFSMState
    {
        [SerializeField] StateType currentState;

        Dictionary<Type, StateType> states = new Dictionary<Type, StateType>();
        Queue<Type> transitions = new Queue<Type>();

        void Awake()
        {
            StateType[] states = GetComponentsInChildren<StateType>();
            foreach (StateType state in states)
                this.states.Add(state.GetType(), state);
        }

        void Start()
        {
            currentState.OnEnter();
        }

        public void MakeTransition<T>() where T : StateType
        {
            transitions.Enqueue(typeof(T));
        }

        protected void UpdateStates(float dt)
        {
            while (transitions.Count > 0)
            {
                StateType state;
                states.TryGetValue(transitions.Dequeue(), out state);

                if (state == currentState)
                    continue;

                if (state != null)
                {
                    currentState.OnExit();
                    currentState = state;
                    currentState.OnEnter();
                }

                break;
            }

            transitions.Clear();
            
            currentState.OnUpdate(dt);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class ControllerCapataz : MonoBehaviour
    {
        public State currentState; // apuntador al estado actual
        public State remainState;  // el estado en el que te quedas si no pasas a la siguiente

        private Animator _animatorController;

        public bool ActiveAI { get; set; }

        private void Awake()
        {
            _animatorController = GetComponent<Animator>();
        }

        public void Start()
        {
            ActiveAI = true; // Para activar la IA
        }

        public void Update() // Se ejecutan las acciones del estado actual.
        {
            if (!ActiveAI)                   // El parámetro permite que los 
                return;                      // estados tengan una referencia al
            //currentState.UpdateState(this);  // controlador, para poder llamar a
                                             // sus métodos
        }

        /*public bool GetTalk()
        {
            return;
        }*/

        public void SetAnimation(string animation, bool value)
        {
            _animatorController.SetBool(animation, value);
        }

        public void Transition(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
            }
        }
    }
}
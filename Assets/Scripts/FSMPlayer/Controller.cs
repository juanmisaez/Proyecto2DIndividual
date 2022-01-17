using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class Controller : MonoBehaviour
    {
        public State currentState; // apuntador al estado actual
        public State remainState;  // el estado en el que te quedas si no pasas a la siguiente

        private Animator _animatorController;
        private OxygenSystem _oxygenSystem;
        private InputSystemKeyboard _inputSystemKeyboard;
        private Rigidbody2D _rigidbody2D; //---
        private Rigidbody2D _rigidbody2DPlayerMovePoint;        
        [SerializeField]
        private Transform _playerMovePoint;        

        public bool ActiveAI { get; set; }

        private void Awake()
        {
            _animatorController = GetComponent<Animator>();
            _oxygenSystem = GetComponent<OxygenSystem>();
            _inputSystemKeyboard = GetComponent<InputSystemKeyboard>();
            _rigidbody2D = GetComponent<Rigidbody2D>(); //---
            _rigidbody2DPlayerMovePoint = _playerMovePoint.GetComponent<Rigidbody2D>();
        }

        public void Start()
        {
            ActiveAI = true; // Para activar la IA
        }

        public void Update() // Se ejecutan las acciones del estado actual.
        {
            if (!ActiveAI)                   // El parámetro permite que los 
                return;                      // estados tengan una referencia al
            currentState.UpdateState(this);  // controlador, para poder llamar a
                                             // sus métodos
        }

        public int GetCurrentOxygen()
        {
            return _oxygenSystem.GetOxygen();
        }

        public float GetMoveX()
        {
            return _inputSystemKeyboard.hor;            
        }

        public bool GetFall()
        {
            return _rigidbody2DPlayerMovePoint.velocity.y < -0.2f; // Con la 'velocity' del "point" es más preciso que con el 'grounded' del "player"
        }

        public bool GetDig()
        {
            return _inputSystemKeyboard.space;
        }

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
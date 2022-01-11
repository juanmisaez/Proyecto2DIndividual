using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Player/State")]
    public class State : ScriptableObject
    {
        public Action[] actions; // en un state se ejecutan varias acciones

        public Transition[] transitions; // Desde un estado se puede pasar a otros estados a través de las transiciones

        public void UpdateState(Controller controller) // Se ejecutan desde el Controller
        {
            DoActions(controller); // Ejecutamos todas las acciones
            CheckTransitions(controller); // Comprobamos las transiciones
        }

        private void DoActions(Controller controller) // Ejecuta las acciones
        {
            for(int i = 0; i < actions.Length; i++)
            {
                actions[i].Act(controller); // Llamada al método abstracto
            }
        }

        private void CheckTransitions(Controller controller)
        {
            for(int i = 0; i < transitions.Length; i++)
            {
                bool decision = transitions[i].decision.Decide(controller);

                if(decision)
                {
                    controller.Transition(transitions[i].trueState);
                    return;
                }
                else
                {
                    controller.Transition(transitions[i].falseState);
                }
            }
        }
    }
}
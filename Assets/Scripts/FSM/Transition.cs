using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FSM
{
    [System.Serializable] //se necesita que se vea en el editor
    public class Transition
    {
        public Decision decision;
        public State trueState;
        public State falseState;
    }
}
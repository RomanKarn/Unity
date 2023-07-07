using System;
using UnityEngine;

namespace State
{
    public class StateMashin : MonoBehaviour
    {
        public event Action svitchStateFlay;
        public event Action svitchStateMove;
        public event Action svitchStateDaed;
        public string stateNow { get; private set; }
        void Start()
        {
            StartDefaltState();
        }

        private void StartDefaltState()
        {
            svitchStateMove?.Invoke();
            stateNow = "PlaerMove";
        }
        public void StateMove()
        {
            if (stateNow == "PlaerDead")
                return;
            svitchStateMove?.Invoke();
            stateNow = "PlaerMove";
        }
        public void StateFlay()
        {
            if (stateNow == "PlaerDead")
                return;
            svitchStateFlay?.Invoke();
            stateNow = "PlaerFlay";
        }
        public void StateDead()
        {
            svitchStateDaed?.Invoke();
            stateNow = "PlaerDead";
        }
    }
}
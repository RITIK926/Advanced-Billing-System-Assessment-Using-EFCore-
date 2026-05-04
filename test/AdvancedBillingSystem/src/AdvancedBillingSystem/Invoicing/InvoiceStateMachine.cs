using System;
using System.Collections.Generic;

namespace AdvancedBillingSystem.Invoicing
{
    public class InvoiceStateMachine
    {
        private readonly Dictionary<string, Action> _transitions;
        public string CurrentState { get; private set; }

        public InvoiceStateMachine()
        {
            CurrentState = "Draft"; // Initial state
            _transitions = new Dictionary<string, Action>
            {
                { "Draft", ProcessDraft },
                { "Sent", ProcessSent },
                { "Paid", ProcessPaid },
                { "Cancelled", ProcessCancelled }
            };
        }

        public void TransitionTo(string newState)
        {
            if (_transitions.ContainsKey(newState))
            {
                _transitions[newState].Invoke();
                CurrentState = newState;
            }
            else
            {
                throw new InvalidOperationException($"Invalid state transition to {newState}");
            }
        }

        private void ProcessDraft()
        {
            // Logic for processing draft state
        }

        private void ProcessSent()
        {
            // Logic for processing sent state
        }

        private void ProcessPaid()
        {
            // Logic for processing paid state
        }

        private void ProcessCancelled()
        {
            // Logic for processing cancelled state
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace OPG.Input
{
    /// <summary>
    /// Base class for all input contexts.
    /// </summary>
    /// <typeparam name="Actions">The actions that can be performed in this context.</typeparam>
    public abstract class InputContext<Actions> : MonoBehaviour where Actions : Enum
    {
        private Dictionary<Actions, List<Action>> actionCallbacks = new Dictionary<Actions, List<Action>>();

        /// <summary>
        /// Subscribe a method to an action in this context, which will be called when the latter is performed.
        /// </summary>
        /// <param name="action">The action to subscribe to.</param>
        /// <param name="callback">The subscribed method.</param>
        public void SubscribeToAction(Actions action, Action callback)
        {
            if (!actionCallbacks.ContainsKey(action)) actionCallbacks.Add(action, new List<Action>());

            actionCallbacks[action].Add(callback);
        }

        /// <summary>
        /// Perform an action in this context, therefore calling all methods subscribed to it.
        /// </summary>
        /// <param name="action">The action to be performed.</param>
        public void DoAction(Actions action)
        {
            if (!actionCallbacks.ContainsKey(action)) return;

            foreach (Action callback in actionCallbacks[action]) callback?.Invoke();
        }
    }
}
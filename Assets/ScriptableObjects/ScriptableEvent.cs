using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Event", menuName = "ScriptableObjects/New Event", order = 0)]
    public class ScriptableEvent : ScriptableObject
    {
        private Action action;

        public void InvokeAction()
        {
            action?.Invoke();
        }
        
        public void Subscribe(Action action)
        {
            this.action += action;
        }
        
        public void Unsubscribe(Action action)
        {
            this.action -= action;
        }
    }
}
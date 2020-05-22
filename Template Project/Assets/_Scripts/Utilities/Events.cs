﻿using UnityEditor.Events;
using UnityEngine.Events;

namespace Utilities
{
    public static class Events
    {
        /// <summary>
        /// Adds a listener to the provided UnityEvent. The type of listener added changes based on
        /// whether the code is running in the Unity Editor or not. If the code is running in the
        /// Editor, a persistent listener will be added to the event (for in-editor debugging).
        /// Otherwise, a standard listener will be added.
        /// </summary>
        /// <param name="eventToUse">The event to add the listener to.</param>
        /// <param name="actions">The function(s) to add as a listener to the event.</param>
        public static void AddListener(UnityEvent eventToUse, params UnityAction[] actions)
        {
            foreach (UnityAction actionToUse in actions)
            { 
                #if UNITY_EDITOR
                    UnityEventTools.AddPersistentListener(eventToUse, actionToUse);
                #else
                    eventToUse.AddListener(actionToUse);
                #endif
            }
        }

        /// <summary>
        /// Adds a listener of a specified Type to the provided UnityEvent. The Type is needed for functions
        /// that are attempting to pass a parameter of the given Type. The type of listener added changes
        /// based on  whether the code is running in the Unity Editor or not. If the code is running in the
        /// Editor, a persistent listener will be added to the event (for in-editor debugging).
        /// Otherwise, a standard listener will be added.
        /// </summary>
        /// <param name="eventToUse">The event to add the listener to.</param>
        /// <param name="actions">The function(s) to add as a listener to the event.</param>
        public static void AddListener<Type>(UnityEvent<Type> eventToUse, params UnityAction<Type>[] actions)
        {
            foreach (UnityAction<Type> actionToUse in actions)
            {
                #if UNITY_EDITOR
                    UnityEventTools.AddPersistentListener<Type>(eventToUse, actionToUse);
                #else
                    eventToUse.AddListener(actionToUse);
                #endif
            }
        }

        /// <summary>
        /// Removes a listener from the provided UnityEvent. The type of listener removed changes based on
        /// whether the code is running in the Unity Editor or not.
        /// </summary>
        /// <param name="eventToUse">The event to add the listener to.</param>
        /// <param name="actions">The function(s) to add as a listener to the event.</param>
        public static void RemoveListener(UnityEvent eventToUse, params UnityAction[] actions)
        {
            foreach (UnityAction actionToUse in actions)
            {
                #if UNITY_EDITOR
                    UnityEventTools.RemovePersistentListener(eventToUse, actionToUse);
                #else
                    eventToUse.RemoveListener(actionToUse);
                #endif
            }
        }

        /// <summary>
        /// Removes a listener of the specified Type from the provided UnityEvent. The Type is needed for functions
        /// that are attempting to pass a parameter of the given Type. The type of listener removed changes based on
        /// whether the code is running in the Unity Editor or not.
        /// </summary>
        /// <param name="eventToUse">The event to add the listener to.</param>
        /// <param name="actions">The function(s) to add as a listener to the event.</param>
        public static void RemoveListener<Type>(UnityEvent<Type> eventToUse, params UnityAction<Type>[] actions)
        {
            foreach (UnityAction<Type> actionToUse in actions)
            {
                #if UNITY_EDITOR
                    UnityEventTools.RemovePersistentListener(eventToUse, actionToUse);
                #else
                    eventToUse.RemoveListener(actionToUse);
                #endif
            }
        }
    }
}
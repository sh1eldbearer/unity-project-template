using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// Applies the singleton pattern to a script, and sets the GameObject that script resides on
    /// as a persistent object (DontDestroyOnLoad) if it is not childed to any other GameObject.
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    public static class Singleton<Type>
    {
        /// <summary>
        /// Attempts to create a singleton instance of the class of the given Type.
        ///
        /// Will also attempt to flag the provided GameObject as DontDestroyOnLoad, if the
        /// GameObject is not a child of any other GameObject.
        ///
        /// If the class of the provided Type already has a defined static instance, the GameObject
        /// (and the script stored on it) will be considered redundant, and destroyed.
        /// </summary>
        /// <typeparam name="Type">The class you are attempting to set a singleton instance of.</typeparam>
        /// <param name="script">The script object invoking the singleton attempt.</param>
        /// <param name="instance">The Type class' static instance variable.</param>
        /// <param name="gameObject">The GameObject on which the calling script resides.</param>
        public static void SetAsStaticInstance<Type>(Type script, ref Type instance, GameObject gameObject)
        {
            // Checks to see if this class already has a defined static instance
            if (instance == null)
            {
                // Assign the script as the static instance
                instance = script;

                // Checks to see if the GameObject is a child
                if (gameObject.transform.parent == null)
                {
                    // If this GameObject is not a child, set it as a persistent object
                    MonoBehaviour.DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                // The class already has a defined static instance, so destroy the GameObject (and the script)
                MonoBehaviour.Destroy(gameObject);
            }
        }

        /// <summary>
        /// Attempts to create a singleton instance of the class of the given Type.
        ///
        /// If the class of the provided Type already has a defined static instance, the script will be
        /// considered redundant, and destroyed.
        /// </summary>
        /// <typeparam name="Type">The class you are attempting to set a singleton instance of.</typeparam>
        /// <param name="script">The script object invoking the singleton attempt.</param>
        /// <param name="instance">The Type class' static instance variable.</param>
        public static void SetAsStaticInstance<Type>(Type script, ref Type instance)
        {
            // Checks to see if this class already has a defined static instance
            if (instance == null)
            {
                // Assign the script as the static instance
                instance = script;
            }
            else
            {
                // The class already has a defined static instance, so destroy the script
                MonoBehaviour.Destroy(script as Object);
            }
        }
    }
}

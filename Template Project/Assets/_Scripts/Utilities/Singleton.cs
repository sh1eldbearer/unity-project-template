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
        /// If the class of the provided Type already has a defined static instance, the script will be
        /// considered redundant, and destroyed.
        /// </summary>
        /// <typeparam name="Type">The class you are attempting to set a singleton instance of.</typeparam>
        /// <param name="script">The script object invoking the singleton attempt.</param>
        /// <param name="instance">The Type class' static instance variable.</param>
        public static void SetAsStaticInstance(Type script, ref Type instance)
        {
            SetAsStaticInstance(script, ref instance, null, false);
        }

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
        /// </param>
        public static void SetAsStaticInstance(Type script, ref Type instance, GameObject gameObject)
        {
            SetAsStaticInstance(script, ref instance, gameObject, false);
        }

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
        /// <param name="destroyOtherInstance">Denotes whether or not an already-existing static instance of
        /// a class should be deleted and replaced by a new instance of the class.</param>
        public static void SetAsStaticInstance(Type script, ref Type instance, GameObject gameObject, 
            bool destroyOtherInstance)
        {
            if (destroyOtherInstance && instance != null)
            {
                MonoBehaviour.Destroy((instance as MonoBehaviour).gameObject);
            }

            // Checks to see if this class already has a defined static instance
            if (instance == null)
            {
                // Assign the script as the static instance
                instance = script;

                // Checks to see if the GameObject is a child
                if (gameObject != null && gameObject.transform.parent == null)
                {
                    // If this GameObject is not a child, set it as a persistent object
                    MonoBehaviour.DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                if (gameObject == null)
                {
                    // The class already has a defined static instance, so destroy the script
                    MonoBehaviour.Destroy(script as Object);
                }
                else
                {

                    // The class already has a defined static instance, so destroy the GameObject (and the script)
                    MonoBehaviour.Destroy(gameObject);
                }
            }
        }
    }
}

#if UNITY_EDITOR
// This script is only used in the UnityEditor, so the directive tells the compiler to ignore it.
    using DataClasses;
    using UnityEditor;
    using UnityEngine;

    public class CreateAudioSourceObject : MonoBehaviour
    {
        [MenuItem("GameObject/Audio/Custom Audio Source Object", false, 10)]
        static void CreateAudioSourceGameObject(MenuCommand menuCommand)
        {
            // Create a new GameObject
            GameObject newGameObject = new GameObject("New Audio Source Object", typeof(AudioSourceInfo));
            // Ensure it gets re-parented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(newGameObject, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(newGameObject, "Create " + newGameObject.name);
            // Select the new GameObject in the hierarchy
            Selection.activeObject = newGameObject;
        }
    }
#endif
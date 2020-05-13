using UnityEngine;
using UnityEditor;

namespace Utilities
{
    public class QuitGame : MonoBehaviour
    {
        /// <summary>
        /// Quits the game.
        /// </summary>
        public void Quit()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
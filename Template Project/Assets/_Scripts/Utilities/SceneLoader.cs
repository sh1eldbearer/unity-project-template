using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class SceneLoader : MonoBehaviour
    {
        #region Private Properties
#pragma warning disable CS0649
        private static SceneLoader _instance; // Static singleton instance of the SceneLoader class
        private static UIFader _uiFader; // Static reference to a UIFader object that exists in an active scene

        [Tooltip("The build index of the game's loading screen."),
            SerializeField] private int _loadingScreenSceneIndex;
#pragma warning restore CS0649
        #endregion

        #region Public Properties
        /// <summary>
        /// Static singleton instance of the SceneLoader class.
        /// </summary>
        public static SceneLoader Instance
        {
            get { return _instance; }
        }
        #endregion

        // Awake is called before Start
        private void Awake()
        {
            // Attempts to set this script as the static instance for this class
            Singleton<SceneLoader>.SetAsStaticInstance(this, ref _instance, this.gameObject);
        }

        /// <summary>
        /// Loads a scene using the provided build index value.
        /// </summary>
        /// <param name="targetScene">The build index of the scene to be loaded.</param>
        public void LoadScene(int targetScene)
        {
            StartCoroutine(LoadSceneWithLoadingScreen(SceneManager.GetActiveScene().buildIndex, targetScene,
                _loadingScreenSceneIndex));
        }

        /// <summary>
        /// Loads a scene using the provided scene name.
        /// </summary>
        /// <param name="targetScene">The scene name of the scene to be loaded.</param>
        public void LoadScene(string targetScene)
        {
            StartCoroutine(LoadSceneWithLoadingScreen(SceneManager.GetActiveScene().buildIndex,
                SceneManager.GetSceneByName(targetScene).buildIndex,
                _loadingScreenSceneIndex));
        }

        /// <summary>
        /// Registers a UIFader script with the SceneLoader for use during scene transitions.
        /// </summary>
        /// <param name="uiFader">The UIFader object to register with the SceneLoader.</param>
        public void RegisterUIFader(UIFader uiFader)
        {
            _uiFader = uiFader;
        }

        /// <summary>
        /// Additively loads a scene asynchronously from within a coroutine.
        /// </summary>
        /// <param name="sceneToLoad">The build index of the scene to be loaded.</param>
        /// <returns>Coroutine.</returns>
        private IEnumerator LoadSceneAsync(int sceneToLoad)
        {
            AsyncOperation sceneLoaded = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

            while (!sceneLoaded.isDone)
            {
                yield return null;
            }
        }

        /// <summary>
        /// Performs all necessary operations to transition between two scenes, while displaying the loading
        /// screen between scenes.
        /// </summary>
        /// <param name="originScene">The scene the game is currently in, and that will be unloaded.</param>
        /// <param name="targetScene">The scene the game will load.</param>
        /// <param name="transitionScene">The scene that will be loaded additively between the origin and
        /// target scenes.</param>
        /// <returns>Coroutine.</returns>
        private IEnumerator LoadSceneWithLoadingScreen(int originScene, int targetScene, int transitionScene)
        {
            // Loads the loading screen scene additively, and waits for the loading screen UI to finish
            // fading in before proceeding
            yield return LoadSceneAsync(transitionScene);

            // If there is an active UIFader, fade its canvas group in
            if (_uiFader != null)
            {
                yield return StartCoroutine(_uiFader.FadeIn());
            }

            // Unloads the previous scene
            SceneManager.UnloadSceneAsync(originScene);

            // Loads the new scene additively, and waits for the scene to finish loading before proceeding
            yield return LoadSceneAsync(targetScene);

            // Waits a single frame, then sets the new scene as the active scene to make its lighting the dominant scene lighting
            yield return 0;
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(targetScene));

            // If there is an active UIFader, fade its canvas group out
            if (_uiFader != null)
            {
                yield return StartCoroutine(_uiFader.FadeOut());
            }

            // Unloads the loading screen scene
            SceneManager.UnloadSceneAsync(transitionScene);
            yield return null;
        }
    }
}

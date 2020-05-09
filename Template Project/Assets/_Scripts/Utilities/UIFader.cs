using System.Collections;
using Managers;
using UnityEngine;

namespace Utilities
{
    public class UIFader : MonoBehaviour
    { 
        #region Private Properties

#pragma warning disable CS0649
        [Tooltip("The Canvas Group component for the loading screen UI elements."),
            SerializeField] private CanvasGroup _canvasGroup;

        [Tooltip("The camera used only in the loading screen. (Used to enable this camera just before " +
                 "unloading the previous scene."),
            SerializeField] private Camera _loadingScreenCam;
#pragma warning restore CS0649

        #endregion

        // Awake is called before Start
        private void Awake()
        {
            // Register this UIFader component with the SceneLoader
            SceneLoader.Instance.RegisterUIFader(this);

            // Component reference assignments
            if (_canvasGroup == null)
            {
                _canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
            }
        }

        /// <summary>
        /// Increases the alpha the UI elements of the loading screen until they obscure the view of the
        /// canvas.
        /// </summary>
        /// <returns>Coroutine.</returns>
        public IEnumerator FadeIn()
        {
            float timer = 0f;

            // Fades the UI's alphas from 0 up to 100 (fully invisible to fully opaque)
            while (timer <= GameManager.Instance.SceneTransitionFadeTime)
            {
                _canvasGroup.alpha = timer / GameManager.Instance.SceneTransitionFadeTime;
                timer += Time.unscaledDeltaTime;
                yield return null;
            }

            // Enables the camera on the loading screen
            _loadingScreenCam.enabled = true;
        }

        /// <summary>
        /// Decreases the alpha the UI elements of the loading screen until they are hidden from view in
        /// the canvas.
        /// </summary>
        /// <returns>Coroutine.</returns>
        public IEnumerator FadeOut()
        {
            float timer = GameManager.Instance.SceneTransitionFadeTime;

            // Fades the UI's alphas from 100 down to 0 (fully opaque to fully invisible)
            while (timer >= 0f)
            {
                _canvasGroup.alpha = timer / GameManager.Instance.SceneTransitionFadeTime;
                timer -= Time.unscaledDeltaTime;
                yield return null;
            }
        }
    }
}
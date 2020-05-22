using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Managers
{
    public class PauseManager : MonoBehaviour
    {
        #region Private Properties

#pragma warning disable CS0649
        private static PauseManager _instance; // Static singleton instance of the PauseManager class

        [SerializeField] private UnityEvent _gamePaused = new UnityEvent();
        [SerializeField] private UnityEvent _gameUnpaused = new UnityEvent();
#pragma warning restore CS0649

        #endregion

        #region Public Properties

        /// <summary>
        /// Static singleton instance of the PauseManager class.
        /// </summary>
        public static PauseManager Instance
        {
            get { return _instance; }
        }

        #endregion

        // Awake is called before Start
        private void Awake()
        {
            // Attempts to set this script as the static instance for this class
            Singleton<PauseManager>.SetAsStaticInstance(this, ref _instance, this.gameObject);
        }

        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }

        /// <summary>
        /// Adds one or more listeners to the OnPause event.
        /// </summary>
        /// <param name="calls">The names of the functions to call when OnPause is invoked.</param>
        public void AddOnGamePauseListener(params UnityAction[] calls)
        {
            foreach (UnityAction call in calls)
            {
                Events.AddListener(_gamePaused, calls);
            }
        }

        /// <summary>
        /// Removes one or more listeners from the OnPause event.
        /// </summary>
        /// <param name="calls">The names of the functions to remove from the OnPause invoke array.</param>
        public void RemoveOnGamePauseListener(params UnityAction[] calls)
        {
            foreach (UnityAction call in calls)
            {
                Events.RemoveListener(_gamePaused, calls);
            }
        }

        /// <summary>
        /// Adds one or more listeners to the OnUnpause event.
        /// </summary>
        /// <param name="calls">The names of the functions to call when OnUnpause is invoked.</param>
        public void AddOnGameUnpauseListener(params UnityAction[] calls)
        {
            foreach (UnityAction call in calls)
            {
                Events.AddListener(_gameUnpaused, calls);
            }
        }

        /// <summary>
        /// Removes one or more listeners from the OnUnpause event.
        /// </summary>
        /// <param name="calls">The names of the functions to remove from the OnUnpause invoke array.</param>
        public void RemoveOnGameUnpauseListener(params UnityAction[] calls)
        {
            foreach (UnityAction call in calls)
            {
                Events.RemoveListener(_gameUnpaused, calls);
            }
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public void PauseGame()
        {
            Time.timeScale = 0;
            _gamePaused.Invoke();
        }

        /// <summary>
        /// Unpauses the game.
        /// </summary>
        public void UnpauseGame()
        {
            Time.timeScale = 1;
            _gameUnpaused.Invoke();
        }
    }
}

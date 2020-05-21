using UnityEngine;
using Utilities;
using PlayerPrefs = Utilities.PlayerPrefs;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Private Properties

#pragma warning disable CS0649
        private static GameManager _instance; // Static singleton instance of the GameManager class

        [Header("UI Settings")]
        [Tooltip("The length of time (in seconds) it will take a for the UI of a loading screen to change its alpha" +
                 "from fully transparent to fully opaque (or vice versa)."),
            SerializeField, Range(0.1f, 2f)] private float _sceneTransitionFadeTime;

        [Header("PlayerPrefs Key Names")] 
        [SerializeField] private Utilities.PlayerPrefs _playerPrefs;
#pragma warning restore CS0649

        #endregion

        #region Public Properties
        /// <summary>
        /// Static singleton instance of the GameManager class.
        /// </summary>
        public static GameManager Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// The length of time (in seconds) it will take a for the UI of a loading screen to change its alpha from
        /// fully transparent to fully opaque (or vice versa).
        /// </summary>
        public float SceneTransitionFadeTime
        {
            get { return _sceneTransitionFadeTime; }
        }

        /// <summary>
        /// This game's PlayerPrefs utility object.
        /// </summary>
        public PlayerPrefs PlayerPrefs
        {
            get { return _playerPrefs; }
        }

        #endregion

        // Awake is called before Start
        private void Awake()
        {
            // Attempts to set this script as the static instance for this class
            Singleton<GameManager>.SetAsStaticInstance(this, ref _instance, this.gameObject);
        }

        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}
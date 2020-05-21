using DataClasses;
using UnityEngine;

namespace Utilities
{
    [System.Serializable]
    public class PlayerPrefs 
    {
        #region Private Properties
#pragma warning disable CS0649
        [Header("Volume Key Names")]
        [Tooltip("Information about the master volume PlayerPrefs setting."),
            SerializeField] private PlayerPrefsItemFloat _masterVolume;
        [Tooltip("Information about the music volume PlayerPrefs setting."),
            SerializeField] private PlayerPrefsItemFloat _musicVolume;
        [Tooltip("Information about the sound effect volume PlayerPrefs setting."),
            SerializeField] private PlayerPrefsItemFloat _sfxVolume;
        [Tooltip("Information about the ambient sound volume PlayerPrefs setting."),
            SerializeField] private PlayerPrefsItemFloat _ambianceVolume;
        [Tooltip("Information about the voice volume PlayerPrefs setting."),
            SerializeField] private PlayerPrefsItemFloat _voiceVolume;
#pragma warning restore CS0649

        #endregion

        #region Public Properties

        /// <summary>
        /// Information about the master volume PlayerPrefs setting.
        /// </summary>
        public PlayerPrefsItemFloat MasterVolume
        {
            get { return _masterVolume; }
        }

        /// <summary>
        /// Information about the music volume PlayerPrefs setting.
        /// </summary>
        public PlayerPrefsItemFloat MusicVolume
        {
            get { return _musicVolume; }
        }

        /// <summary>
        /// Information about the sound effect volume PlayerPrefs setting.
        /// </summary>
        public PlayerPrefsItemFloat SfxVolume
        {
            get { return _sfxVolume; }
        }

        /// <summary>
        /// Information about the ambient sound volume PlayerPrefs setting.
        /// </summary>
        public PlayerPrefsItemFloat AmbianceVolume
        {
            get { return _ambianceVolume; }
        }

        /// <summary>
        /// Information about the voice volume PlayerPrefs setting.
        /// </summary>
        public PlayerPrefsItemFloat VoiceVolume
        {
            get { return _voiceVolume; }
        }
        #endregion
    }
}

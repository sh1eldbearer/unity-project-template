using System;
using Enums;
using Managers;
using UnityEngine;

namespace DataClasses
{
    [RequireComponent(typeof(AudioSource))]
    [DisallowMultipleComponent]
    public class AudioSourceInfo : MonoBehaviour
    {
        #region Private Properties

#pragma warning disable CS0649
        [Tooltip("The type of audio clip this is."), 
            SerializeField] private AudioSourceType _sourceType = AudioSourceType.None;

        [Tooltip("The name of this audio source. (Must be a unique name.)"),
            SerializeField] private string _sourceName;

        [Tooltip("The audio source containing the clip to be used."),
            SerializeField] private AudioSource _clipSource;
#pragma warning restore CS0649

        #endregion

        // Awake is called before Start
        private void Awake()
        {
            // Assigns the source a name if the user forgot to provide one
            if (_sourceName == string.Empty)
            {
                _sourceName = this.gameObject.name;
            }

            // Assigns the source clip if the user forgets to assign it
            if (_clipSource == null)
            {
                _clipSource = this.gameObject.GetComponent<AudioSource>();

                if (_clipSource.clip == null)
                {
                    throw new NullReferenceException($"{_clipSource.name} does not have an audio clip assigned to it!");
                }
            }
        }

        // Start is called before the first frame update
        private void Start()
        {
            // Registers the audio source with the audio manager
            AudioManager.Instance.RegisterAudioSource(_clipSource, _sourceName, _sourceType, ChangeVolume);
            // Adjusts the volume levels of the audio source to the game's current volume settings
            ChangeVolume();
        }

        /// <summary>
        /// Changes the volume of this audio source.
        /// </summary>
        /// <param name="value">Optional parameter for AudioManager event complicity. Can be omitted;
        /// value is ignored.</param>
        private void ChangeVolume(float value = -1)
        {
            switch (_sourceType)
            {
                case AudioSourceType.Music:
                    _clipSource.volume = AudioManager.Instance.MasterVolume * AudioManager.Instance.MusicVolume;
                    break;
                case AudioSourceType.SFX:
                    _clipSource.volume = AudioManager.Instance.MasterVolume * AudioManager.Instance.SfxVolume;
                    break;
                case AudioSourceType.Ambiance:
                    _clipSource.volume = AudioManager.Instance.MasterVolume * AudioManager.Instance.AmbianceVolume;
                    break;
                case AudioSourceType.Voice:
                    _clipSource.volume = AudioManager.Instance.MasterVolume * AudioManager.Instance.VoiceVolume;
                    break;
            }
        }
    }
}
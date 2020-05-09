using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Managers
{
    [RequireComponent(typeof(AudioListener))]
    public class AudioManager : MonoBehaviour
    {
        
        #region Private Properties

#pragma warning disable CS0649
        private static AudioManager _instance; // Static singleton instance of the AudioManager class

        [Header("Volume Settings")]
        [Tooltip("The overall volume level for the game. All other volumes will be multiplied by this " +
                 "value to determine the volume level they will play at."), 
            SerializeField, Range(0f, 1f)] private float _masterVolume = 1f;
        [Tooltip("The volume level for audio sources designated as music. This value will be multiplied " +
                 "by the master volume level to determine the volume level it will play at."),
            SerializeField, Range(0f, 1f)] private float _musicVolume = 0.35f;
        [Tooltip("The volume level for audio sources designated as sound effects. This value will be " +
                 "multiplied by the master volume level to determine the volume level it will play at."),
            SerializeField, Range(0f, 1f)] private float _sfxVolume = 0.75f;
        [Tooltip("The volume level for audio sources designated as ambient noise. This value will be " +
                 "multiplied by the master volume level to determine the volume level it will play at."),
            SerializeField, Range(0f, 1f)] private float _ambianceVolume = 0.5f;
        [Tooltip("The volume level for audio sources designated as voice clips. This value will be " +
                 "multiplied by the master volume level to determine the volume level it will play at."),
            SerializeField, Range(0f, 1f)] private float _voiceVolume = 0.75f;

        [Header("Audio Source Dictionaries")]
        // The dictionary of audio sources designated as music. Allows audio sources to be looked up by name.
        private Dictionary<string, AudioSource> _musicSources = new Dictionary<string, AudioSource>();
        // The dictionary of audio sources designated as sound effects. Allows sources to be looked up by name.
        private Dictionary<string, AudioSource> _sfxSources = new Dictionary<string, AudioSource>();
        // The dictionary of audio sources designated as ambient sounds. Allows sources to be looked up by name.
        private Dictionary<string, AudioSource> _ambianceSources = new Dictionary<string, AudioSource>();
        // The dictionary of audio sources designated as voice clips. Allows sources to be looked up by name.
        private Dictionary<string, AudioSource> _voiceSources = new Dictionary<string, AudioSource>();

        [Header("Volume Changed Events")] [SerializeField]
        private UnityEvent _masterVolumeChanged;
        [SerializeField] private UnityEvent _musicVolumeChanged;
        [SerializeField] private UnityEvent _sfxVolumeChanged;
        [SerializeField] private UnityEvent _ambianceVolumeChanged;
        [SerializeField] private UnityEvent _voiceVolumeChanged;
#pragma warning restore CS0649

        #endregion

        #region Public Properties

        /// <summary>
        /// Static singleton instance of the AudioManager class.
        /// </summary>
        public static AudioManager Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// The overall volume level for the game. All other volumes will be multiplied by this
        /// value to determine the volume level they will play at.
        /// </summary>
        public float MasterVolume
        {
            get { return _masterVolume; }
        }

        /// <summary>
        /// The volume level for audio sources designated as music. This value will be multiplied
        /// by the master volume level to determine the volume level it will play at.
        /// </summary>
        public float MusicVolume
        {
            get { return _musicVolume; }
        }

        /// <summary>
        /// The volume level for audio sources designated as sound effects. This value will be
        /// multiplied by the master volume level to determine the volume level it will play at.
        /// </summary>
        public float SfxVolume
        {
            get { return _sfxVolume; }
        }

        /// <summary>
        /// The volume level for audio sources designated as ambient noise. This value will be
        /// multiplied by the master volume level to determine the volume level it will play at.
        /// </summary>
        public float AmbianceVolume
        {
            get { return _ambianceVolume; }
        }

        /// <summary>
        /// The volume level for audio sources designated as voice clips. This value will be
        /// multiplied by the master volume level to determine the volume level it will play at.
        /// </summary>
        public float VoiceVolume
        {
            get { return _voiceVolume; }
        }

        #endregion

        // Awake is called before Start
        private void Awake()
        {
            // Attempts to set this script as the static instance for this class
            Singleton<AudioManager>.SetAsStaticInstance(this, ref _instance, this.gameObject);

            // Registers events that cause audio sources of each type to adjust their clip volumes when the
            // master volume level is changed.
            Events.AddListener(_masterVolumeChanged, InvokeMusicVolumeChanged, InvokeSFXVolumeChanged,
                InvokeAmbianceVolumeChanged, InvokeVoiceVolumeChanged);
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
        /// Invokes the _musicVolumeChanged UnityEvent.
        /// </summary>
        private void InvokeMusicVolumeChanged()
        {
            _musicVolumeChanged.Invoke();
        }

        /// <summary>
        /// Invokes the _sfxVolumeChanged UnityEvent.
        /// </summary>
        private void InvokeSFXVolumeChanged()
        {
            _sfxVolumeChanged.Invoke();
        }

        /// <summary>
        /// Invokes the _ambianceVolumeChanged UnityEvent.
        /// </summary>
        private void InvokeAmbianceVolumeChanged()
        {
            _ambianceVolumeChanged.Invoke();
        }

        /// <summary>
        /// Invokes the _voiceVolumeChanged UnityEvent.
        /// </summary>
        private void InvokeVoiceVolumeChanged()
        {
            _voiceVolumeChanged.Invoke();
        }

        /// <summary>
        /// Registers an AudioSource with the AudioManager, adding an entry
        /// </summary>
        /// <param name="audioSource">The AudioSource being registered with the AudioManager.</param>
        /// <param name="sourceName">The name being used by the AudioSource.</param>
        /// <param name="sourceType">The type of AudioSource being registered.</param>
        /// <param name="changeVolumeFunction">The ChangeVolume function in the AudioSourceInfo </param>
        public void RegisterAudioSource(AudioSource audioSource, string sourceName, AudioSourceType sourceType,
            UnityAction changeVolumeFunction)
        {
            // Registers the AudioSource with the appropriate dictionary
            switch (sourceType)
            {
                case Enums.AudioSourceType.None:
                    throw new ArgumentNullException($"AudioSource {sourceName} does not have a type assigned " +
                                                    $"and was not registered!");
                case AudioSourceType.Music:
                    _musicSources.Add(sourceName, audioSource);
                    Events.AddListener(_musicVolumeChanged, changeVolumeFunction);
                    break;
                case AudioSourceType.SFX:
                    _sfxSources.Add(sourceName, audioSource);
                    Events.AddListener(_sfxVolumeChanged, changeVolumeFunction);
                    break;
                case AudioSourceType.Ambiance:
                    _ambianceSources.Add(sourceName, audioSource);
                    Events.AddListener(_ambianceVolumeChanged, changeVolumeFunction);
                    break;
                case AudioSourceType.Voice:
                    _voiceSources.Add(sourceName, audioSource);
                    Events.AddListener(_voiceVolumeChanged, changeVolumeFunction);
                    break;
            }
        }

        /// <summary>
        /// Attempts to play the music clip by the given name. The clip will be played at the
        /// position of the audio manager.
        ///
        /// Throws an exception if a music clip by the given name could not be found.
        /// </summary>
        /// <param name="clipName">The name of the music clip to be played.</param>
        public void PlayMusic(string clipName)
        {
            PlayMusic(clipName, this.transform.position);
        }

        /// <summary>
        /// Attempts to play the music clip by the given name at the provided position in the game
        /// world.
        ///
        /// Throws an exception if a music clip by the given name could not be found.
        /// </summary>
        /// <param name="clipName">The name of the music clip to be played.</param>
        /// <param name="playPosition">The world position to play the music clip at.</param>
        public void PlayMusic(string clipName, Vector3 playPosition)
        {
            if (_musicSources.ContainsKey(clipName))
            {
                AudioSource.PlayClipAtPoint(_musicSources[clipName].clip, playPosition);
            }
            else
            {
                throw new ArgumentNullException(
                    $"No AudioSource by the name {clipName} was found in the music dictionary.");
            }
        }

        /// <summary>
        /// Attempts to play the sound clip by the given name. The clip will be played at the
        /// position of the audio manager.
        ///
        /// Throws an exception if a sound clip by the given name could not be found.
        /// </summary>
        /// <param name="clipName">The name of the sound clip to be played.</param>
        public void PlaySFX(string clipName)
        {
            PlaySFX(clipName, this.transform.position);
        }

        /// <summary>
        /// Attempts to play the sound clip by the given name at the provided position in the game
        /// world.
        ///
        /// Throws an exception if a sound clip by the given name could not be found.
        /// </summary>
        /// <param name="clipName">The name of the sound clip to be played.</param>
        /// <param name="playPosition">The world position to play the sound clip at.</param>
        public void PlaySFX(string clipName, Vector3 playPosition)
        {
            if (_sfxSources.ContainsKey(clipName))
            {
                AudioSource.PlayClipAtPoint(_musicSources[clipName].clip, playPosition);
            }
            else
            {
                throw new ArgumentNullException(
                    $"No AudioSource by the name {clipName} was found in the sound dictionary.");
            }
        }

        /// <summary>
        /// Attempts to play the ambiance clip by the given name. The clip will be played at the
        /// position of the audio manager.
        ///
        /// Throws an exception if an ambiance clip by the given name could not be found.
        /// </summary>
        /// <param name="clipName">The name of the ambiance clip to be played.</param>
        public void PlayAmbiance(string clipName)
        {
            PlayAmbiance(clipName, this.transform.position);
        }

        /// <summary>
        /// Attempts to play the ambiance clip by the given name at the provided position in the game
        /// world.
        ///
        /// Throws an exception if an ambiance clip by the given name could not be found.
        /// </summary>
        /// <param name="clipName">The name of the ambiance clip to be played.</param>
        /// <param name="playPosition">The world position to play the ambiance clip at.</param>
        public void PlayAmbiance(string clipName, Vector3 playPosition)
        {
            if (_ambianceSources.ContainsKey(clipName))
            {
                AudioSource.PlayClipAtPoint(_musicSources[clipName].clip, playPosition);
            }
            else
            {
                throw new ArgumentNullException(
                    $"No AudioSource by the name {clipName} was found in the ambiance dictionary.");
            }
        }

        /// <summary>
        /// Attempts to play the voice clip by the given name. The clip will be played at the
        /// position of the audio manager.
        ///
        /// Throws an exception if a voice clip by the given name could not be found.
        /// </summary>
        /// <param name="clipName">The name of the voice clip to be played.</param>
        public void PlayVoice(string clipName)
        {
            PlayVoice(clipName, this.transform.position);
        }

        /// <summary>
        /// Attempts to play the voice clip by the given name at the provided position in the game
        /// world.
        ///
        /// Throws an exception if a voice clip by the given name could not be found.
        /// </summary>
        /// <param name="clipName">The name of the voice clip to be played.</param>
        /// <param name="playPosition">The world position to play the voice clip at.</param>
        public void PlayVoice(string clipName, Vector3 playPosition)
        {
            if (_ambianceSources.ContainsKey(clipName))
            {
                AudioSource.PlayClipAtPoint(_musicSources[clipName].clip, playPosition);
            }
            else
            {
                throw new ArgumentNullException(
                    $"No AudioSource by the name {clipName} was found in the voice dictionary.");
            }
        }

        /// <summary>
        /// Changes the master volume level.
        /// </summary>
        /// <param name="changeAmt">The amount to change the volume by.</param>
        public void ChangeMasterVolume(float changeAmt)
        {
            _masterVolume = Mathf.Clamp(_masterVolume + changeAmt, 0f, 1f);
            _masterVolumeChanged.Invoke();
        }

        /// <summary>
        /// Changes the music volume level.
        /// </summary>
        /// <param name="changeAmt">The amount to change the master volume by.</param>
        public void ChangeMusicVolume(float changeAmt)
        {
            _musicVolume = Mathf.Clamp(_musicVolume + changeAmt, 0f, 1f);
            _musicVolumeChanged.Invoke();
        }

        /// <summary>
        /// Changes the sound effects volume level.
        /// </summary>
        /// <param name="changeAmt">The amount to change the sound effects volume by.</param>
        public void ChangeSFXVolume(float changeAmt)
        {
            _sfxVolume = Mathf.Clamp(_sfxVolume + changeAmt, 0f, 1f);
            _sfxVolumeChanged.Invoke();
        }

        /// <summary>
        /// Changes the ambiance volume level.
        /// </summary>
        /// <param name="changeAmt">The amount to change the ambiance volume by.</param>
        public void ChangeAmbianceVolume(float changeAmt)
        {
            _ambianceVolume = Mathf.Clamp(_ambianceVolume + changeAmt, 0f, 1f);
            _ambianceVolumeChanged.Invoke();
        }

        /// <summary>
        /// Changes the voice volume level.
        /// </summary>
        /// <param name="changeAmt">The amount to change the voice volume by.</param>
        public void ChangeVoiceVolume(float changeAmt)
        {
            _voiceVolume = Mathf.Clamp(_voiceVolume + changeAmt, 0f, 1f);
            _voiceVolumeChanged.Invoke();
        }
    }
}
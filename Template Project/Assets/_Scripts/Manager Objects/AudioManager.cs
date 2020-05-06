using System;
using System.Collections.Generic;
using System.Linq;
using DataClasses;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        #region Private Properties

#pragma warning disable CS0649
        private static AudioManager _instance; // Global reference for the main AudioManager object

        [Header("Volume Settings")]
        [Tooltip("The overall volume level for the game. All other volumes will be multiplied by this " +
                 "value to determine the volume level they will play at."), 
            SerializeField, Range(0f, 1f)] private float _masterVolume;
        [Tooltip("The volume level for audio sources designated as music. This value will be multiplied " +
                 "by the master volume level to determine the volume level it will play at."), 
            SerializeField, Range(0f, 1f)] private float _musicVolume;
        [Tooltip("The volume level for audio sources designated as sound effects. This value will be " +
                 "multiplied by the master volume level to determine the volume level it will play at."), 
            SerializeField, Range(0f, 1f)] private float _sfxVolume;
        [Tooltip("The volume level for audio sources designated as ambient noise. This value will be " +
                 "multiplied by the master volume level to determine the volume level it will play at."),
            SerializeField, Range(0f, 1f)] private float _ambientVolume;
        [Tooltip("The volume level for audio sources designated as voice clips. This value will be " +
                 "multiplied by the master volume level to determine the volume level it will play at."),
            SerializeField, Range(0f, 1f)] private float _voiceVolume;

        [Header("Audio Sources")]
        [Tooltip("A list of music sources and their names. These values will be populated into a dictionary " +
                 "at runtime, so sources can be looked up by name. This exists simply for visual debugging."),
             SerializeField] private List<AudioSourceInfo> _musicSources = new List<AudioSourceInfo>();
        [Tooltip("A list of sound effect sources and their names. These values will be populated into a " +
                 "dictionary at runtime, so sources can be looked up by name. This exists simply for visual " +
                 "debugging."),
            SerializeField] private List<AudioSourceInfo> _sfxSources = new List<AudioSourceInfo>();
        [Tooltip("A list of ambient noise sources and their names. These values will be populated into a " +
                 "dictionary  at runtime, so sources can be looked up by name. This exists simply for visual " +
                 "debugging."), 
            SerializeField] private List<AudioSourceInfo> _ambientSources = new List<AudioSourceInfo>();
        [Tooltip("A list of voice clip sources and their names. These values will be populated into a " +
                 "dictionary at runtime, so sources can be looked up by name. This exists simply for visual " +
                 "debugging."),
             SerializeField] private List<AudioSourceInfo> _voiceSources = new List<AudioSourceInfo>();

        // The dictionary of audio sources designated as music. Allows sources to be looked up by name.
        private Dictionary<string, AudioSource> _musicDict = new Dictionary<string, AudioSource>();
        // The dictionary of audio sources designated as sound effects. Allows sources to be looked up by name.
        private Dictionary<string, AudioSource> _sfxDict = new Dictionary<string, AudioSource>();
        // The dictionary of audio sources designated as ambient sounds. Allows sources to be looked up by name.
        private Dictionary<string, AudioSource> _ambientDict = new Dictionary<string, AudioSource>();
        // The dictionary of audio sources designated as voice clips. Allows sources to be looked up by name.
        private Dictionary<string, AudioSource> _voiceDict = new Dictionary<string, AudioSource>();
#pragma warning restore CS0649

        #endregion

        #region Public Properties

        /// <summary>
        /// Global reference for the game's AudioManager object.
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
        public float AmbientVolume
        {
            get { return _ambientVolume; }
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
        }

        // Start is called before the first frame update
        private void Start()
        {
            // Gets all AudioSource components that are on child GameObjects of the AudioManger GameObject
            AudioSourceInfo[] audioSources = this.gameObject.GetComponentsInChildren<AudioSourceInfo>();

            // Filters audio sources by type and assigns them to the appropriate lists and dictionaries
            GetSources(ref audioSources, Enums.AudioType.Music, ref _musicSources, ref _musicDict);
            GetSources(ref audioSources, Enums.AudioType.SFX, ref _sfxSources, ref _sfxDict);
            GetSources(ref audioSources, Enums.AudioType.Ambient, ref _ambientSources, ref _ambientDict);
            GetSources(ref audioSources, Enums.AudioType.Voice, ref _voiceSources, ref _voiceDict);
        }

        // Update is called once per frame
        private void Update()
        {

        }

        /// <summary>
        /// Gets all audio sources of the designated type, and stores them in the appropriate lists and dictionaries.
        /// </summary>
        /// <param name="sources">The list of audio sources to query.</param>
        /// <param name="sourceType">The type of audio source to look for.</param>
        /// <param name="targetList">The list in which to store the list of audio sources.</param>
        /// <param name="targetDict">The dictionary in which to store audio sources and the names by which they will be
        /// referenced.</param>
        private void GetSources(ref AudioSourceInfo[] sources, Enums.AudioType sourceType,
            ref List<AudioSourceInfo> targetList, ref Dictionary<string, AudioSource> targetDict)
        {
            targetList = (from AudioSourceInfo source in sources where source.SourceType == sourceType select source)
                .ToList();

            foreach (AudioSourceInfo source in targetList)
            {
                try
                {
                    targetDict.Add(source.SourceName, source.ClipSource);
                }
                catch
                {
                    throw new ArgumentException(
                        $"The key {source.SourceName} already exists in the {sourceType.ToString()} dictionary!");
                }
                
            }
        }
    }
}
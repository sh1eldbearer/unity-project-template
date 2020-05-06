using System;
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
            SerializeField] private Enums.AudioType _sourceType = Enums.AudioType.None;

        [Tooltip("The name of this audio source. (Must be a unique name.)"),
            SerializeField] private string _sourceName;

        [Tooltip("The audio source containing the clip to be used."),
            SerializeField] private AudioSource _clipSource;
#pragma warning restore CS0649

        #endregion

        #region Public Properties

        /// <summary>
        /// The type of audio clip this is.
        /// </summary>
        public Enums.AudioType SourceType
        {
            get { return _sourceType; }
        }

        /// <summary>
        /// The name of this audio clip. (Must be a unique name.)
        /// </summary>
        public string SourceName
        {
            get { return _sourceName; }
        }

        /// <summary>
        /// The audio source containing the clip to be used.
        /// </summary>
        public AudioSource ClipSource
        {
            get { return _clipSource; }
        }

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
    }
}
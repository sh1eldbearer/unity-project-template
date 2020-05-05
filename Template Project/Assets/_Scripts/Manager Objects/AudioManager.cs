using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        #region Private Properties

#pragma warning disable CS0649
        private static AudioManager _instance; // Global reference for the main AudioManager object
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

        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}
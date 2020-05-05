using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Private Properties

#pragma warning disable CS0649
        private static GameManager _instance; // Global reference for the main GameManager object
#pragma warning restore CS0649

        #endregion

        #region Public Properties
        /// <summary>
        /// Global reference for the game's GameManager object.
        /// </summary>
        public static GameManager Instance
        {
            get { return _instance; }
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataClasses
{
    [System.Serializable]
    public class InputInfo
    {
        #region Private Properties

#pragma warning disable CS0649
        [Tooltip("The name used for this input."),
            SerializeField] private string _name;
        [Tooltip("The KeyCode used by this action."),
            SerializeField] private KeyCode _keyCode;
#pragma warning restore CS0649

        #endregion

        #region Public Properties

        #endregion
    }
}
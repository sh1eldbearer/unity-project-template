using UnityEngine;

namespace DataClasses
{
    [System.Serializable]
    public abstract class PlayerPrefsItem<Type>
    {
        #region Private Properties

#pragma warning disable CS0649
        [Tooltip("The key name of the PlayerPrefs setting."),
         SerializeField]
        private string _keyName;
#pragma warning restore CS0649

        #endregion

        #region Public Properties

        /// <summary>
        /// The key name of the PlayerPrefs setting.
        /// </summary>
        public string KeyName
        {
            get { return _keyName; }
        }

        #endregion

        public abstract Type GetValue();

        public abstract void SetValue(Type value);

        public bool HasKey()
        {
            return PlayerPrefs.HasKey(_keyName);
        }
    }
}
using UnityEngine;

namespace DataClasses
{
    [System.Serializable]
    public class PlayerPrefsItemString : PlayerPrefsItem<string>
    {
        /// <summary>
        /// Returns the stored string value for this setting in the preference file
        /// if it exists.
        /// </summary>
        /// <returns>Returns the stored string value for this setting in the preference file
        /// if it exists.</returns>
        public override string GetValue()
        {
            return PlayerPrefs.GetString(KeyName);
        }

        /// <summary>
        /// Sets the string value of the preference for this setting.
        /// </summary>
        /// <param name="value">The string value to save to the preference file.</param>
        public override void SetValue(string value)
        {
            PlayerPrefs.SetString(KeyName, value);
        }
    }
}

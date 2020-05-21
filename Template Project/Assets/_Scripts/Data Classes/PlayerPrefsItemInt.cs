using UnityEngine;

namespace DataClasses
{
    [System.Serializable]
    public class PlayerPrefsItemInt : PlayerPrefsItem<int>
    {
        /// <summary>
        /// Returns the stored integer value for this setting in the preference file
        /// if it exists.
        /// </summary>
        /// <returns>Returns the stored integer value for this setting in the preference file
        /// if it exists.</returns>
        public override int GetValue()
        {
            return PlayerPrefs.GetInt(KeyName);
        }

        /// <summary>
        /// Sets the integer value of the preference for this setting.
        /// </summary>
        /// <param name="value">The integer value to save to the preference file.</param>
        public override void SetValue(int value)
        {
            PlayerPrefs.SetInt(KeyName, value);
        }
    }
}

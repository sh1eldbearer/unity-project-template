using UnityEngine;

namespace DataClasses
{
    [System.Serializable]
    public class PlayerPrefsItemDecimal : PlayerPrefsItem<decimal>
    {
        /// <summary>
        /// Returns the stored float value for this setting in the preference file
        /// if it exists.
        /// </summary>
        /// <returns>Returns the stored float value for this setting in the preference file
        /// if it exists.</returns>
        public override decimal GetValue()
        {
            return (decimal)PlayerPrefs.GetFloat(KeyName);
        }

        /// <summary>
        /// Sets the float value of the preference for this setting.
        /// </summary>
        /// <param name="value">The float value to save to the preference file.</param>
        public override void SetValue(decimal value)
        {
            PlayerPrefs.SetFloat(KeyName, (float)value);
        }
    }
}
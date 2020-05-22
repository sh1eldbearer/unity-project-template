using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ChangeSliderValue : MonoBehaviour
{
    #region Private Properties
#pragma warning disable CS0649
    [SerializeField] private Slider _slider;
#pragma warning restore CS0649
    #endregion
	
	// Awake is called before Start
    private void Awake()
    {
        // Component reference assignments
        _slider = this.gameObject.GetComponent<Slider>();

        // Prevents this component from being attached to a GameObject that
        // does not already have a Slider component attached.
        if (_slider == null)
        {
            DestroyImmediate(this);
        }
    }

    /// <summary>
    /// Changes the value of this slider.
    /// </summary>
    /// <param name="value">The value to apply to this slider.</param>
    public void ChangeValue(float value)
    {
        _slider.value = value;
    }
}

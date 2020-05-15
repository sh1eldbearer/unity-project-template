using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuManager : MenuManager
{
    #region Private Properties
#pragma warning disable CS0649
    [Header("Volume Sliders")]
    private Slider _masterVolumeSlider;
    private Slider _musicVolumeSlider;
    private Slider _sfxVolumeSlider;
    private Slider _ambianceVolumeSlider;
    private Slider _voiceVolumeSlider;
#pragma warning restore CS0649
    #endregion

    #region Public Properties

    #endregion
	
	// Awake is called before Start
	protected override void Awake()
	{
        // Sets this object as the
		base.Awake();
	}

    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }
}

using UnityEngine;
using Utilities;

public abstract class MenuManager : MonoBehaviour
{
    #region Private Properties
#pragma warning disable CS0649
    protected static MenuManager _instance; // Static singleton instance of the GameManager class
#pragma warning restore CS0649
    #endregion

    #region Public Properties
    /// <summary>
    /// // Static singleton instance of the GameManager class
    /// </summary>
    public MenuManager Instance
    {
        get { return _instance; }
    }
    #endregion

    // Awake is called before Start
    protected virtual void Awake()
    {
        // Attempts to set this script as the static instance for this class
        Singleton<MenuManager>.SetAsStaticInstance(this, ref _instance, this.gameObject, true);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}

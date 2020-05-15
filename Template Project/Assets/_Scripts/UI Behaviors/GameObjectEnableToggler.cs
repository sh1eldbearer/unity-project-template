using UnityEngine;

public class GameObjectEnableToggler : MonoBehaviour
{
    /// <summary>
    /// Enables a GameObject in the game scene (so that it becomes visible).
    /// </summary>
    /// <param name="panelToEnable">The GameObject to enable.</param>
    public void EnableOtherGameObject(GameObject panelToEnable)
    {
        panelToEnable.SetActive(true);
    }

    /// <summary>
    /// Enables a GameObject in the game scene. The GameObject enabled will the be
    /// GameObject this script is attached to.
    /// </summary>
    public void EnableThisGameObject()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// Disables a GameObject in the game scene (so that it becomes invisible.)
    /// </summary>
    /// <param name="panelToDisable">The GameObject to disable.</param>
    public void DisableOtherGameObject(GameObject panelToDisable)
    {
        panelToDisable.SetActive(false);
    }

    /// <summary>
    /// Disables a GameObject in the game scene. The GameObject disabled will the be
    /// GameObject this script is attached to.
    /// </summary>
    public void DisableThisGameObject()
    {
        this.gameObject.SetActive(false);
    }
}

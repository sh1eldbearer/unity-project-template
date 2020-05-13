using UnityEngine;

public class GameObjectEnableToggler : MonoBehaviour
{
    /// <summary>
    /// Enables a panel in the game scene (so that it becomes visible).
    /// </summary>
    /// <param name="panelToEnable">The panel GameObject to enable.</param>
    public void EnablePanel(GameObject panelToEnable)
    {
        panelToEnable.SetActive(true);
    }

    /// <summary>
    /// Enables a panel GameObject in the game scene. The panel enabled will the be GameObject
    /// this script is attached to.
    /// </summary>
    public void EnableThisPanel()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// Disables a panel GameObject in the game scene (so that it becomes invisible.)
    /// </summary>
    /// <param name="panelToDisable">The panel GameObject to disable.</param>
    public void DisablePanel(GameObject panelToDisable)
    {
        panelToDisable.SetActive(false);
    }

    /// <summary>
    /// Disables a panel GameObject in the game scene. The panel disabled will the be GameObject
    /// this script is attached to.
    /// </summary>
    public void DisableThisPanel()
    {
        this.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject simulationsPanel;
    public void ShowPanel(GameObject panelToShow)
    {
        // Hide all panels first
        mainMenuPanel.SetActive(false);
        simulationsPanel.SetActive(false);

        // Show target panel
        panelToShow.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _UpgradePanel, _inSpaceShipPanel, _inGamePanel;



    public void LaunchButton()
    {
        CloseAllPanels();
        _inGamePanel.SetActive(true);
    }

    private void CloseAllPanels()
    {
        _inGamePanel.SetActive(false);
        _inSpaceShipPanel.SetActive(false);
        _UpgradePanel.SetActive(false);
    }
}

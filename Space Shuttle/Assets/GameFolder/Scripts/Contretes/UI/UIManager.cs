using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _UpgradePanel, _inSpaceShipPanel, _inGamePanel, _losePanel;


    private void Awake()
    {
        CloseAllPanels();
        _inSpaceShipPanel.SetActive(true);
    }

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
        _losePanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        CloseAllPanels();
        _losePanel.SetActive(true);
    }
}

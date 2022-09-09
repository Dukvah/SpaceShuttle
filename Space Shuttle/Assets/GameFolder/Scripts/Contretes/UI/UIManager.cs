using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _UpgradePanel, _inSpaceShipPanel, _inGamePanel, _losePanel;
    [SerializeField] private Button _onBoardButton;


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
    public void OnBoardButton()
    {
        CloseAllPanels();
        _inSpaceShipPanel.SetActive(true);
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

    public void OnBoard(bool status)
    {
        if (status)
        {
            _onBoardButton.gameObject.transform.DOScale(Vector3.one, 1f);
        }
        else if (!status)
        {
            _onBoardButton.gameObject.transform.DOScale(Vector3.zero, 1f);
        }
    }
}

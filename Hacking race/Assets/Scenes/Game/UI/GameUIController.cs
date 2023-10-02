using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : Singleton<GameUIController>
{
    [SerializeField] private GameObject _winningWindow;
    [SerializeField] private GameObject _losingWindow;
    [SerializeField] private GameObject _passingGameWindow;
    [SerializeField] private ShowingText _showingText;

    public void ShowWinningWindow()
    {
        _winningWindow.SetActive(true);
    }
    public void ShowLosingWindow()
    {
        _losingWindow.SetActive(true);
    }

    public void ReloadLevel()
    {
        _winningWindow.SetActive(false);
        _losingWindow.SetActive(false);
        GameController.Instance.LevelController.ReloadLevel();
    }

    public void ComeBackToMenu()
    {
        _winningWindow.SetActive(false);
        _losingWindow.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void GoToNextLevel()
    {
        _winningWindow.SetActive(false);
        _losingWindow.SetActive(false);
        GameController.Instance.StartNextLevel();
    }
    public void ShowTextForStartingGame(string text)
    {
        _showingText.gameObject.SetActive(true);
        _showingText.ShowText(text);
    }
    public void ShowPassingGameWindow()
    {
        _passingGameWindow.SetActive(true);
    }
}

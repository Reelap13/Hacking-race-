using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private LevelController[] levelControllers;
    private int _levelNumber;
    private LevelController _levelController;
    private void Awake()
    {
        LoadData();
        //vStartCoroutine(s());
    }

    IEnumerator s()
    {
        yield return new WaitForSeconds(10);
        _levelNumber = 2;
        LoadLevel();
    }

    private void LoadData()
    {
        _levelNumber = PlayerPrefs.GetInt("Level_number");
        LoadLevel();
    }

    public void StartNextLevel()
    {
        _levelNumber = PlayerPrefs.GetInt("Level_number") + 1;
        PlayerPrefs.SetInt("Level_number", _levelNumber);
        LoadLevel();
    }

    private void LoadLevel()
    {
        if (_levelController) _levelController.DeleteLevel();
        foreach (var levelController in levelControllers)
        {
            if (_levelNumber == levelController.LevelNumber)
            {
                _levelController = levelController;
                _levelController.LoadLevel();
                return;
            }
        }

        GameUIController.Instance.ShowPassingGameWindow();
    }

    public LevelController LevelController { get { return _levelController;} }
}

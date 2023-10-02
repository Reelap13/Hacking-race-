using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [field: SerializeField]
    public int LevelNumber { get; private set; }
    [SerializeField] private GraphController _graph;
    [SerializeField] private EnemyController _enemies;
    [SerializeField] private string _text = "";

    public void LoadLevel()
    {
        _graph.gameObject.SetActive(true);
        _graph.CreateGraph();

        Player.Instance.SetPreset(_graph.StartVertex);

        _enemies.gameObject.SetActive(true);
        _enemies.SetPresetEnemies();
        GameUIController.Instance.ShowTextForStartingGame(_text);
    }

    public void StartGame()
    {
        Player.Instance.ActivatePlayer();
        _enemies.ActivateEnemies();
    }

    public void DeleteLevel()
    {
        _enemies.DisactivateEnemies();
        _enemies.gameObject.SetActive(false);

        Player.Instance.DisactivatePlayer();
        Player.Instance.TraceMaker.ClearTraces();

        _graph.DeleteGraph();
        _graph.gameObject.SetActive(false);
    }

    public void KillPlayer()
    {
        _enemies.DisactivateEnemies();

        Player.Instance.DisactivatePlayer();
        Player.Instance.TraceMaker.ClearTraces(); 

        GameUIController.Instance.ShowLosingWindow();
    }

    public void Win()
    {
        _enemies.DisactivateEnemies();

        Player.Instance.DisactivatePlayer();
        Player.Instance.TraceMaker.ClearTraces();

        GameUIController.Instance.ShowWinningWindow();
    }

    public void ReloadLevel()
    {
        DeleteLevel();
        LoadLevel();
    }

}

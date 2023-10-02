using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningVertex : MonoBehaviour
{
    [SerializeField] private Vertex _vertex;

    private void Awake()
    {
        _vertex.OnEnter.AddListener(Win);
    }

    private void Win()
    {
        GameController.Instance.LevelController.Win();
    }
}

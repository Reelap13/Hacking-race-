using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPoint : MonoBehaviour
{
    [SerializeField] private Vertex _vertex;

    private void Awake()
    {
        _vertex.OnEnter.AddListener(Lose);
    }

    private void Lose()
    {
        Debug.Log("Game over");
    }
}

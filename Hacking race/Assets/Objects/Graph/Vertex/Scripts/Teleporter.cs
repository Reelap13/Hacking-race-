using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Vertex _vertex;
    [SerializeField] private Vertex _teleportationVertex;

    private void Awake()
    {
        _vertex.OnEnter.AddListener(Teleport);
    }

    private void Teleport()
    {
        Player.Instance.Movement.Teleport(_teleportationVertex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracesCleaner : MonoBehaviour
{
    [SerializeField] private Vertex _vertex;

    private void Awake()
    {
        _vertex.OnEnter.AddListener(ClearTraces);
    }

    private void ClearTraces()
    {
        Player.Instance.TraceMaker.ClearTraces();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    [field: SerializeField]
    public Vertex[] AdjacentVertices { get; private set; }

    public Transform Transform { get; private set; }
    private void Awake()
    {
        Transform = GetComponent<Transform>();
    }
}

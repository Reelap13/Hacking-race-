using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [field: SerializeField] 
    public Vertex Vertex { get; private set; }
    [field: SerializeField]
    public Vertex[] AdjacentVertices { get; private set; } = { };
    public Edge[] AdjacentEdges { get; private set; } = { };

    private int _index = 0;

    private void Awake()
    {
        Vertex.OnEnter.AddListener(Switch);
    }
    public void SetPreset(Edge[] edges)
    {
       AdjacentEdges = edges;
        foreach (Edge edge in AdjacentEdges)
            edge.TurnOff();

        if (AdjacentEdges.Length > 0)
            AdjacentEdges[0].TurnOn();
        _index = 0;
    }

    private void Switch()
    {
        AdjacentEdges[_index % AdjacentEdges.Length].TurnOff();
        ++_index;
        AdjacentEdges[_index % AdjacentEdges.Length].TurnOn();
    } 
}

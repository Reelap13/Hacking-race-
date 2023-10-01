using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour
{
    [SerializeField] private SelfDestroyer _selfDestroyer;
    public Trace Next { get; set; }
    public Trace Previous { get; set; }
    public Transform Transform { get; private set; }
    private void Awake()
    {
        Transform = transform;
    }

    public void ClearTrace()
    {
        if (Next) Next.Previous = null;
        if (Previous) Previous.Next = null;
        Destroy(gameObject);
    }

    public float GetLiveTime()
    {
        return _selfDestroyer.GetLiveTime();
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour
{
    public Trace Next { get; set; }
    public Trace Previous { get; set; }

    public void ClearTrace()
    {
        if (Next) Next.Previous = null;
        if (Previous) Previous.Next = null;
        Destroy(gameObject);
    }
}

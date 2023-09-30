using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementOfGraph : MonoBehaviour
{
    public abstract GraphicalMovementParameters GetParameters(Vector3 direction, GraphicalMovementParameters parameters);
}

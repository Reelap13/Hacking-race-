using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    public abstract void SetPreset();
    public abstract void Activate();
    public abstract void Disactivate();
}

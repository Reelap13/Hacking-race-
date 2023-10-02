using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _movement;

    public void SetPreset() => _movement.SetPreset();

    public void ActivateEnemy() => _movement.Activate();
    public void DisactivateEnemy() => _movement.Disactivate();
}

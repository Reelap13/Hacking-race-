using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;

    public void ActivateEnemies()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.SetPreset();
            enemy.ActivateEnemy();
        }
    }

    public void DisactivateEnemies()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.DisactivateEnemy();
        }
    }
}

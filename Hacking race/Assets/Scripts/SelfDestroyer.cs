using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    [SerializeField] private float _timeBeforeDestoing;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > _timeBeforeDestoing)
            Destroy(gameObject);
    }

    public float GetLiveTime()
    {
        return _time;
    }
}

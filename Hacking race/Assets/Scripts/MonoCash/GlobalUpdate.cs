using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalUpdate : Singleton<GlobalUpdate>
{
    public UnityEvent OnUpdate = new UnityEvent();
    public UnityEvent OnFixedUpdate = new UnityEvent();

    private void Update() => OnUpdate.Invoke();
    private void FixedUpdate() => OnFixedUpdate.Invoke();
}

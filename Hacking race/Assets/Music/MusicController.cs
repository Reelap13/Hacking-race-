using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : Singleton<MusicController>
{
    private void Awake()
    {
        if (MusicController.Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}

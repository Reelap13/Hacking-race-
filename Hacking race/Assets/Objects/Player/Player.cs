using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [field: SerializeField]
    public PlayerMovement Movement { get; private set; }
    [field: SerializeField]
    public TracesMaker TraceMaker { get; private set; }
}

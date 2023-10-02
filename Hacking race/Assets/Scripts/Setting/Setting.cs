using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Setting
{
    public static Audio Audio { get; } = new Audio();
    public static Quality Quality { get; } = new Quality();
    public static ResolutionScreenAndFullSceen Screen { get; } = new ResolutionScreenAndFullSceen();
    public static Difficulty Difficulty { get; } = new Difficulty();
}

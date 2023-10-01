using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tag
{
    PLAYER,
    ENEMY,
    TRACE,
    VERTEX,
    EDGE,
    UNKNOWN
}

public static class TagsMethod
{
    public static Tag ParseStringToTag(string tag)
    {
        switch (tag)
        {
            case "Player": return Tag.PLAYER;
            case "Trace": return Tag.TRACE;
            case "Vertex": return Tag.VERTEX;
            default: return Tag.UNKNOWN;
        }
    }
}

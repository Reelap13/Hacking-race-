using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingPlayerbyTouching : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tag tag = TagsMethod.ParseStringToTag(collision.tag);

        if (Tag.PLAYER == tag)
            GameController.Instance.LevelController.KillPlayer();
    }
}

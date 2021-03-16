using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;

    public void LookAtPlayer()
    {
        Vector3 flip = transform.localScale;
        flip.z *= -1;

        if(transform.position.x> player.position.x && isFlipped)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}

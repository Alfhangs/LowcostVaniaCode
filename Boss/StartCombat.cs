using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCombat : MonoBehaviour
{
    public GameObject Alucard;
    public GameObject door;
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Alucard.SetActive(true);
            door.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject key, panelInfo;
    public Transform player;
    Animator anim;
   
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == player)
        {
            anim.SetBool("Open", true);
            //StopAllCoroutines();
           // StartCoroutine(AddKey());
        }
    }

    public void InstantiateKey()
    {
        key.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(AddKey());
    }
    IEnumerator AddKey()
    {
        yield return new WaitForSeconds(1);
        panelInfo.SetActive(true);
        yield return new WaitForSeconds(1);
        panelInfo.SetActive(false);
    }
}

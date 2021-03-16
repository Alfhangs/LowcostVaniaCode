using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform player;
    public GameObject panelDialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == player)
        {
            print("A");
            panelDialogue.SetActive(true);
            GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        else
        {
            StopAllCoroutines();
            panelDialogue.SetActive(false);
        }
        StartCoroutine("FinishDialogue");
    }
    IEnumerator FinishDialogue()
    {
        yield return new WaitForSeconds(10);
       // LoadScene();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == player)
        {
            print("B");
            StopAllCoroutines();
            panelDialogue.SetActive(false);
        }
    }
    private void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PruebaMenu : MonoBehaviour
{
    public GameObject arrow, list;

    int index = 0;

    private void Start()
    {
        Drawn();
    }

    private void Update()
    {
        bool up = Input.GetKeyDown(KeyCode.UpArrow);
        bool down = Input.GetKeyDown(KeyCode.DownArrow);

        if (up) index--;
        if (down) index++;

        if (index > list.transform.childCount - 1) index = 0;
        else if (index < 0) index = list.transform.childCount - 1;

        if (up || down) Drawn();
        if (Input.GetKeyDown("return"))
        {
            Action();
        }
    }
    void Drawn()
    {
        Transform option = list.transform.GetChild(index);
        arrow.transform.position = option.position;
    }
    void Action()
    {
        Transform option = list.transform.GetChild(index);

        if(option.gameObject.name == "Exti")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(option.gameObject.name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject panelPause, panelInventory;
    bool menuPause = false;
    bool menuInventory = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("Entro al menu para ver");
            menuPause = !menuPause;

            if (menuPause)
            {
                Time.timeScale = 0;
                panelPause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                panelPause.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            print("Entro en el inventario");
            menuInventory = !menuInventory;
            if (menuInventory)
            {
                panelInventory.SetActive(true);
            }
            else
                panelInventory.SetActive(false);
        }
    }

}

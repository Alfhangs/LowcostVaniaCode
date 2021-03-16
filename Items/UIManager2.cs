//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class UIManager : MonoBehaviour
//{
//    public GameObject panelPause;
//    public Transform cursor;
//    public GameObject[] menuOptions;
//    public Text healthText, manaText, strenghtText, attackText, defenseText;
//    public GameObject panelOptions, itemList;
//    public GameObject itemListPrefap;
//    public RectTransform content;
//    public Text description;
//    public Scrollbar scrollVertical;


//    Inventory2 inventory;
//    Player player;
//    bool menuPause = false;
//    int cursorIndex = 0;
//    public List<ItemList> items;
//    bool itemListActive = false;

//    private void Start()
//    {
//        inventory = Inventory2.inventory;
//        player = FindObjectOfType<Player>();
//    }
//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.P))
//        {
//            menuPause = !menuPause;
//            cursorIndex = 0;
//            itemListActive = false;
//            description.text = "";
//            itemList.SetActive(false);
//            panelOptions.SetActive(true);
//            UpdateAtributes();
//            UpdateUI();
//            if (menuPause)
//            {
//                //Time.timeScale = 0;
//                panelPause.SetActive(true);
//            }
//            else
//            {
//                // Time.timeScale = 1;
//                panelPause.SetActive(false);
//            }
//            if (menuPause)
//            {
//                Vector3 cursorPosition = new Vector3();
//                print("entro al menu");
//                if (itemListActive)
//                {
//                    print("A");
//                    cursorPosition = menuOptions[cursorIndex].transform.position;
//                    cursor.position = new Vector3(cursorPosition.x - 100, cursorPosition.y, cursorPosition.z);
//                }
//                else if (itemListActive && items.Count > 0)
//                {
//                    print("B");
//                    cursorPosition = items[cursorIndex].transform.position;
//                    cursor.position = new Vector3(cursorPosition.x - 75, cursorPosition.y, cursorPosition.z);
//                }
//                if (Input.GetKeyDown(KeyCode.I))
//                {
//                    print("C");
//                    if (!itemListActive && cursorIndex >= menuOptions.Length - 1)
//                    {
//                        cursorIndex = menuOptions.Length - 1;
//                    }
//                    else if (itemListActive && cursorIndex >= items.Count - 1)
//                    {
//                        if (items.Count == 0)
//                        {
//                            cursorIndex = 0;
//                        }
//                        else
//                        {
//                            cursorIndex = items.Count - 1;
//                        }
//                    }
//                    else
//                        cursorIndex++;
//                    if (itemListActive && items.Count > 0)
//                    {
//                        scrollVertical.value -= (1f / (items.Count - 1));
//                        UpdateDescription();
//                    }
//                }
//                else if (Input.GetKeyDown(KeyCode.K))
//                {
//                    if (cursorIndex == 0)
//                        cursorIndex = 0;
//                    else
//                        cursorIndex--;
//                    if (itemListActive && items.Count > 0)
//                    {
//                        scrollVertical.value += (1f / (items.Count - 1));
//                        UpdateDescription();
//                    }
//                }
//                //Si presiono enter
//                if (Input.GetKeyDown("return") && !itemListActive)
//                {
//                    print("Estoy entrando");
//                    panelOptions.SetActive(false);
//                    itemList.SetActive(true);
//                    RefreshItemList();
//                    UpdateItemsList(cursorIndex);
//                    cursorIndex = 0;
//                    if (items.Count > 0)
//                        UpdateDescription();
//                    itemListActive = true;
//                }
//                else if (Input.GetButtonDown("Submit") && itemListActive)
//                {
//                    if (items.Count > 0)
//                    {
//                        UseItem();
//                    }
//                }
//            }
//        }
//    }
//    void UseItem()
//    {
//        //if (items[cursorIndex].weapon != null)
//        //{
//        //    //player.AddWeapon(items[cursorIndex].weapon);
//        //}
//        if (items[cursorIndex].consumibleItem != null)
//        {
//            player.UseItem(items[cursorIndex].consumibleItem);
//            inventory.RemoveItem(items[cursorIndex].consumibleItem);
//            cursorIndex = 0;
//            RefreshItemList();
//            UpdateItemsList(2);
//            scrollVertical.value = 1;
//        }
//        //else if (items[cursorIndex].armor != null)
//        //{
//        //   // player.AddArmor(items[cursorIndex].armor);
//        //}
//        UpdateAtributes();
//        UpdateDescription();
//    }
//    void UpdateDescription()
//    {
//        //if (items[cursorIndex].weapon != null)
//        //    description.text = items[cursorIndex].weapon.description;
//        if (items[cursorIndex].consumibleItem != null)
//            description.text = items[cursorIndex].consumibleItem.description;
//        else if (items[cursorIndex].key != null)
//            description.text = items[cursorIndex].key.description;
//        //else if (items[cursorIndex].armor != null)
//        //    description.text = items[cursorIndex].armor.description;
//    }

//    void RefreshItemList()
//    {
//        for (int i = 0; i < items.Count; i++)
//        {
//            Destroy(items[i].gameObject);
//        }
//        items.Clear();
//    }

//    void UpdateItemsList(int option)
//    {
//        if (option == 0)
//        {
//            for (int i = 0; i < inventory.items.Count; i++)
//            {
//                GameObject tempItem = Instantiate(itemListPrefap, content.transform);
//                tempItem.GetComponent<ItemList>().SetUpItem(inventory.items[i]);
//                items.Add(tempItem.GetComponent<ItemList>());
//            }
//        }
//        else if (option == 1)
//        {
//            for (int i = 0; i < inventory.keys.Count; i++)
//            {
//                GameObject tempItem = Instantiate(itemListPrefap, content.transform);
//                tempItem.GetComponent<ItemList>().SetUpKey(inventory.keys[i]);
//                items.Add(tempItem.GetComponent<ItemList>());
//            }
//        }
//    }

//    void UpdateAtributes()
//    {
//        healthText.text = "Vida: " + player.GetHealth() + "/" + player.maxHealth;
//        manaText.text = "Mana: " + player.GetMana() + "/" + player.maxMana;
       
//    }
//    public void UpdateUI()
//    {
//        //healthUI.text = player.getHealth() + " / " + player.maxHealth;
//        //manaUI.text = player.getMana() + " / " + player.maxMana;
//        //potionUI.text = "x " + inventory.CountItems(player.item);
//    }
//}



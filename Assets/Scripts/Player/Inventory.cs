using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string name = "";
    public Texture2D texture;
}

public class Inventory : MonoBehaviour
{
    public int width = 5, height = 10, boxWidth = 40, boxHeight = 40, borderX = 5, borderY = 5;
    
    public List<Item> items;
    
    public int selectedItemFromList = 0;
    
    Item[,] slotItems;
    
    Item selectedItem;
    int selectedItemX;
    int selectedItemY;
    
    public bool openInventory = false;
    
	void Start ()
    {
	   slotItems = new Item[width, height];
       
       selectedItem = new Item();
       selectedItem.name = "null";
       
       for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                slotItems[x, y] = new Item();
                slotItems[x, y].name = "null";
            }
        }
        
        slotItems[0, 0] = items[0];
        slotItems[1, 0] = items[1];
	}
	
	void Update ()
    {
	   if(Input.GetKeyDown(KeyCode.I))
       {
           openInventory = !openInventory;
       }
	}
    
    void OnGUI()
    {
        if(openInventory == true)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if(GUI.Button(new Rect(x * (boxWidth + borderX), y * (boxHeight + borderY), boxWidth, boxHeight), ""))
                    {
                        if(slotItems[x, y].name == "null" && selectedItem.name != "null")
                        {
                            slotItems[x, y] = selectedItem;
                            slotItems[selectedItemX, selectedItemY] = new Item();
                            slotItems[selectedItemX, selectedItemY].name = "null";
                            selectedItem = new Item();
                            selectedItem.name = "null";
                            selectedItemX = x;
                            selectedItemY = y;
                        }
                        
                        if(slotItems[x, y].name != "null")
                        {
                            selectedItem = slotItems[x, y];
                            selectedItemX = x;
                            selectedItemY = y;
                        }
                    }
                    
                    if(slotItems[x, y].name != "null")
                    {
                        GUI.DrawTexture(new Rect(x * (boxWidth + borderX), y * (boxHeight + borderY), boxWidth, boxHeight), slotItems[x, y].texture);
                    }
                }
            }
        }
    }
}

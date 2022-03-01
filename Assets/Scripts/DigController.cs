using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DigController : MonoBehaviour
{

    private GameObject confirmLocationText;
    private TextMeshProUGUI updateText;

    private GameObject[] diggingContents;
    private string areaName;
    private GameObject buttonRef;

    private GameObject resultText;
    private TextMeshProUGUI itemResultText;

    // default part.
    public GameObject empty;

    public GameObject playerRef;

    void Awake()
    {
        confirmLocationText = this.transform.Find("ConfirmText").gameObject;
        updateText = confirmLocationText.GetComponent<TextMeshProUGUI>();

        // hacky way of getting a reference to DigResultMenu, then to ResultTexts, then to ItemText.
        resultText = transform.parent.gameObject.transform.GetChild(1).GetChild(0).GetChild(1).gameObject;
        itemResultText = resultText.GetComponent<TextMeshProUGUI>();
    }

    void UpdateButtonRef(GameObject button)
    {
        // set button reference to script.
        buttonRef = button;
        string name = buttonRef.GetComponent<AreaData>().AreaName;
        Debug.Log(name);
        GameObject[] items = buttonRef.GetComponent<AreaData>().ItemList;
        
        // move passed in data to script's data.
        diggingContents = items;

        // update text to show area name.
        AreaInfoUpdate(name);
        // log available items to dig in area.
        AreaObjectUpdate();
    }

    void AreaInfoUpdate(string areaLocation)
    {
        areaName = areaLocation;
        updateText.text = "Dig at " + areaName + "?";
    }

    void AreaObjectUpdate()
    {
        Debug.Log("THE ITEMS IN THIS AREA ARE:"); 

        for(int i = 0; i < diggingContents.Length; i++)
        {
            if (diggingContents[i] == null)
            {
                // handler to show empty spots and prevent crashing. 
                // come back to this when the game design is settled.
                Debug.Log("Nothing");
            } 
            else
            {
                Debug.Log(diggingContents[i].ToString());
            }
        }
            
    }

    void DigHole(MenuController script)
    {
        Debug.Log("dig");

        // dig from random spot in array.
        int itemIndex = Random.Range(0, diggingContents.Length);
        Debug.Log(itemIndex);

        // get object data.
        GameObject item = diggingContents[itemIndex];

        if (item == null)
        {
            Debug.Log("Dug nothing.");
            // reference stats of empty part.
            script.DigResult = empty;
        } 
        else
        {
            // remove dug item from pull list.
            buttonRef.GetComponent<AreaData>().ItemList[itemIndex] = null;

            // log dug item.
            Debug.Log("Dug " + item.name + "!");
            Debug.Log("Stat1 value: " + item.GetComponent<ItemData>().Stat1);
            Debug.Log("Stat2 value: " + item.GetComponent<ItemData>().Stat2);
            Debug.Log("Stat3 value: " + item.GetComponent<ItemData>().Stat3);

            // pass the dig result back to the menu controller.
            script.DigResult = item;
        }

        
    }

    void DisplayResults(GameObject dugItem)
    {
        if (dugItem.name == "EmptyPart")
        {
            itemResultText.text = "Nothing.";
        }
        else
        {
            itemResultText.text = dugItem.GetComponent<ItemData>().itemName;

            playerRef.SendMessage("StatUpdate", dugItem);
        }
    }
}

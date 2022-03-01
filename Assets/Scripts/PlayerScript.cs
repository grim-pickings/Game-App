using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;

public class PlayerScript : MonoBehaviour
{

    private float Stat1 = 0; 
    private float Stat2 = 0;
    private float Stat3 = 0;

    private Sprite partImage;

    private GameObject statTextObject;
    private TextMeshProUGUI statText;

    // get reference to creature image parts.
    public GameObject Head;
    public GameObject Body;
    public GameObject LeftArm;
    public GameObject RightArm;
    public GameObject LeftLeg;
    public GameObject RightLeg;

    private DatabaseReference _database;

    // Start is called before the first frame update
    void Start()
    {
        statTextObject = this.transform.Find("StatsLabel").gameObject;
        statText = statTextObject.GetComponent<TextMeshProUGUI>();

        _database = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // function to update stat label information with passed in data. 
    // logic is not complete, getting a new part will directly add to stats.
    // needs to remove values from the removed part first. 
    void StatUpdate(GameObject dugItem)
    {
        string itemName = dugItem.GetComponent<ItemData>().itemName;
        float stat1Val = dugItem.GetComponent<ItemData>().Stat1;
        float stat2Val = dugItem.GetComponent<ItemData>().Stat2;
        float stat3Val = dugItem.GetComponent<ItemData>().Stat3;

        Stat1 += stat1Val;
        Stat2 += stat2Val;
        Stat3 += stat3Val;

        partImage = dugItem.GetComponent<ItemData>().image;

        statText.text = "Stat 1: " + Stat1 + "\nStat 2: " + Stat2 + "\nStat 3: " + Stat3;

        // switch statement dependent on body part type. 
        switch (dugItem.GetComponent<ItemData>().bodyPart)
        {
            case "Left Leg":
                LeftLeg.GetComponent<Image>().sprite = partImage; 
                break;
            case "Right Leg":
                RightLeg.GetComponent<Image>().sprite = partImage; 
                break;
            case "Left Arm":
                LeftArm.GetComponent<Image>().sprite = partImage; 
                break;
            case "Right Arm":
                RightArm.GetComponent<Image>().sprite = partImage;
                break;
            case "Body":
                Body.GetComponent<Image>().sprite = partImage; 
                break;
            case "Head":
                Head.GetComponent<Image>().sprite = partImage;
                break;
            case "empty":
                // do nothing.
                break;
            default:
                Debug.Log("No match found for StatUpdate switch statement.");
                break;
        }

        playerDatabaseItemUpdate(itemName, stat1Val.ToString(), stat2Val.ToString(), stat3Val.ToString());
    }

    void playerDatabaseItemUpdate(string itemName, string stat1, string stat2, string stat3)
    {
        ItemInfo item = new ItemInfo(itemName, stat1, stat2, stat3);
        string json = JsonUtility.ToJson(item);

        Debug.Log(json);
        _database.Child("inventory").SetValueAsync(json);
    }

    public class ItemInfo
    {
        public string name;
        public string stat1;
        public string stat2;
        public string stat3;

        public ItemInfo(string name, string stat1, string stat2, string stat3)
        {
            this.name = name;
            this.stat1 = stat1;
            this.stat2 = stat2;
            this.stat3 = stat3;
        }
    }

}

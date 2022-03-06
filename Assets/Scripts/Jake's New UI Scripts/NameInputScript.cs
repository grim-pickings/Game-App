using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputScript : MonoBehaviour
{
    public string nameVal;
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject nameInputCanvasGroup;
    [SerializeField] private InputField nameInputObject;
    [SerializeField] private Text placeholderText;
    private string[] nameExamples = { "Soulsnare", "Tangleling", "Stonewing", "Foulstrike",
        "Chaosscreamer", "Wispman", "Spiritstep", "Emberwings", "Decayling", "Toxinwings", "Phantomgolem",
        "Cursehood", "Umbramask", "Phaseserpent", "Shadevine", "Cavernfigure", "Germchild",
        "Grimebeast", "Frightclaw", "Shadespawn", "Boweltooth", "Corpsehound", "Coffinwoman", "Gallman"};
    bool naming = true;

    void Start()
    {
        StartCoroutine(nameChange());
    }

    //Function used once the player has typed in a name for their monster to transition screens
    public void nameInput()
    {
        nameVal = nameInputObject.text;
        nameInputCanvasGroup.SetActive(false);
        //nameText.text = nameVal;
        mainUI.SetActive(true);
        naming = false;
    }

    //Coroutine used for cycling the example names in the input section
    IEnumerator nameChange()
    {
        int i = 0;
        while (naming == true)
        {
            if (i >= nameExamples.Length)
            {
                i = 0;
            }
            placeholderText.text = "Ex. " + nameExamples[i] + "...";
            i++;

            yield return new WaitForSeconds(2f);
        }
    }
}

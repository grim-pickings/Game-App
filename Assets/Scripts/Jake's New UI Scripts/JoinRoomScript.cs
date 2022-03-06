using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoomScript : MonoBehaviour
{
    [SerializeField] private InputField codeInputObject;
    [SerializeField] private Text failedCodeText;
    [SerializeField] private GameObject startScreenCanvasGroup;
    [SerializeField] private GameObject createScreenCanvasGroup;
    [SerializeField] private GameObject joinScreenCanvasGroup;
    [SerializeField] private GameObject characterSelectCanvasGroup;

    public void joinScreen()
    {
        startScreenCanvasGroup.SetActive(false);
        joinScreenCanvasGroup.SetActive(true);
    }

    public void join()
    {
        string codeVal = codeInputObject.text;
        //This variable grab from the script is temprary for testing. This will be changed when actually joining a room
        if (createScreenCanvasGroup.GetComponent<CreateRoomScript>().code == codeVal)
        {
            joinScreenCanvasGroup.SetActive(false);
            characterSelectCanvasGroup.SetActive(true);
        }
        else
        {
            failedCodeText.text = "No rooms matching that code";
        }
    }
}

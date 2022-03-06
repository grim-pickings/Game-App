using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomScript : MonoBehaviour
{
    [SerializeField] private GameObject startScreenCanvasGroup;
    [SerializeField] private GameObject createScreenCanvasGroup;
    [SerializeField] private GameObject characterSelectCanvasGroup;
    [SerializeField] private Text codeText;
    public string code;

    public void createScreen()
    {
        startScreenCanvasGroup.SetActive(false);
        createScreenCanvasGroup.SetActive(true);
        codeGeneration();
    }

    public void codeGeneration()
    {
        code = "";
        string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = 0; i < 6; i++)
        {
            int a = Random.Range(0, characters.Length);
            code += characters[a];
        }
        codeText.text = code;
    }

    public void create()
    {
        createScreenCanvasGroup.SetActive(false);
        characterSelectCanvasGroup.SetActive(true);
    }
}

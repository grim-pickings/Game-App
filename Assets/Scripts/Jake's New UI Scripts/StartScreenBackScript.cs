using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenBackScript : MonoBehaviour
{
    [SerializeField] private GameObject startScreenCanvasGroup;
    [SerializeField] private GameObject createScreenCanvasGroup;
    [SerializeField] private GameObject joinScreenCanvasGroup;

    public void back()
    {
        startScreenCanvasGroup.SetActive(true);
        createScreenCanvasGroup.SetActive(false);
        joinScreenCanvasGroup.SetActive(false);
    }
}

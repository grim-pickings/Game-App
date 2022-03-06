using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScript : MonoBehaviour
{
    [SerializeField] private GameObject nameInputCanvasGroup;
    [SerializeField] private GameObject characterSelectCanvasGroup;
    public string characterModel;

    public void characterSelected(string character)
    {
        characterModel = character;
    }

    public void characterConfirm()
    {
        characterSelectCanvasGroup.SetActive(false);
        nameInputCanvasGroup.SetActive(true);
    }
}

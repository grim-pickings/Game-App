using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{

    public GameObject GameMenu;
    public GameObject DigMenu;
    public GameObject ResultMenu;
    public GameObject DigConfirmMenu;
    public GameObject DigResultMenu;

    public GameObject DigResult;

    public void DigButton()
    {
        GameMenu.SetActive(false);
        DigMenu.SetActive(true);
    }

    public void AreaDigButton()
    {
        DigMenu.SetActive(false);
        ResultMenu.SetActive(true);
        DigConfirmMenu.SetActive(true);

        // send reference to selected button to DigController on DigConfirmMenu.
        DigConfirmMenu.SendMessage("UpdateButtonRef", EventSystem.current.currentSelectedGameObject);
    }

    public void DigConfirmButton()
    {
        // process data before deactivating the menu,
        // and pass itself so the DigResult variable can be modified.
        DigConfirmMenu.SendMessage("DigHole", this);
        Debug.Log("THE OBJECT ON MenuController IS: " + DigResult);

        // GameMenu needs to be active so that the DisplayResults function can send the StatUpdate message to it. 
        // consider improving this later?
        GameMenu.SetActive(true);
        DigConfirmMenu.SendMessage("DisplayResults", DigResult);
        GameMenu.SetActive(false);

        DigConfirmMenu.SetActive(false);
        DigResultMenu.SetActive(true);
    }

    public void DigCancelButton()
    {
        DigConfirmMenu.SetActive(false);
        ResultMenu.SetActive(false);
        DigMenu.SetActive(true);
    }

    public void ResultEndButton()
    {
        DigResultMenu.SetActive(false);
        ResultMenu.SetActive(false);
        GameMenu.SetActive(true);
    }
}

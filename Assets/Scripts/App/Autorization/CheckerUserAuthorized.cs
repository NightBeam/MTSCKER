using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerUserAuthorized : MonoBehaviour
{
    public User user;
    public GameObject[] UIOBJ;
    void Start()
    {
        if (user.authorized)
        {
            UIOBJ[0].SetActive(false);
            UIOBJ[1].SetActive(false);
            UIOBJ[2].SetActive(true);
            UIOBJ[3].SetActive(true);
            UIOBJ[4].SetActive(true);
            UIOBJ[5].SetActive(false);
            UIOBJ[6].SetActive(false);

        }
        else
        {
            UIOBJ[0].SetActive(true);
            UIOBJ[1].SetActive(false);
            UIOBJ[2].SetActive(false);
            UIOBJ[3].SetActive(false);
            UIOBJ[4].SetActive(false);
            UIOBJ[5].SetActive(false);
            UIOBJ[6].SetActive(false);
        }
    }

    public void OpenAuthorizationWindow()
    {
        UIOBJ[0].SetActive(false);
        UIOBJ[1].SetActive(true);
    }
}

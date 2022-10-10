using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SetUserConfig : MonoBehaviour
{
    public Text[] textFields;
    public Dropdown dropdown;
    CheckerUserAuthorized CheckerUserAuthorized;
    private void Start()
    {
        CheckerUserAuthorized = GetComponent<CheckerUserAuthorized>();
    }
    public void writeUserConfig()
    {
        CheckerUserAuthorized.user.firstName = textFields[0].text;
        CheckerUserAuthorized.user.lastName = textFields[1].text;
        CheckerUserAuthorized.user.password = textFields[2].text;
        CheckerUserAuthorized.user.post = dropdown.value;
        CheckerUserAuthorized.user.authorized = true;
        OpenTinder();
    }

    void OpenTinder()
    {
        CheckerUserAuthorized.UIOBJ[1].SetActive(false);
        CheckerUserAuthorized.UIOBJ[2].SetActive(true);
        CheckerUserAuthorized.UIOBJ[3].SetActive(true);
        CheckerUserAuthorized.UIOBJ[4].SetActive(true);
        CheckerUserAuthorized.UIOBJ[5].SetActive(false);
        CheckerUserAuthorized.UIOBJ[6].SetActive(false);
    }


}

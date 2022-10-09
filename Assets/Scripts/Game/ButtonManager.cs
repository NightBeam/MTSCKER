using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
    private void Awake()
    {
        uIManager = GetComponent<UIManager>();
    }

    public void ShowAndHideExitPannel(bool yes)
    {
        uIManager.ShowAndHide(uIManager.ExitGameOBJ, yes);
    }
}

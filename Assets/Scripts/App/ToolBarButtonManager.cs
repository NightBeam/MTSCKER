using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToolBarButtonManager : MonoBehaviour
{
    public GameObject[] windows;
    public void OpenUser()
    {
        windows[0].SetActive(false);
        windows[1].SetActive(true);
        windows[2].SetActive(false);
    }
    public void OpenTinder()
    {
        windows[0].SetActive(true);
        windows[1].SetActive(false);
        windows[2].SetActive(false);
    }
    public void OpenChat()
    {
        windows[0].SetActive(false);
        windows[1].SetActive(false);
        windows[2].SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("EggSmash");
    }
}


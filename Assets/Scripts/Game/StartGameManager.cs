using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    public static bool isStarted;

    private void Start()
    {
        isStarted = false;
    }
    public void StartGame()
    {
        isStarted = true;
    }
}

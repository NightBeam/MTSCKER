using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameManager : MonoBehaviour
{
    UIManager uIManager;
    public GameObject GoldenEgg;
    public static bool gameIsStarted;
    private void Start()
    {
        gameIsStarted = false;
        uIManager.ShowAndHide(uIManager.EndGameOBJ, false);
        uIManager.ShowAndHide(uIManager.StartGameOBJ, true);
        uIManager = GetComponent<UIManager>(); 
    }
    public void StartGame()
    {
        uIManager.ShowAndHide(uIManager.StartGameOBJ, false);
        gameIsStarted = true;
        
    }



}

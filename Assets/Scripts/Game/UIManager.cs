using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum ShoisenText
    {
        pointsField = 0,
        scoreField,
        messageField,
        endGameField
    }

    public Text[] textField; //4 text fields for a game (point, score, message, endGame)

    public GameObject StartGameOBJ;
    public GameObject EndGameOBJ;

    public void ShowAndHide(GameObject objToDo, bool showOrHide)
    {
        if (showOrHide)
        {
            objToDo.SetActive(true);
        }
        else
        {
            objToDo.SetActive(false);
        }
    }
}

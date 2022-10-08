using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum ChoisenText : int //������������ ����� �� ������ ������� � ��������� ��������
    {
        pointsField = 0,
        scoreField,
        messageField,
        endGameField
    }

    public Text[] textField; //4 text fields for a game (point, score, message, endGame)

    public GameObject StartGameOBJ;
    public GameObject EndGameOBJ;

    public void ShowAndHide(GameObject objToDo, bool showOrHide) //�������� ��� ���������� �������
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
    private void Update()
    {
        if(StartGameManager.gameIsStarted)
            WriteDatasIntoTextFieldFrom(ChoisenText.scoreField, $"{EggRocketManager.points}/{EnemyEggRocket.points}");
        else
            WriteDatasIntoTextFieldFrom(ChoisenText.scoreField, "");
    }
    public void WriteDatasIntoTextFieldFrom(ChoisenText where, string someText)//����� ��� ������ ������ ����� ������ � ��������� ���� 
    {
        textField[(int)where].text = someText;
    }
    //public void WriteDatasIntoTextFieldFrom(ChoisenText where, WriteDatas writeDatas) //����� ��� ������ ������ �� �������� ������ (PlayerPrefs) (����������)
    //{
    //    textField[(int)where].text = Convert.ToString(writeDatas.Invoke());
    //}
    //public delegate int WriteDatas();
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public UIManager uIManager;
    public GameObject GoldenEgg;
    public static bool gameIsStarted;

    public GameObject Player;
    private void Awake()
    {
        gameIsStarted = false;   //���������� ��� ���� �� ��������
        uIManager = GetComponent<UIManager>(); 
        scoreManager = GetComponent<ScoreManager>();
    } 
    private void Start()
    {
        Player.SetActive(false);
        uIManager.ShowAndHide(uIManager.EndGameOBJ, false); //�������� �������� ����
        uIManager.ShowAndHide(uIManager.StartGameOBJ, true); //������ ��������� ����
        scoreManager.points = PointsManager.GetPoint();
        uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.pointsField, Convert.ToString(scoreManager.points));
        uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.messageField, "You was joined\n");
    }
    public void StartGame()//������ ����
    {
        Player.SetActive(true);
        uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.messageField, "Game is started\n");
        Invoke("ResetText", 2f);
        uIManager.ShowAndHide(uIManager.StartGameOBJ, false); //�������� �������� ����
        gameIsStarted = true;//���������� ��� ���� ��������
        SpawnGoldenEgg(GoldenEgg, new Vector3(0f, 0f, 0f), new Vector2(0f, 10f));
    }
    public void SpawnGoldenEgg(GameObject spawnObj, Vector3 pos, Vector2 initialVectorOfVelocity) //����� ��� �������� ���� � �������� ��� ����
    {
        scoreManager.GoldenEggTracker = Instantiate(spawnObj, pos, Quaternion.identity);
        scoreManager.GoldenEggTracker.GetComponent<GoldEggManager>().initialDirection = initialVectorOfVelocity;
        EnemyEggRocket.GoldenEgg = scoreManager.GoldenEggTracker;
    }

    void ResetText()
    {
        uIManager.textField[(int)UIManager.ChoisenText.messageField].text = "";
    }
}

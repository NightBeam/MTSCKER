using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public UIManager uIManager;
    public GameObject GoldenEgg;
    public static bool gameIsStarted;

    public GameObject Player;

    public PointsManager pointsManager;
    private void Awake()
    {
        gameIsStarted = false;   //���������� ��� ���� �� ��������
        uIManager = GetComponent<UIManager>(); 
        scoreManager = GetComponent<ScoreManager>();
    } 
    private void Start()
    {
        int gameRestart = GetRestartGame();
        
        Player.SetActive(false);
        uIManager.ShowAndHide(uIManager.EndGameOBJ, false); //�������� �������� ����
        uIManager.ShowAndHide(uIManager.StartGameOBJ, true); //������ ��������� ����
        uIManager.ShowAndHide(uIManager.ExitGameOBJ, false);//��������� ���� ������
        scoreManager.points = pointsManager.GetPoint();
        uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.pointsField, Convert.ToString(scoreManager.points));
        if(gameRestart == 0)
        {
            uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.messageField, "�� �������������\n");
        }
        else
        {
            uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.messageField, "���� ������������\n");
        }
    }
    public void StartGame()//������ ����
    {
        Player.SetActive(true);
        uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.messageField, "���� ��������\n");
        Invoke("ResetText", 2f);
        uIManager.ShowAndHide(uIManager.StartGameOBJ, false); //�������� �������� ����
        gameIsStarted = true;//���������� ��� ���� ��������
        SpawnGoldenEgg(GoldenEgg, new Vector3(0f, 0f, 0f), new Vector2(0f, 10f), null);
    }
    public void SpawnGoldenEgg(GameObject spawnObj, Vector3 pos, Vector2 initialVectorOfVelocity, Transform startPos) //����� ��� �������� ���� � �������� ��� ����
    {
        scoreManager.GoldenEggTracker = Instantiate(spawnObj, pos, Quaternion.identity);
        GoldEggManager goldenEggManager = scoreManager.GoldenEggTracker.GetComponent<GoldEggManager>();
        goldenEggManager.initialDirection = initialVectorOfVelocity;
        goldenEggManager.startPos = startPos;
        EnemyEggRocket.GoldenEgg = scoreManager.GoldenEggTracker;
    }

    void ResetText()
    {
        uIManager.textField[(int)UIManager.ChoisenText.messageField].text = "";
    }

    public static void SetRestartGame(int value)
    {
        PlayerPrefs.SetInt("RestartGame", value);
    }
    public static int GetRestartGame()
    {
        int result = PlayerPrefs.GetInt("RestartGame");
        return result; 
    }
    public void RestartGame(int numberOfRoom)
    {
        SetRestartGame(1);
        SceneManager.LoadScene(numberOfRoom);
    }
    public void ExitGame(int numberOfRoom)
    {
        SetRestartGame(0);
        SceneManager.LoadScene(numberOfRoom);
    }
}

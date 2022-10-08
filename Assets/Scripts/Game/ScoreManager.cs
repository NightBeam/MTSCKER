using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ScoreManager : MonoBehaviour
{
    public int points;
    public GameObject GoldenEggTracker;
    [SerializeField] StartGameManager startGameManager;
    public GameObject[] players;
    private void Awake()
    {
        startGameManager = GetComponent<StartGameManager>(); 
    }

    private void Update()
    {
        if (StartGameManager.gameIsStarted)
        {
            if (GoldenEggTracker != null)
            {
                if (GoldenEggTracker.transform.position.y >= 5.3f)
                {
                    UpdateScore(true);
                }
                else if (GoldenEggTracker.transform.position.y <= -5.3f)
                {
                    UpdateScore(false);
                }
            }
        }
    }

    public void UpdateScore(bool winnerOrLooser)
    {
        int i = 0;
        Debug.Log("Hi");
        if (winnerOrLooser)
        {
            EggRocketManager.points++;
            i = 0;
        }
        else
        {
            EnemyEggRocket.points++;
            i = 1;
        }

        if (EggRocketManager.points >= 5)
        {
            EndGame(true);
        }
        else if (EnemyEggRocket.points >= 5)
        {
            EndGame(false);
        }

        Destroy(GoldenEggTracker);
        GoldenEggTracker = null;
        EnemyEggRocket.GoldenEgg = null;
        if (StartGameManager.gameIsStarted)
        {
            if (i == 0)
            {
                startGameManager.SpawnGoldenEgg(startGameManager.GoldenEgg, players[i].transform.Find("pointOfball").transform.position, new Vector2(0f, 10f));
            }
            else if(i == 1)
            {
                startGameManager.SpawnGoldenEgg(startGameManager.GoldenEgg, players[i].transform.Find("pointOfball").transform.position, new Vector2(0f, -10f));
            }
        }
    }
    public void EndGame(bool who)
    {
        StartGameManager.gameIsStarted = false;
        players[0].SetActive(false);
        players[1].SetActive(false);
      
        if (who)
        {
            points++;
            PointsManager.SetPoint(points);
            startGameManager.uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.endGameField, "You are winner!");
        }
        else
        {
            startGameManager.uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.endGameField, "You are looser!");
        }
        startGameManager.uIManager.ShowAndHide(startGameManager.uIManager.EndGameOBJ, true);
    }
}

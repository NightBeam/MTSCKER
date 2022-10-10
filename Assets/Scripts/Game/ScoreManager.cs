using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int points;
    public GameObject GoldenEggTracker;
    [SerializeField] StartGameManager startGameManager;
    [SerializeField] UIManager uIManager;
    public GameObject[] players;
    public GameObject ExitGameButton;

    public GameObject goalParticle;
    [SerializeField]AudioSource audioSource;

    PointsManager pointsManager;
    private void Awake()
    {
        startGameManager = GetComponent<StartGameManager>(); 
        uIManager = GetComponent<UIManager>();
        audioSource = GetComponent<AudioSource>();
        pointsManager = GetComponent<PointsManager>();
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
        audioSource.Play();
        int i = 0;
        if (winnerOrLooser)
        {
            EggRocketManager.points++;
            i = 0;
            Instantiate(goalParticle, GoldenEggTracker.transform.position, Quaternion.Euler(90f, 0f, 0f));
        }
        else
        {
            EnemyEggRocket.points++;
            i = 1;
            Instantiate(goalParticle, GoldenEggTracker.transform.position, Quaternion.Euler(-90f, 0f, 0f));
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
            Transform pos = players[i].transform.Find("pointOfball").transform;
            if (i == 0)
            {
                startGameManager.SpawnGoldenEgg(startGameManager.GoldenEgg, pos.position, new Vector2(0f, 10f), pos);
            }
            else if(i == 1)
            {
                startGameManager.SpawnGoldenEgg(startGameManager.GoldenEgg, pos.position, new Vector2(0f, -10f), pos);
            }
        }
    }
    public void EndGame(bool who)
    {

        StartGameManager.gameIsStarted = false;
        players[0].SetActive(false);
        players[1].SetActive(false);
        ExitGameButton.SetActive(false);
        if (who)
        {
            points++;
            pointsManager.SetPoint(points);
            uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.endGameField, "Ты выйграл!");
        }
        else
        {
            uIManager.WriteDatasIntoTextFieldFrom(UIManager.ChoisenText.endGameField, "Ты проиграл!");
        }
        uIManager.ShowAndHide(startGameManager.uIManager.EndGameOBJ, true);
    }
}
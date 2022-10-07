using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject eggBall;
    public GameObject eggBallTrecker;
    public bool isBallCreated;
    
    public bool isa;
    private void Start()
    {
        isBallCreated = false;
    }
    private void Update()
    {
        StartGameManager.isStarted = isa;
        scoreText.text = $"{EggRocketManager.points}/{EnemyEggRocket.points}";
        if(StartGameManager.isStarted == true)
        {
            if(isBallCreated == false)
            {
                CreateEggBall();
                isBallCreated = true;
            }
            if (eggBallTrecker != null)
            {
                if(eggBallTrecker.transform.position.y >= 6f)
                {
                    TakePoint(true);
                }
                else if(eggBallTrecker.transform.position.y <= -6f)
                {
                    TakePoint(false); 
                }
            }
        }

    }
    void CreateEggBall()
    {
        eggBallTrecker = Instantiate(eggBall, new Vector3(0f,0f,0f), Quaternion.identity);
        EnemyEggRocket.GoldenEgg = eggBallTrecker;
    }
    void TakePoint(bool whom)
    {
        if (whom)
        {
            EggRocketManager.points++;
        }   
        else
        {
            EnemyEggRocket.points++;
        }
        Destroy(eggBallTrecker);
        eggBallTrecker = null;
        CreateEggBall();
    }
}

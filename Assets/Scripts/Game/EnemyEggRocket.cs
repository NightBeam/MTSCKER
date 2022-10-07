using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEggRocket : MonoBehaviour
{
    [SerializeField] float errorRate;
    [SerializeField] float speed;
    public static GameObject GoldenEgg;

    public static int points;
    void Start()
    {
        points = 0;
       
    }
    void Update()
    {
        if (GoldenEgg != null)
        {
            if (GoldenEgg.transform.position.y > 2f)
            {
                FollowToGoldenEgg();
            }
        }

        transform.position = new Vector2(Limit(), transform.position.y);
    }

    void FollowToGoldenEgg()
    {
        float goldenEggXPos = GoldenEgg.transform.position.x;
        transform.position = Vector2.Lerp(transform.position, new Vector2(goldenEggXPos, transform.position.y), speed * Time.deltaTime );
    }
    float Limit()
    {
        float widthOfWindow = (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0f)).x - errorRate);
        float limit = Mathf.Clamp(transform.position.x, -widthOfWindow, widthOfWindow);
        return limit;
    }
}

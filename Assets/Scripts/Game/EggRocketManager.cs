using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggRocketManager : MonoBehaviour
{
    [SerializeField] float errorRate;
    [SerializeField] float speed;
    public float endPointX;

    public static int points;
    private void Awake()
    {
        points = 0;
        endPointX = 0;
    }
    private void Update()
    {
        MoveToEndPoint();
        transform.position = new Vector2(LimitPosX(), transform.position.y);
    }

    void MoveToEndPoint()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(endPointX, transform.position.y), speed * Time.deltaTime);
    }
    float LimitPosX()
    {
        float widthOfWindow = (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0f)).x - errorRate);
        float limit = Mathf.Clamp(transform.position.x, -widthOfWindow, widthOfWindow);
        return limit; 
    }

}

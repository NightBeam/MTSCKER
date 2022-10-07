using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaterWall : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    public float errorRate;
    private void Start()
    {
        Vector2 verticale = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
        CreateWalls(walls[0],verticale);
    }
    void CreateWalls(GameObject verticaleWall,Vector2 verticalePos)
    {
        Instantiate(verticaleWall, new Vector2(verticalePos.x + errorRate , verticalePos.y), Quaternion.identity);
        Instantiate(verticaleWall, -new Vector2(verticalePos.x + errorRate , verticalePos.y), Quaternion.identity);
    }
}

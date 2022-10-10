using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public User user;
    public  void SetPoint(int value)
    {
        user.points += value;
    }
    public  int GetPoint()
    {
        int points = user.points;
        return points;
    }
}

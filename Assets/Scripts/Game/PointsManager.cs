using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static void SetPoint(int value)
    {
        PlayerPrefs.SetInt("AppPoints", value);
    }
    public static int GetPoint()
    {
        int points = PlayerPrefs.GetInt("AppPoints");
        return points;
    }
}

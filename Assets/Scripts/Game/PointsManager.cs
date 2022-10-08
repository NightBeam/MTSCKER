using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static void SetPoint()
    {
        PlayerPrefs.SetInt("AppPoints", +1);
    }
    public static int GetPoint()
    {
        int points = PlayerPrefs.GetInt("AppPoints");
        return points;
    }
}

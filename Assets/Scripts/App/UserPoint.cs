using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserPoint : MonoBehaviour
{
    public User user;
    public Text text;
    private void Update()
    {
        text.text = Convert.ToString(user.points);
    }
}

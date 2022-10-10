using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SomeUser", menuName = "ScriptableObjects/User", order = 1)]
public class User : ScriptableObject
{
    public string firstName;
    public string lastName;
    public string password;
    public int post;
    public int points;
    public bool authorized;
}

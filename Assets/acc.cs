using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class acc : MonoBehaviour
{
    public Text text; 
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Имя: " + PlayerPrefs.GetString("name") + '\n' + "Фамилия: " + PlayerPrefs.GetString("famili") + '\n' + "Login: " + PlayerPrefs.GetString("login") + '\n' + "Технический стек: " + PlayerPrefs.GetString("technostack") + '\n' + "Информация: " + PlayerPrefs.GetString("info") + '\n' + "Направление: " + PlayerPrefs.GetString("drop") + '\n';
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

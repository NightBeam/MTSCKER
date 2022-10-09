using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sms : MonoBehaviour
{
    public InputField user;
    public Text tt;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        tt.text += "Пользователь: привет"+'\n';
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void send(){
        tt.text += PlayerPrefs.GetString("name") + ": " + user.text + '\n';
        tt.text += "Пользователь: пошли играть!"+'\n';
        button.SetActive(true);
    }
    public void game(){
        SceneManager.LoadScene("EggSmash");
    }
}

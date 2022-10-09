using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PP : MonoBehaviour
{
    public InputField name;
    public InputField famili;
    public InputField login;
    public InputField password;
    public InputField technostack;
    public InputField info;
    public Dropdown drop;
    public GameObject sign;
    public GameObject signUP;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(drop.GetComponent<Dropdown>().options[drop.GetComponent<Dropdown>().value].text);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void regist(){ 
        PlayerPrefs.SetString("name", name.text);
        PlayerPrefs.SetString("famili", famili.text);
        PlayerPrefs.SetString("login", login.text);
        PlayerPrefs.SetString("password", password.text);
        PlayerPrefs.SetString("info", info.text);
        PlayerPrefs.SetString("technostack", technostack.text);
        PlayerPrefs.SetString("drop", drop.GetComponent<Dropdown>().options[drop.GetComponent<Dropdown>().value].text);
        SceneManager.LoadScene("home");
    }
    public void signin(){
        if (PlayerPrefs.HasKey("name")){
			SceneManager.LoadScene("home");
        }
        else{
            sign.SetActive(false);
            signUP.SetActive(true);
        }
    }
    public void signup(){
        /*if (PlayerPrefs.HasKey("name")){
			SceneManager.LoadScene("home");
        }
        else{*/
            sign.SetActive(false);
            signUP.SetActive(true);
        
    }
}

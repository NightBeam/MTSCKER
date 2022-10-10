using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chek : MonoBehaviour
{
    private Instantiateon inst;
    public GameObject cards;
    public GameObject chat;
    public GameObject ivent; 
    public bool ch;
    public float time;
    public int a;

    public User user;
    // Start is called before the first frame update
    void Start()
    {
        inst = FindObjectOfType<Instantiateon>();
        time = Random.Range( 4f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(ch && a==1){
            time -= Time.deltaTime;
            if(time <= 0){
                ch = false;
                inst.num = 1;
                time = Random.Range( 4f, 10f); 
                a = 0;
                cards.SetActive(false);
                ivent.SetActive(true);
            }
        }
    }
    public void gal(){
        ivent.SetActive(false);
        chat.SetActive(true);
        user.searchChat = true;
    }
    public void no(){
        ivent.SetActive(false);
        cards.SetActive(true);
    }
}

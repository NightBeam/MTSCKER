using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsSwaper : MonoBehaviour
{
    public GameObject card_pref;
    public GameObject card;
    public Transform spawnPoint;

    public ToolBarButtonManager toolBarButtonManager;


    public User user;
    private void Start()
    {
        CreateCard();
    }

    public void YesOrNo(bool what)
    {
        if (card != null)
        {
            if (what)
            {
                if (!user.searchChat)
                {
                    MakeChoise("YesCard");
                    Invoke("StartMessage", 1f);
                    user.searchChat = true;
                }
            }
            else
            {
                MakeChoise("NoCard");
            }
        }
    }
    void MakeChoise(string nameOfAnimation)
    {
        card.GetComponent<Animation>().Play(nameOfAnimation);
        card.GetComponent<CardManager>().destroy = true;
        CreateCard();
    }

    public void CreateCard()
    {
        card = Instantiate(card_pref, spawnPoint);
    }

    void StartMessage()
    {
        toolBarButtonManager.OpenChat();
    }
}

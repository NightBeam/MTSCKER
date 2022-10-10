using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiateon : MonoBehaviour
{
    public GameObject[] cardPrefab;
    private secondCard second;
    private SwipeEffect swip;
    private chek che;
    public int num = 1;
    // Start is called before the first frame update
    void InstantiateCard()
    {
        GameObject newCard = Instantiate(cardPrefab[Random.Range(0,5)], transform, false);
        newCard.transform.SetAsFirstSibling();
    }

    // Update is called once per frame
    void Update()
    {
        che = FindObjectOfType<chek>();
        if(transform.childCount < 2)
        {
            if(num==0){
                che.a=1;
            }       
            num-=1;    
            InstantiateCard();
        }   
    }
}

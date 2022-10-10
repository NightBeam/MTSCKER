using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondCard : MonoBehaviour
{
    private SwipeEffect swipeEffect;
    private GameObject _firstCard;
    private chek che;
    // Start is called before the first frame update
    void Start()
    {
        swipeEffect = FindObjectOfType<SwipeEffect>();
        che = FindObjectOfType<chek>();
        _firstCard = swipeEffect.gameObject;
        swipeEffect.cardMoved += CardMovedFront;
        transform.localScale = new Vector3(8.8f, 13.3f, 8.8f);

    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = _firstCard.transform.localPosition.x;
        if (Mathf.Abs(distanceMoved) > 0)
        {
            float step = Mathf.SmoothStep(8.8f,9,Mathf.Abs(distanceMoved)/(Screen.width / 2));
            float step1 = Mathf.SmoothStep(13.3f,13.5f,Mathf.Abs(distanceMoved)/(Screen.width / 2));
            transform.localScale = new Vector3(step, step1, step);
        }
    }
    void CardMovedFront()
    {
        gameObject.AddComponent<SwipeEffect>();
        Destroy(this);
    }
}

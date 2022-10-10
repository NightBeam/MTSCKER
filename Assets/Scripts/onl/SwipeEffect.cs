using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeEffect : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Vector3 _initialPosition;
    private float _distanceMoved;
    private bool _swipeLeft;

    public event Action cardMoved;
    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x+eventData.delta.x,transform.localPosition.y);

        if(transform.localPosition.x - _initialPosition.x > 0)
        {
            transform.localEulerAngles = new Vector3(0,0,Mathf.LerpAngle(0,-30,(_initialPosition.x + transform.localPosition.x)/(Screen.width/2)));
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, 30, (_initialPosition.x - transform.localPosition.x) / (Screen.width / 2)));
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = transform.localPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPosition.x);
        if(_distanceMoved<0.4*Screen.width)
        {
            transform.localPosition = _initialPosition;
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            if (transform.localPosition.x > _initialPosition.x)
            {
                _swipeLeft = false;
                
            }
            else
            {
                _swipeLeft = true;
            }
            cardMoved?.Invoke();
            StartCoroutine(MovedCard());
        }
    }

    private IEnumerator MovedCard()
    {
        float time = 0;
        if (_swipeLeft)
        {
            while (GetComponent<Image>().color != new Color(255, 0, 0, 0))
            {
                time += Time.deltaTime;
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x - Screen.width, time), transform.localPosition.y, 0);
                GetComponent<Image>().color = new Color(255, 0, 0, Mathf.SmoothStep(1, 0, 4 * time));
                yield return null;
            }
        }
        else
        {
            while (GetComponent<Image>().color != new Color(0, 166, 0, 0))
            {
                time += Time.deltaTime;
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                        transform.localPosition.x + Screen.width, time), transform.localPosition.y, 0);
                GetComponent<Image>().color = new Color(0, 166, 0, Mathf.SmoothStep(1, 0, 4 * time));
                yield return null;
            }
        }
        //while (GetComponent<Image>().color != new Color(1, 1, 1, 0))
        //{
        //    time += Time.deltaTime;
        //    if (_swipeLeft)
        //    {
        //        transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
        //            transform.localPosition.x-Screen.width,time),transform.localPosition.y,0);
        //       GetComponent<Image>().color = new Color(75, 255, 0, Mathf.SmoothStep(1, 0, 4 * time)); 
        //    }
        //    else
        //    {
        //        transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
        //            transform.localPosition.x+Screen.width,time),transform.localPosition.y,0);
        //        GetComponent<Image>().color = new Color(255, 26, 0, Mathf.SmoothStep(1,0,4*time));
        //    }
        //    GetComponent<Image>().color = new Color(1, 1, 1, Mathf.SmoothStep(1, 0, 4 * time));
        //    yield return null;
        //}
        Destroy(gameObject);
    }
}

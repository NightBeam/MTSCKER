using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldEggManager : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public bool isWent;
    public Vector2 initialDirection;

    private void Start()
    {
        isWent = false;
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!isWent)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    rb2D.velocity = initialDirection;
                    isWent = true;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2D.velocity = Vector2.Reflect(rb2D.velocity, collision.contacts[0].normal);
    }
}

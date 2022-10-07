using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldEggManager : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(Random.Range(1f,10f), 10f);
    }
    private void Update()
    {
        Vector2 dir = rb2D.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2D.velocity = Vector2.Reflect(rb2D.velocity, collision.contacts[0].normal);
    }
}

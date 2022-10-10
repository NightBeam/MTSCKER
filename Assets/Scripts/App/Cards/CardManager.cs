using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    Animation anim;
    public bool destroy;
    void Start()
    {
        destroy = false;
        anim = GetComponent<Animation>();
        anim.Play("UpScaleCard");
    }
    private void Update()
    {
        if (destroy)
        {
            Invoke("DestroyGameOBJ", 0.35f);
        }
    }
    private void DestroyGameOBJ()
    {
        Destroy(gameObject);
    }

}

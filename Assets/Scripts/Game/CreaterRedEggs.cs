using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaterRedEggs : MonoBehaviour
{
    public GameObject redEgg;
    public GameObject bomb;
    [SerializeField] int countRedEgg;
    [SerializeField] float margin;
    [SerializeField] int min;
    [SerializeField] int max;
    private void Start()
    {
        countRedEgg = Random.Range(min, max);
    }
    void CreteRedEggs()
    {
        foreach(int i in new int[countRedEgg])
        {

        }
    }
    
}

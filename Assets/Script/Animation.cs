using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField]
    GameObject start;
    [SerializeField]
    GameObject eggi;
    [SerializeField]
    GameObject retry;

    int timer;
    void Start()
    {
        eggi.SetActive(false);
        retry.SetActive(false);
        timer = 90;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.is_Goal)
        {
            retry.SetActive(true);
            eggi.SetActive(true);
        }

        timer--;
        if (timer >= 45) 
        {
            start.SetActive(false);
        }
        else
        {
            start.SetActive(true);
        }
        if (timer < 0)
        {
            timer = 90;
        }
    }
}

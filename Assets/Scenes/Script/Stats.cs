using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    int jumpNum;
    
    private int jn;

    public int JumpNum
    {
        get { return jn; }
        set { jn = value;}
    }

    void Start()
    {
        jn = jumpNum;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Floor")
        {
            jn = jumpNum;
            Debug.Log("ÇΩÇ‹Ç≤Ç™è∞Ç∆ìñÇΩÇ¡ÇΩ");
        }
    }
}

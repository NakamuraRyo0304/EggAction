using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    [SerializeField] GameObject egg;
    [SerializeField] float jumpPower = 100;

    void Start()
    {
        rigidbody = egg.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(transform.right * 0.5f);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(transform.right * -0.5f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (egg.GetComponent<Stats>().JumpNum < 0) return;
            rigidbody.AddForce(transform.up * jumpPower);
            egg.GetComponent<Stats>().JumpNum--;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower = 10;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(moveSpeed, 0.0f));
            // âEå¸Ç´Ç…Ç∑ÇÈ
            transform.localScale = Vector2.one;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-moveSpeed,0.0f));
            // ç∂å¸Ç´Ç…Ç∑ÇÈ
            transform.localScale = new Vector2(-1, 1);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(transform.up * jumpPower);
        }
    }
}

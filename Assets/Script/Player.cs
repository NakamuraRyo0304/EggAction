using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    bool is_Goal;

    void Start()
    {
        transform.parent = null;
        is_Goal = false;

        // �X�^�[�g������d�͂͊O��
        transform.GetComponent<Rigidbody2D>().Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // �X���[�v����Ȃ���Ώ������Ȃ�
            if (!transform.GetComponent<Rigidbody2D>().IsSleeping()) return;

            // �X���[�v����
            transform.GetComponent<Rigidbody2D>().WakeUp();
        }

        if(is_Goal)
        {
            transform.position = GameObject.FindGameObjectWithTag("Goal").transform.position;
            // ��]�ʂ����Z�b�g
            transform.rotation = Quaternion.identity;
            // ���W�b�h�{�f�B���O��
            transform.GetComponent<Rigidbody2D>().Sleep();
        }

        if (transform.position.y < -10.0f)
        {
            SceneManager.LoadScene("PlayScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Goal")
        {
            is_Goal = true;
        }
    }
}

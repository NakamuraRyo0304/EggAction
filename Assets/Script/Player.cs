using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject Spawn;

    public static bool is_Goal;
    static bool is_PlayMode;

    int timer;

    void Start()
    {
        Canvas.SetActive(true);
        transform.GetComponent<Rigidbody2D>().Sleep();
        transform.parent = null;
        is_Goal = false;
        is_PlayMode = false;

        timer = 600;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイモードじゃなければリターンする
        if (!is_PlayMode) return;
        
        // タイマースタート処理
        timer--;
        if (timer < 0) timer = 0;
        if (timer > 0)
        {
            transform.GetComponent<Rigidbody2D>().Sleep();
            transform.position = Spawn.transform.position;
            return;
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().WakeUp();
        }

        if (is_Goal)
        {
            // 移動量をなくす
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            // 回転量をリセット
            transform.rotation = Quaternion.identity;
            // リジッドボディを外す
            transform.GetComponent<Rigidbody2D>().Sleep();
        }

        // 死ぬかスペースを押したらリトライ
        if (transform.position.y < -10.0f ||
            Input.GetKeyDown(KeyCode.Space))
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

    public void StartGame()
    {
        is_PlayMode = true;
        Canvas.SetActive(false);
    }

    public void ReStart()
    {
        SceneManager.LoadScene("PlayScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

    [SerializeField] GameObject linePrefab;
    [SerializeField] float lineLength = 0.2f;
    [SerializeField] float lineWidth = 0.1f;
    [SerializeField] float lineCanDrawTime = 5;
    float timer;

    private Vector3 touchPos;

    void Start()
    {
        touchPos = Vector3.zero;
        timer = 0;
    }

    void Update()
    {
        // フレームレートを絶対に下げない
        Application.targetFrameRate = 60;

        // 描画処理
        Drawing();
     
    }

    void Drawing()
    {
        // 時間を超過したら処理しない
        if (timer >= lineCanDrawTime * 60) return;

        if (Input.GetMouseButtonDown(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0;
        }

        if (Input.GetMouseButton(0))
        {
            // 時間制限
            if (timer < lineCanDrawTime * 60)
            {
                timer++;
                Debug.Log(timer);
            }

            Vector3 startPos = touchPos;
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;

            if ((endPos - startPos).magnitude > lineLength)
            {
                GameObject obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                obj.transform.position = (startPos + endPos) / 2;
                obj.transform.right = (endPos - startPos).normalized;

                obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);

                obj.transform.parent = this.transform;

                touchPos = endPos;
            }
        }
    }
}

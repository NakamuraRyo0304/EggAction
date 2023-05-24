using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] Transform target;
    public float dampTime = 0.15f;

    private Vector3 m_velocity;

    private void Start()
    {
        m_velocity = Vector3.zero;
    }

    private void Update()
    {
        // カメラの座標を取得
        Vector3 selfPosition = transform.position;

        // 追従対象のオブジェクトの位置を取得
        Vector3 targetPosition = target.position;
        
        // カメラの注視点を取得
        Vector3 point = camera.WorldToViewportPoint(targetPosition);
        
        // カメラと対象の距離を計算
        Vector3 delta = targetPosition - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = selfPosition + delta;

        // ポジションをラープ移動させる
        transform.position = Vector3.SmoothDamp(selfPosition, destination, ref m_velocity, dampTime);
    }
}

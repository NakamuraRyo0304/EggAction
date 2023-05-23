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
        // �J�����̍��W���擾
        Vector3 selfPosition = transform.position;

        // �Ǐ]�Ώۂ̃I�u�W�F�N�g�̈ʒu���擾
        Vector3 targetPosition = target.position;
        
        // �J�����̒����_���擾
        Vector3 point = camera.WorldToViewportPoint(targetPosition);
        
        // �J�����ƑΏۂ̋������v�Z
        Vector3 delta = targetPosition - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = selfPosition + delta;

        // �|�W�V���������[�v�ړ�������
        transform.position = Vector3.SmoothDamp(selfPosition, destination, ref m_velocity, dampTime);
    }
}

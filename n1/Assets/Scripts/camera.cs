using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform BTR;  
    public float distance = 5.0f;  // ���������� ������ ��� ������������
    public float height = 3.0f;  // ������ ������
    public float smoothSpeed = 0.5f;  // �������� �������� ������

    private Vector3 offset;  // ���������� �� ������ �� ��� �� �������

    void Start()
    {
        offset = new Vector3(0, height, -distance);
    }

    void FixedUpdate() // �������� ������, ���� ������ �������)
    {
        // ������������ �������, ���� ������ ��������� ������
        Vector3 desiredPosition = BTR.position + offset;

        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(BTR);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform BTR;  
    public float distance = 5.0f;  // Расстояние камеры при передвижении
    public float height = 3.0f;  // Высота камеры
    public float smoothSpeed = 0.5f;  // Скорость движения камеры

    private Vector3 offset;  // Расстояние от камеры до БТР по вектору

    void Start()
    {
        offset = new Vector3(0, height, -distance);
    }

    void FixedUpdate() // нагрузка больше, зато камера плавнее)
    {
        // Рассчитываем позицию, куда должна двигаться камера
        Vector3 desiredPosition = BTR.position + offset;

        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(BTR);
    }
}

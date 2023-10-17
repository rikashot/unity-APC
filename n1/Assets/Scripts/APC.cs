using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class APC : MonoBehaviour
{  // ���� �����
    public Transform modelFLWheel;
    public Transform modelFRWheel;
    public Transform modelMLWheel;
    public Transform modelMRWheel;
    public Transform modelBLWheel;
    public Transform modelBRWheel;
    
    // ��������� ������
    public WheelCollider colliderFLWheel;
    public WheelCollider colliderFRWheel;
    public WheelCollider colliderMLWheel;
    public WheelCollider colliderMRWheel;
    public WheelCollider colliderBLWheel;
    public WheelCollider colliderBRWheel;

    public float force; // ��������
    public float Angle; // ���� �������� �����

    private void FixedUpdate()
    {
        colliderFLWheel.motorTorque = Input.GetAxis("Vertical") * force;
        colliderFRWheel.motorTorque = Input.GetAxis("Vertical") * force;
        colliderMLWheel.motorTorque = Input.GetAxis("Vertical") * force;
        colliderMRWheel.motorTorque = Input.GetAxis("Vertical") * force;
        colliderBLWheel.motorTorque = Input.GetAxis("Vertical") * force;
        colliderBRWheel.motorTorque = Input.GetAxis("Vertical") * force;

        colliderFLWheel.steerAngle = Angle * Input.GetAxis("Horizontal");
        colliderFRWheel.steerAngle = Angle * Input.GetAxis("Horizontal");
        // ������� ������ ����� � ������ �������
        colliderBLWheel.steerAngle = - Angle * Input.GetAxis("Horizontal");
        colliderBRWheel.steerAngle = - Angle * Input.GetAxis("Horizontal");

        /// ���������� �����
        RotWheels(colliderFLWheel, modelFLWheel);
        RotWheels(colliderFRWheel, modelFRWheel);
        RotWheels(colliderMLWheel, modelMLWheel);
        RotWheels(colliderMRWheel, modelMRWheel);
        RotWheels(colliderBLWheel, modelBLWheel);
        RotWheels(colliderBRWheel, modelBRWheel);
    }

    // ����� �������� �����
    private void RotWheels(WheelCollider collider, Transform transform)
    {
        Vector3 position; // �������
        Quaternion rotation; // �������
        collider.GetWorldPose(out position, out rotation);
        transform.position = position;
        transform.rotation = rotation;
    }

}

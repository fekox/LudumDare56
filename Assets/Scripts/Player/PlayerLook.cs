using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Mouse")]
    [SerializeField] private float mouseSensitivity = 900f;

    [SerializeField] private Transform playerBody;

    [SerializeField] private float maxRotation = -90;
    [SerializeField] private float minRotation = 90;

    private float XRotation;

    public void LookLogic() 
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, minRotation, maxRotation);

        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

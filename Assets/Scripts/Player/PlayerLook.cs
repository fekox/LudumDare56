using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Mouse References")]
    [SerializeField] private Transform playerBody;

    [Header("Mouse Setup")]

    [SerializeField] private float mouseSensitivity = 900f;
    [SerializeField] private float minLookUp = -90;
    [SerializeField] private float maxLookUp = 90;

    private float XRotation;

    private Vector2 mouseInput;

    public void LookLogic() 
    {
        mouseInput = new Vector2(Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime, Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime);

        XRotation -= mouseInput.y;
        XRotation = Mathf.Clamp(XRotation, minLookUp, maxLookUp);

        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseInput.x);
    }
}

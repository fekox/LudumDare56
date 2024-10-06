using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    [Header("Crouch Setup")]
    [SerializeField] private float crouch;

    [SerializeField] private float startScale;

    [SerializeField] private bool isCrouch;

    [Header("Reference Player Rigidbody")]
    [SerializeField] private Rigidbody playerRigidbody;

    private void Start()
    {
        if (playerRigidbody == null)
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
    }

    public void CrouchLogic() 
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            transform.localScale = new Vector3(transform.localScale.x, crouch, transform.localScale.z);
            playerRigidbody.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            isCrouch = true;
        }

        if (Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(transform.localScale.x, startScale, transform.localScale.z);
            isCrouch = false;
        }
    }

    public bool GetIsCrouch() 
    {
        return isCrouch;
    }
}

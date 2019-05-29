using UnityEngine;

public class ClickToMove : MonoBehaviour
{

    public float speed = 5f;
    public float jumpHeight = 8f;
    public float gravity = 20f;
    //public float DashDistance = 5f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = Vector3.zero;
            if (Input.GetButton("Fire1"))
            {
                moveDirection = new Vector3(Input.mousePosition.x - Screen.width / 2, 0.0f, Input.mousePosition.y - Screen.height / 2).normalized;
                moveDirection *= speed;
            }
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpHeight;
            }

        }
        moveDirection.y -= gravity * Time.deltaTime;
        
        characterController.Move(moveDirection * Time.deltaTime);
    }
}

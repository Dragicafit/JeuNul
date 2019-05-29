using System;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public float walk = 0.5f;
    public float run = 1f;
    public float jumpHeight = 0.1f;
    //public float groundDistance = 0.1f;
    //public float DashDistance = 5f;

    private Rigidbody body;
    private float radius;
    private bool isGrounded;
    //private LesBeauxPiedsDuCube lbpdc;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        radius = GetComponent<CapsuleCollider>().radius;
        /*
        lbpdc = GetComponentInChildren<LesBeauxPiedsDuCube>();
        if (lbpdc == null)
            throw new System.Exception("Tu peux pas marcher sans pieds");
        */
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.position.y < transform.position.y + radius)
            isGrounded = true;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.GetContact(0).point.y < transform.position.y + radius)
            isGrounded = true;
    }

    void FixedUpdate()
    {
        //bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundDistance);
        //bool IsGrounded = false;// lbpdc.IsGrounded();
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetButton("Fire1"))
        {
            Vector3 move = new Vector3(Input.mousePosition.x - Screen.width / 2, 0.0f, Input.mousePosition.y - Screen.height / 2);
            moveDirection = move.normalized;
            moveDirection *= move.magnitude > 75 ? run : walk;
            body.MovePosition(body.position + moveDirection * Time.fixedDeltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //body.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            body.velocity = new Vector3(body.velocity.x, jumpHeight * -2f * Physics.gravity.y, body.velocity.z);
        }

        /*
        if (Input.GetButtonDown("Dash"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * body.drag + 1)) / -Time.deltaTime)));
            body.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
        */
        isGrounded = false;
    }
}

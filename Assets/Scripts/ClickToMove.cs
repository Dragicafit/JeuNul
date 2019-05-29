using UnityEngine;

public class ClickToMove : MonoBehaviour
{

    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float Distanceto;
    //public float DashDistance = 5f;

    private Rigidbody body;
    private Collider col;
    private Vie pv;
    //private LesBeauxPiedsDuCube lbpdc;
    void Start()
    {
        pv = GetComponent<Vie>();
        body = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        /*
        lbpdc = GetComponentInChildren<LesBeauxPiedsDuCube>();
        if (lbpdc == null)
            throw new System.Exception("Tu peux pas marcher sans pieds");
        */
    }

    void FixedUpdate()
    {
        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, GroundDistance);
        //bool IsGrounded = false;// lbpdc.IsGrounded();

        Vector3 moveDirection = Vector3.zero;
        Vector3 forward = Vector3.zero;
        if (Input.GetButton("Fire1"))
        {
            moveDirection = new Vector3(Input.mousePosition.x - Screen.width / 2, 0.0f, Input.mousePosition.y - Screen.height / 2).normalized;
            body.MovePosition(body.position + moveDirection * Speed * Time.fixedDeltaTime);
            forward = new Vector3(Input.mousePosition.x - Screen.width / 2, 0, Input.mousePosition.y - Screen.height / 2);
            Distanceto = Vector3.Distance(forward, body.position);
        }
        else
            Distanceto = 0;

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        /*
        if (Input.GetButtonDown("Dash"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * body.drag + 1)) / -Time.deltaTime)));
            body.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
        */
    }
}

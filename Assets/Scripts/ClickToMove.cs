using UnityEngine;

public class ClickToMove : MonoBehaviour
{

    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;

    private Rigidbody body;
    private Vector3 input;
    //private LesBeauxPiedsDuCube lbpdc;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        /*
        lbpdc = GetComponentInChildren<LesBeauxPiedsDuCube>();
        if (lbpdc == null)
            throw new System.Exception("Tu peux pas marcher sans pieds");
        */
    }

    void Update()
    {
        
        float DisstanceToTheGround = GetComponent<Collider>().bounds.extents.y;
        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, DisstanceToTheGround + GroundDistance);
        

        //bool IsGrounded = false;// lbpdc.IsGrounded();

        input = new Vector3(Input.mousePosition.x - Screen.width / 2, 0.0f, Input.mousePosition.y - Screen.height / 2).normalized;
        if (input != Vector3.zero)
            transform.forward = input;
        
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

    void FixedUpdate()
    {
        if(Input.GetButton("Fire1"))
            body.MovePosition(body.position + input * Speed * Time.fixedDeltaTime);
    }

}

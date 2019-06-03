using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    private WithHp whp;
    private StatusList sl;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        whp = GetComponent<WithHp>();
        sl = GetComponent<StatusList>();
        CheckNull();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.y > 10)
        {
            whp.Fall(collision.relativeVelocity.y);
        }
        
    }

    void CheckNull()
    {
        if (!rb)
            throw new Exception("A player should have a rigid body");
        if (!whp)
            throw new Exception("A player should have hp");
    }
}

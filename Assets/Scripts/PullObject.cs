using System;
using UnityEngine;

public class PullObject : MonoBehaviour
{

    public float pullForce = 1;
    public float pullRadius = 10;
    public float timeBeforePull = 5;

    private float start;
    private Rigidbody rb;
    
    void Start()
    {
        start = Time.time;
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (Time.time - start > timeBeforePull)
        {
            foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius))
            {
                Rigidbody rb2 = collider.GetComponent<Rigidbody>();
                if (rb2 == null)
                {
                    continue;
                }

                if (collider.gameObject == gameObject)
                {
                    continue;
                }

                Vector3 forceDirection = transform.position - collider.transform.position;
                float d = forceDirection.magnitude;
                float f = pullForce * rb.mass * rb2.mass / (float)Math.Pow(d, 2);
                rb2.AddForce(forceDirection.normalized * f * Time.fixedDeltaTime);
            }
        }
    }


}

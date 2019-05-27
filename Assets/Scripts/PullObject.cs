using System;
using UnityEngine;

public class PullObject : MonoBehaviour
{

    public float pullRadius = 10;
    public float timeBeforePull = 5;
    private float start;
    
    void Start()
    {
        start = Time.time;
    }
    
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        if (Time.time - start > timeBeforePull)
        {
            foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius))
            {
                Vector3 forceDirection = transform.position - collider.transform.position;
                float d = forceDirection.magnitude;
                if (collider.gameObject != gameObject && collider.GetComponent<Rigidbody>() != null)
                {
                    float f = collider.GetComponent<Rigidbody>().mass * gameObject.GetComponent<Rigidbody>().mass / (float)Math.Pow(d, 2);
                    collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * f * Time.fixedDeltaTime);
                }
            }
        }
    }


}

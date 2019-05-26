using UnityEngine;

public class PullObject : MonoBehaviour
{

    public float pullRadius = 2;
    public float pullForce = 1;
    public float timeBeforePull = 5;
    private float start;

    // Start is called before the first frame update
    void Start()
    {
        start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        if (Time.time - start > timeBeforePull)
        {
            foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius))
            {
                // calculate direction from target to me
                Vector3 forceDirection = transform.position - collider.transform.position;

                // apply force on target towards me
                if (collider.GetComponent<Rigidbody>() != null)
                    collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);
            }
        }
    }


}

using System;
using UnityEngine;

public class OndeDeChoc : AbstractSpell
{
    public float pushForce = 50000f;
    private SphereCollider sphereCollider;

    public override void Start()
    {
        base.Start();
        sphereCollider = GetComponent<SphereCollider>();
    }

    protected override void CloneObject(Transform t)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 spawnPoint = hit.point;
            spawnPoint.y += 0.6f;
            Instantiate(gameObject, spawnPoint, t.rotation);
        }
        else
        {
            throw new Exception("Raycast dans le vide");
        }
    }

    protected override void AddForce()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        Rigidbody rb2 = col.GetComponent<Rigidbody>();
        if (rb2 == null)
        {
            return;
        }
        Vector3 radius = new Vector3(sphereCollider.radius, sphereCollider.radius, sphereCollider.radius);
        Vector3 forceDirection = col.transform.position - transform.position;
        radius.x *= forceDirection.x > 0 ? 1 : -1;
        radius.y *= forceDirection.y > 0 ? 1 : -1;
        radius.z *= forceDirection.z > 0 ? 1 : -1;
        forceDirection = radius - forceDirection;

        rb2.AddForce(forceDirection * pushForce * Time.fixedDeltaTime);
    }
}

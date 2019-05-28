using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpell : Detruisable
{ 
    public float Cooldown = 1f;
    public float Speed = 100f;
    public List<string> Key;

    protected float LastUse = 0f;
    protected Rigidbody body;

    public void Reset_cooldown()
    {
        LastUse = 0.0f;
    }

    void Start()
    {
        body = GetComponent<Rigidbody>();
        AddForce();
        DestroyObj();
    }

    public void CreateProjectile(Transform t)
    {
        if (Time.time - Cooldown > LastUse)
        {
            CloneObject(t);
            LastUse = Time.time;
        }
    }

    protected virtual void CloneObject(Transform t)
    {
        Instantiate(gameObject, t.position + t.forward * 2, t.rotation);
    }

    protected virtual void AddForce()
    {
        body.AddRelativeForce(Vector3.forward * Speed);
    }

    protected virtual void DestroyObj()
    {
        GetComponent<Detruisable>().DestroyObjectDelayed();
    }

}
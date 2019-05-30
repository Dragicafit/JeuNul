using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpell : Detruisable
{
    public float cooldown = 1f;
    public float speed = 100f;
    public List<int> key;

    protected float lastUse = 0f;
    protected Rigidbody body;

    public void Reset_cooldown()
    {
        lastUse = 0.0f;
    }

    public virtual void Start()
    {
        body = GetComponent<Rigidbody>();
        AddForce();
        DestroyObj();
    }

    public void CreateProjectile(Transform t)
    {
        if (Time.time - cooldown > lastUse)
        {
            CloneObject(t);
            lastUse = Time.time;
        }
    }

    protected virtual void CloneObject(Transform t)
    {
        Instantiate(gameObject, t.position + t.forward * 2 + Vector3.up*0.7f, t.rotation);
    }

    protected virtual void AddForce()
    {
        body.AddRelativeForce(Vector3.forward * speed);
    }

    protected virtual void DestroyObj()
    {
        GetComponent<Detruisable>().DestroyObjectDelayed();
    }

}
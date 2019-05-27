using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpell : MonoBehaviour
{ 
    public float Cooldown = 1f;
    public float Speed = 100f;
    public List<string> Key;
    protected float LastUse = 0f;

    public void Reset_cooldown()
    {
        LastUse = 0.0f;
    }

    public void CreateProjectile(Transform t)
    {
        if (Time.time - Cooldown > LastUse)
        {
            GameObject clone = CloneObject(t);
            AddForce(clone);
            DestroyObj(clone);
            LastUse = Time.time;
        }
    }

    protected virtual GameObject CloneObject(Transform t)
    {
        GameObject clone = Instantiate(gameObject, t.position + t.forward * 2, t.rotation);
        return clone;
    }

    protected virtual void AddForce(GameObject clone)
    {
        clone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed);
    }

    protected virtual void DestroyObj(GameObject clone)
    {
        clone.GetComponent<Projectile>().DestroyObjectDelayed();
    }

}
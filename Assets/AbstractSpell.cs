using UnityEngine;

public abstract class AbstractSpell : MonoBehaviour
{ 
    public float Cooldown = 1f;
    public float Speed = 100f;
    public string Key;
    protected float LastUse = 0f;

    public void reset_cooldown()
    {
        LastUse = 0.0f;
    }

    public void createProjectile(Transform t)
    {
        if (Time.time - Cooldown > LastUse)
        {
            GameObject clone = cloneObject(t);
            addForce(clone);
            destroyObj(clone);
            LastUse = Time.time;
        }
    }

    protected virtual GameObject cloneObject(Transform t)
    {
        GameObject clone = Instantiate(gameObject, t.position + t.forward * 2, t.rotation);
        return clone;
    }

    protected virtual void addForce(GameObject clone)
    {
        clone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed);
    }

    protected virtual void destroyObj(GameObject clone)
    {
        clone.GetComponent<Projectile>().DestroyObjectDelayed();
    }

}
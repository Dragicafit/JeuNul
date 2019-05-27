using UnityEngine;

public class BlackHole : AbstractSpell
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.GetComponent<Rigidbody>() != null)
            Destroy(col.gameObject);
    }

    /*
    protected override void addForce()
    {
        transform.Translate(Vector3.forward * Speed);
    }
    */

}

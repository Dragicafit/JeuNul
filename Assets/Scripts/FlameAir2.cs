using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAir2 : AbstractSpell
{
    protected override void AddForce()
    {
    }

    protected override void DestroyObj()
    {
    }

    protected override void CloneObject(Transform t)
    {
        GameObject parent = GameObject.FindWithTag("Player");
        GameObject g = Instantiate(gameObject, parent.transform);
        g.transform.localPosition = new Vector3(0, 1, 0.7f);
        //g.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            var em = GetComponent<ParticleSystem>().emission;
            em.enabled = false;

            var em2 = transform.GetChild(0).GetComponent<ParticleSystem>().emission;
            em2.enabled = false;

            GetComponent<Detruisable>().DestroyObjectDelayed();
        }
    }
}

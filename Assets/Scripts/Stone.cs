using System;
using UnityEngine;

public class Stone : AbstractSpell
{
    
    protected override void CloneObject(Transform t)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 spawnPoint = hit.point;
            spawnPoint.y = 10;
            Instantiate(gameObject, spawnPoint, t.rotation);
        }
        else
        {
            throw new Exception("Raycast dans le vide");
        }
    }

    protected override void AddForce()
    {
        body.AddRelativeForce(Vector3.down * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Detruisable>().DestroyGameObject();
    }

    protected override void DestroyObj()
    {
    }
}

using System;
using UnityEngine;

public class Stone : AbstractSpell
{
    
    protected override GameObject CloneObject(Transform t)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 spawnPoint = hit.point;
            spawnPoint.y = 100;
            return Instantiate(gameObject, spawnPoint, t.rotation);
        }
        throw new Exception("Raycast dans le vide");
    }

    protected override void AddForce(GameObject clone)
    {
        clone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * -Speed);
    }

}

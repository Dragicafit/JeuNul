using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesBeauxPiedsDuCube : MonoBehaviour
{

    private bool IsItReallyGrounded = false;

    void OnTriggerEnter(Collider collision)
    {
        IsItReallyGrounded = true;
    }

    void OnTriggerStay(Collider collision)
    {
        IsItReallyGrounded = true;
    }

    void OnTriggerExit(Collider collision)
    {
        IsItReallyGrounded = false;
    }

    public bool IsGrounded()
    {
        return IsItReallyGrounded;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesBeauxPiedsDuCube : MonoBehaviour
{

    private bool IsItReallyGrounded = false;

    void OnTriggerEnter(Collider other)
    {
        IsItReallyGrounded = true;
    }

    void OnTriggerStay(Collider other)
    {
        IsItReallyGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        IsItReallyGrounded = false;
    }

    public bool IsGrounded()
    {
        return IsItReallyGrounded;
    }

}

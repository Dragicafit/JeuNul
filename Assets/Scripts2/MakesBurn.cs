using UnityEngine;
using System.Collections;

public class MakesBurn : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        StatusList sl = collision.gameObject.GetComponent<StatusList>();
        if (!sl)
        {
            return;
        }
        sl.AddStatus(new Burn(collision.gameObject, 5f));
    }

}

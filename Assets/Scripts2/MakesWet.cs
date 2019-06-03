using UnityEngine;
using UnityEditor;

public class MakesWet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        StatusList sl = other.GetComponent<StatusList>();
        if (!sl)
        {
            return;
        }
        sl.AddStatus(new Wet(other.gameObject, 5f));
    }

    private void OnTriggerStay(Collider other)
    {
        StatusList sl = other.GetComponent<StatusList>();
        if (!sl)
        {
            return;
        }
        sl.AddStatus(new Wet(other.gameObject, 5f));
    }

}
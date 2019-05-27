using UnityEngine;

public class Detruisable : MonoBehaviour
{

    public int delayBeforeDestroy = 5;

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void DestroyScriptInstance()
    {
        // Removes this script instance from the game object
        Destroy(this);
    }

    public void DestroyComponent()
    {
        // Removes the rigidbody from the game object
        Destroy(GetComponent<Rigidbody>());
    }

    public void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, delayBeforeDestroy);
    }

}

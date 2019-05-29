using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie : MonoBehaviour
{
    public float viemax = 180;
    public float vie = 180;

    // Update is called once per frame
    void Update()
    {
        if (vie < 0)
            Destroy(gameObject, 5);
    }
}

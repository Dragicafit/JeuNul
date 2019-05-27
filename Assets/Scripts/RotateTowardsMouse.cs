using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.mousePosition.x - Screen.width / 2;
        float y = Input.mousePosition.y - Screen.height / 2;
        float angle = 90 - Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,angle,0));

    }
}

using UnityEngine;
using System.Collections;

public class LockCam : MonoBehaviour
{

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - GameObject.FindWithTag("Player").transform.position;
    }

    void LateUpdate()
    {
        transform.position = GameObject.FindWithTag("Player").transform.position + offset;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    private float Speed = 1f;

    private Rigidbody npc;
    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        Vector3 position = GameObject.FindWithTag("Player").transform.position;
        moveDirection = new Vector3( position.x - npc.position.x, position.y - npc.position.y, position.z - npc.position.z).normalized;
        transform.forward = new Vector3(position.x - npc.position.x, 0, position.z - npc.position.z);
        npc.MovePosition(npc.position + moveDirection * Speed * Time.fixedDeltaTime);
    }
}

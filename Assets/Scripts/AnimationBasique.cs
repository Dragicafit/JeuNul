﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBasique : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        anim.SetBool("Walk", Input.GetButton("Fire1"));
    }
}

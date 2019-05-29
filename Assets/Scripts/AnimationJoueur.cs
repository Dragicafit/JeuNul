using UnityEngine;

public class AnimationJoueur : AnimationBasique
{
    void Update()
    {
        anim.SetBool("Walk", Input.GetButton("Fire1"));
        
    }
}

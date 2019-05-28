using UnityEngine;

public class AnimationPnj : AnimationBasique
{
    void Update()
    {
        float time = Time.time % 5;
        anim.SetBool("Walk", time<2);
    }
}

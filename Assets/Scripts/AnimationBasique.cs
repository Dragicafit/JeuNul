using UnityEngine;

public class AnimationBasique : MonoBehaviour
{
    protected Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
}

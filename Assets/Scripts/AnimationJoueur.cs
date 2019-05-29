using UnityEngine;

public class AnimationJoueur : AnimationBasique
{
    private Vie pv;

    protected override void Start()
    {
        base.Start();
        pv = GetComponent<Vie>();
    }

    void Update()
    {
        anim.SetBool("Mort", pv.vie < 1);
        anim.SetBool("Walk", Input.GetButton("Fire1"));       
    }
}

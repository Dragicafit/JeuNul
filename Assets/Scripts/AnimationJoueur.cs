using UnityEngine;

public class AnimationJoueur : AnimationBasique
{

    private ClickToMove Info;
    private Vie pv;

    protected override void Start()
    {
        base.Start();
        Info = GetComponent<ClickToMove>();
        pv = GetComponent<Vie>();
    }

    void Update()
    {
        if (Info.Distanceto > 100)
        {
            Info.Speed = 15f;
            anim.SetBool("Walk", false);
            anim.SetBool("Run", Input.GetButton("Fire1"));
        }
        else if(Info.Distanceto != 0)
        {
            Info.Speed = 5f;
            anim.SetBool("Walk", Input.GetButton("Fire1"));
        }
        if (Info.Distanceto == 0)
            anim.SetBool("Walk", false);
        anim.SetBool("Mort", pv.vie < 1);
    }
 
}

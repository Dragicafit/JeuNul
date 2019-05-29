using UnityEngine;

public class AnimationJoueur : AnimationBasique
{
    public ClickToMove Info = null;
 
    void Update()
    {
        Info = gameObject.GetComponent<ClickToMove>();
        if (Info.faraway)
            Info.Speed = 10f;
        else
            Info.Speed = 5f;
        anim.SetBool("Walk", Input.GetButton("Fire1"));
        
    }
    
 
}

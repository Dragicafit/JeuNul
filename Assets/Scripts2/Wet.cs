using UnityEngine;
using System.Collections;

public class Wet : Status
{

    public Wet(GameObject go, float dur) : base(go, dur)
    {
        Se = StatusEnum.Wet;
    }

    public override void ApplyEffect()
    {
        Debug.Log("Water is wet");
    }
    
}

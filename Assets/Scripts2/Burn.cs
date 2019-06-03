using UnityEngine;
using UnityEditor;

public class Burn : Status
{

    public Burn(GameObject go, float dur) : base(go, dur)
    {
        Se = StatusEnum.Burn;
    }

    public override void ApplyEffect()
    {
        Debug.Log("Fire is hot");
    }

}
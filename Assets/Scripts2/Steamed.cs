using UnityEngine;
using UnityEditor;

public class Steamed : Status
{

    public Steamed(GameObject go, float dur) : base(go, dur)
    {
        Se = StatusEnum.Steam;
    }

    public override void ApplyEffect()
    {
        Debug.Log("Steam is water + fire");
    }

}

public class SteamedFactory : StatusFactory
{

    public SteamedFactory(float dur) : base(dur)
    { }

    public override Status GenerateStatus(GameObject go)
    {
        return new Steamed(go, duration);
    }
}
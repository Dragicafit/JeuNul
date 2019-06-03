using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status
{

    public readonly float duration;
    public StatusEnum Se { get; protected set; }
    public float StartTime { protected get; set; }

    private GameObject go;

    public Status(GameObject go, float dur)
    {
        StartTime = Time.time;
        this.go = go;
        duration = dur;
    }

    public abstract void ApplyEffect();

    public override bool Equals(object other)
    {
        return GetType().Equals(other.GetType());
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public bool IsDone()
    {
        return Time.time - StartTime >= duration;
    }
}

public abstract class StatusFactory
{

    protected readonly float duration;

    public StatusFactory(float dur)
    {
        this.duration = dur;
    }

    public abstract Status GenerateStatus(GameObject go);

}
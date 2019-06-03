using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithHp : MonoBehaviour
{

    public int hp = 100;
    public int fallDamage = 1;

    public bool IsDead()
    {
        return hp <= 0;
    }

    protected virtual void AtDeath()
    {
        Destroy(this);
    }

    public void Fall(float magnitude)
    {
        hp -= (int)(fallDamage * magnitude);
    }
}

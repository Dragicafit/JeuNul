using System.Collections.Generic;
using UnityEngine;

public class SpellList : MonoBehaviour
{

    public GameObject blackhole;
    public GameObject stone;

    private List<GameObject> spells;

    void Start()
    {
        spells = new List<GameObject>();
        spells.Add(blackhole);
        spells.Add(stone);
        foreach (GameObject go in spells)
        {
            AbstractSpell absSpell = go.GetComponent<AbstractSpell>();
            if (absSpell != null)
            {
                absSpell.reset_cooldown();
            }
        }
    }

    void Update()
    {
        foreach(GameObject go in spells)
        {
            AbstractSpell absSpell = go.GetComponent<AbstractSpell>();
            if (absSpell != null)
            {
                if (Input.GetKey(absSpell.Key))
                {
                    absSpell.createProjectile(transform);
                }
            }
        }
    }

}

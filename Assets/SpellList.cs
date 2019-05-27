using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellList : MonoBehaviour
{

    public GameObject blackhole;
    public GameObject stone;
    public GameObject bigExplosion;
    public GameObject flameAir2;
    public int nombreSortsCharges = 5;
    public List<string> touches;

    private List<string> sortsCharges;
    private Dictionary<List<string>, AbstractSpell> spells;

    void Start()
    {
        sortsCharges = new List<string>();

        spells = new Dictionary<List<string>, AbstractSpell>();
        AddSpell(blackhole);
        AddSpell(stone);
        AddSpell(bigExplosion);
        AddSpell(flameAir2);

        foreach (AbstractSpell absSpell in spells.Values)
        {
            absSpell?.Reset_cooldown();
        }
    }

    void Update()
    {
        foreach(string key in touches)
        {
            if (Input.GetKeyDown(key) && sortsCharges.Count() < nombreSortsCharges)
            {
                sortsCharges.Add(key);
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            foreach (KeyValuePair<List<string>, AbstractSpell> dic in spells)
            {
                List<string> listSpell = dic.Key;
                AbstractSpell absSpell = dic.Value;
                if (listSpell.SequenceEqual(sortsCharges))
                {
                    absSpell.CreateProjectile(transform);
                }
            }
            sortsCharges.Clear();
        }
    }

    private void AddSpell(GameObject go)
    {
        AbstractSpell absSpell = go.GetComponent<AbstractSpell>();
        spells.Add(absSpell.Key, absSpell);
    }

}
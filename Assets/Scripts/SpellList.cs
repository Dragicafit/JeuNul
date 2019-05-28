using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class SpellList : MonoBehaviour
{
    public int nombreSortsCharges = 5;
    public List<string> touches = new List<string>{ "a", "z", "e", "r" };

    private List<string> sortsCharges;
    private Dictionary<List<string>, AbstractSpell> spells;

    void Start()
    {
        sortsCharges = new List<string>();

        spells = new Dictionary<List<string>, AbstractSpell>();
        foreach (AbstractSpell absSpell in Resources.LoadAll("spells", typeof(AbstractSpell)))
        {
            AddSpell(absSpell);
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

    private void AddSpell(AbstractSpell absSpell)
    {
        spells.Add(absSpell.Key, absSpell);
        absSpell.Reset_cooldown();
    }

}
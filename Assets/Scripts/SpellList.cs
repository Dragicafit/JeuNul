using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellList : MonoBehaviour
{
    private Touches touches;
    private Canalisation canalisation;
    private Dictionary<List<Element>, AbstractSpell> spells;

    void Start()
    {
        touches = GetComponent<Touches>();
        canalisation = GetComponent<Canalisation>();

        spells = new Dictionary<List<Element>, AbstractSpell>();
        foreach (AbstractSpell absSpell in Resources.LoadAll("spells", typeof(AbstractSpell)))
        {
            AddSpell(absSpell);
        }
    }

    void Update()
    {
        foreach(KeyValuePair<string, Element> entry in touches.getTouches())
        {
            if (Input.GetKeyDown(entry.Key))
            {
                canalisation.Add(entry.Value);
                break;
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Lance();
            canalisation.Clear();
        }
    }

    private void Lance()
    {
        foreach (KeyValuePair<List<Element>, AbstractSpell> entry in spells)
        {
            if (canalisation.MemeCombinaison(entry.Key))
            {
                entry.Value.CreateProjectile(transform);
                return;
            }
        }
        Sort sort = new Sort(canalisation.SortsCharges);
        Debug.Log(sort);
    }

    private void AddSpell(AbstractSpell absSpell)
    {
        spells.Add(absSpell.key.Cast<Element>().ToList(), absSpell);
        absSpell.Reset_cooldown();
    }

}
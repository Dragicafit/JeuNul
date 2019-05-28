using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Element { Feu, Eau, Electricite, Terre, Air, Gravite, Croissance, Mort, Poison, Vapeur, Glace, Lave };

public class Canalisation : MonoBehaviour
{
    public int nombreSortsCharges = 5;

    public List<Element> SortsCharges { get; private set; }
    private readonly Dictionary<List<Element>, Element> secondaires = new Dictionary<List<Element>, Element>
        {
            {new List<Element>{Element.Mort, Element.Croissance}, Element.Poison },
            {new List<Element>{Element.Feu, Element.Eau}, Element.Vapeur },
            {new List<Element>{Element.Eau, Element.Air}, Element.Glace },
            {new List<Element>{Element.Terre, Element.Feu}, Element.Lave }
        };

    void Start()
    {
        SortsCharges = new List<Element>();
    }

    public void Add(Element element)
    {
        int count = SortsCharges.Count();

        if (count >= nombreSortsCharges)
            return;

        for (int i = 0; i< count; i++)
        {
            Element comp = SortsCharges[count - i - 1];
            foreach (KeyValuePair<List<Element>, Element> entry in secondaires)
            {
                if (entry.Key.All(new List<Element> { element, comp }.Contains))
                {
                    SortsCharges[count - i - 1] = entry.Value;
                    return;
                }
            }
        }

        SortsCharges.Add(element);
    }

    public void Clear()
    {
        SortsCharges.Clear();
    }

    public bool MemeCombinaison(List<Element> list)
    {
        return SortsCharges.SequenceEqual(list);
    }

    public override string ToString()
    {
        string s = "";
        foreach (Element e in SortsCharges)
        {
            s += Enum.GetName(typeof(Element), e) + ", ";
        }
        return "Charges : " + s;
    }
}
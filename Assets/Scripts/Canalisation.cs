using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Element { Feu, Eau, Electricite, Terre, Air, Gravite, Croissance, Mort, Poison, Vapeur, Glace, Lave };

public class Canalisation : MonoBehaviour
{
    public int nombreSortsCharges = 5;

    private List<Element> sortsCharges;
    private Dictionary<List<Element>, Element> secondaires;
    private Dictionary<List<Element>, Element> interactions;

    void Start()
    {
        sortsCharges = new List<Element>();
        secondaires = new Dictionary<List<Element>, Element>
        {
            {new List<Element>{Element.Mort, Element.Croissance}, Element.Poison },
            {new List<Element>{Element.Feu, Element.Eau}, Element.Vapeur },
            {new List<Element>{Element.Eau, Element.Air}, Element.Glace },
            {new List<Element>{Element.Terre, Element.Feu}, Element.Lave }
        };
        interactions = new Dictionary<List<Element>, Element>
        {
            {new List<Element>{Element.Gravite, Element.Air}, Element.Poison },
            {new List<Element>{Element.Terre, Element.Gravite}, Element.Vapeur },
            {new List<Element>{Element.Eau, Element.Air}, Element.Glace }
        };
    }

    public void Add(Element element)
    {
        int count = sortsCharges.Count();

        if (count >= nombreSortsCharges)
            return;

        for (int i = 0; i< count; i++)
        {
            Element comp = sortsCharges[count - i - 1];
            foreach (KeyValuePair<List<Element>, Element> entry in secondaires)
            {
                if (entry.Key.All(new List<Element> { element, comp }.Contains))
                {
                    sortsCharges[count - i - 1] = entry.Value;
                    return;
                }
            }
        }

        sortsCharges.Add(element);
    }

    public void Clear()
    {
        sortsCharges.Clear();
    }

    public bool MemeCombinaison(List<Element> list)
    {
        return sortsCharges.SequenceEqual(list);
    }
}
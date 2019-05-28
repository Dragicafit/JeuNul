using System;
using System.Collections.Generic;
using System.Linq;

public enum Forme { Boule, Vague, Eclair, Shatter, Projection, Attirance, AOE, Laser, Flaque, Brume, Cristaux, Coulee, OndeDeChoc, Meteorite };

public class Sort
{
    public Forme Forme { get; private set; }
    public List<Element> Effects { get; private set; }
    private readonly Dictionary<List<Element>, Forme> interactions = new Dictionary<List<Element>, Forme>
    {
        {new List<Element>{Element.Feu}, Forme.Boule },
        {new List<Element>{Element.Eau}, Forme.Vague },
        {new List<Element>{Element.Electricite}, Forme.Eclair },
        {new List<Element>{Element.Terre}, Forme.Shatter },
        {new List<Element>{Element.Air}, Forme.Projection },
        {new List<Element>{Element.Gravite}, Forme.Attirance },
        {new List<Element>{Element.Croissance}, Forme.AOE },
        {new List<Element>{Element.Mort}, Forme.Laser },
        {new List<Element>{Element.Poison}, Forme.Flaque },
        {new List<Element>{Element.Vapeur}, Forme.Brume },
        {new List<Element>{Element.Glace}, Forme.Cristaux },
        {new List<Element>{Element.Lave}, Forme.Coulee },
        {new List<Element>{Element.Gravite, Element.Air}, Forme.OndeDeChoc },
        {new List<Element>{Element.Terre, Element.Gravite}, Forme.Meteorite }
    };

    public Sort(List<Element> sortsCharges)
    {
        Effects = sortsCharges;
        RechercheSort();

    }

    private void RechercheSort()
    {
        if (Effects.Count() == 0)
            throw new System.Exception("pas de sorts");
        if (Effects.Count() >= 2)
        {
            List<Element> s2 = new List<Element> { Effects[0], Effects[1] };
            foreach (KeyValuePair<List<Element>, Forme> entry in interactions)
            {
                if (entry.Key.SequenceEqual(s2))
                {
                    Forme = entry.Value;
                    return;
                }
            }
        }
        List<Element> s1 = new List<Element> { Effects[0] };
        foreach (KeyValuePair<List<Element>, Forme> entry in interactions)
        {
            if (entry.Key.SequenceEqual(s1))
            {
                Forme = entry.Value;
                return;
            }
        }
    }

    public override string ToString()
    {
        string s = "";
        foreach (Element e in Effects)
        {
            s += Enum.GetName(typeof(Element), e)+", ";
        }
        return "Forme : " + Enum.GetName(typeof(Forme), Forme) + "\nEffets : " + s;
    }
}

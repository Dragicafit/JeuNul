using System.Collections.Generic;
using UnityEngine;

public class Touches : MonoBehaviour
{
    public string Sort1 = "a";
    public string Sort2 = "z";
    public string Sort3 = "e";
    public string Sort4 = "r";
    public string Sort5 = "q";
    public string Sort6 = "s";
    public string Sort7 = "d";
    public string Sort8 = "f";

    public Dictionary<string, Element> getTouches()
    {
        return new Dictionary<string, Element>
        {
            { Sort1, Element.Feu},
            { Sort2, Element.Eau},
            { Sort3, Element.Electricite},
            { Sort4, Element.Terre},
            { Sort5, Element.Air},
            { Sort6, Element.Gravite},
            { Sort7, Element.Croissance},
            { Sort8, Element.Mort}
        };
    }
}
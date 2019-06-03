using UnityEngine;
using System.Collections.Generic;

public enum StatusEnum {Burn, Wet, Electrified, Poisoned, Slowed, Steam}

public class StatusList : MonoBehaviour
{

    public Dictionary<StatusEnum, Status> AllStatus { protected get; set; }
    protected readonly Dictionary<HashSet<StatusEnum>, StatusFactory> dict = new Dictionary<HashSet<StatusEnum>, StatusFactory>
    {
        {new HashSet<StatusEnum>{StatusEnum.Wet, StatusEnum.Burn}, new SteamedFactory(2f)}
    };

    void Start()
    {
        AllStatus = new Dictionary<StatusEnum, Status>();
        InvokeRepeating("ApplyAllEffect", 0f, 1f);
    }

    void Update()
    {
        // Affiche correctement les status dans l'UI
    }

    public void AddStatus(Status s)
    {
        if(AllStatus.ContainsKey(s.Se))
        {
            AllStatus[s.Se].StartTime = Time.time;
        }
        else
        {
            foreach (KeyValuePair<StatusEnum, Status> allStats in AllStatus)
            {
                foreach (KeyValuePair<HashSet<StatusEnum>, StatusFactory> entry in dict)
                {
                    if(new HashSet<StatusEnum> {s.Se, allStats.Key}.SetEquals(entry.Key))
                    {
                        AllStatus.Remove(allStats.Key);
                        AddStatus(entry.Value.GenerateStatus(gameObject));
                        return;
                    }
                }
            }
            AllStatus.Add(s.Se, s);
        }
    }

    public void ApplyAllEffect()
    {
        List<StatusEnum> l = new List<StatusEnum>();
        if(AllStatus == null)
        {
            Debug.Log("AllStatus null");
        }
        foreach (Status s in AllStatus.Values)
        {
            if (s.IsDone())
            {
                l.Add(s.Se);
                continue;
            }
            s.ApplyEffect();
            
        }
        foreach(StatusEnum se in l)
        {
            AllStatus.Remove(se);
        }
    }

}


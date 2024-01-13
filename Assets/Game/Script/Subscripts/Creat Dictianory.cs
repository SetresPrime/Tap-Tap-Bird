using System.Collections.Generic;
using UnityEngine;

public class CreatDictionary : MonoBehaviour
{
    public static Dictionary<string, IBaseUI> NewDictionary(IBaseUI[] objects)
    {
        var newDictionary = new Dictionary<string, IBaseUI>();
        for (int i = 0; i < objects.Length; i++)
        {
            var name = NormilizeString(objects[i].GetContainingObjectName());
            newDictionary.Add(name, objects[i]);
        }
        return newDictionary;
    }
    public static string NormilizeString(string naming)
    {
        var split = naming.Split(" ");
        if (split.Length == 1)
            split = naming.Split('_');
        if (split == null)
            naming.ToLower();
        else
        {
            for (int i = 0; i < split.Length; i++)
            {
                split[i] = i != 0 ?
                    split[i].Substring(0, 1).ToUpper() + split[i].Substring(1, split[i].Length - 1).ToLower()
                  : split[i].ToLower();
            }
            naming = string.Join("", split);
        }
        return naming;
    }
}


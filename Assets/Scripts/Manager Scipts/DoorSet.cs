using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSet : MonoBehaviour
{
    public HashSet<string> WispDoors { get; private set; } = new HashSet<string>();

    private void Awake()
    {
        Load();
    }

    public void Save()
    {
        SaveLoad.Save(WispDoors, "WispDoors");
    }

    public void Load()
    {
        if (SaveLoad.FileExists("WispDoors"))
        {
            WispDoors = SaveLoad.Load<HashSet<string>>("WispDoors");
        }
    }
}

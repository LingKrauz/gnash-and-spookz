using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItemSet : MonoBehaviour
{
    public HashSet<string> CollectedItems { get; private set; } = new HashSet<string>();

    private void Awake()
    {
        Load();
    }

    public void Save()
    {
        SaveLoad.Save(CollectedItems, "CollectedItems");
    }

    public void Load()
    {
        if (SaveLoad.FileExists("CollectedItems"))
        {
            CollectedItems = SaveLoad.Load<HashSet<string>>("CollectedItems");
        }
    }
}

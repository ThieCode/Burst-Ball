using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Sprites", menuName = "Game Assets/Sprites", order = 2)]
public class GraphicAssets : ScriptableObject
{
    public Sprite[] ballsSprites;
    public BioColorItem[] items;
    public PrefabItem[] prefabs;

    public BioColorItem GetBioColorItem(string name)
    {
        foreach(BioColorItem item in items)
        {
            if (item.name == name) return item;
        }
        throw null;
    }

    public PrefabItem GetPrefabItem(string name)
    {
        foreach (PrefabItem item in prefabs)
        {
            if (item.name == name) return item;
        }
        throw null;
    }

    [System.Serializable]
    public struct BioColorItem
    {
        public string name;
        public Color color1;
        public Color color2;
    }

    [System.Serializable]
    public struct PrefabItem
    {
        public string name;
        public GameObject go;
    }
}

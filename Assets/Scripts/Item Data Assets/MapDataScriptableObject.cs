using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapDataAsset", menuName = "ScriptableObjects/MapDataAsset", order = 2)]
[System.Serializable]
public class MapDataScriptableObject : ScriptableObject
{
    public string _mapName;
    public Sprite _mapSprite;
    public int _mapCost;
    public bool isSelected;
}

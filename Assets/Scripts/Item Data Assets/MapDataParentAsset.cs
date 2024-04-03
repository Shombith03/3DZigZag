using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapDataAssetParent", menuName = "ScriptableObjects/MapDataAssetParent", order = 1)]

public class MapDataParentAsset : ScriptableObject
{
    public List<MapDataScriptableObject> MapDataAsset => _mapDataAsset;

    [SerializeField]
    private List<MapDataScriptableObject> _mapDataAsset = new List<MapDataScriptableObject>();
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private Button _nextMapButton, _prevMapButton;
    [SerializeField]
    private Image _mapImage;
    [SerializeField]
    private Text _mapText;
    [SerializeField]
    private Button _setMapButton;

    [SerializeField]
    private Button _nextBallButton, _prevBallButton;
    [SerializeField]
    private Sprite[] _ballSprites;
    [SerializeField]
    private Image _ballImage;
    [SerializeField]
    private Text _ballText;
    [SerializeField]
    private Button _buyBallButton;
    [SerializeField]
    private Button _setBallButton;

    [SerializeField]
    private MapDataParentAsset _mapDataAsset;
    int currentMapIndex;

    public void OpenShopPanel()
    {
        SetMaps();
        currentMapIndex = 0;
        SetMaps();
    }

    private void SetMaps()
    {
        _mapText.text = _mapDataAsset.MapDataAsset[currentMapIndex]._mapName;
        //_mapImage.sprite = _mapDataAsset.MapDataAsset[currentMapIndex]._mapSprite;
    }

    public void NextMap()
    {
        if(currentMapIndex > _mapDataAsset.MapDataAsset.Count)
        {
            return;
        }
        currentMapIndex = 1;
        SetMaps();
    }

    public void PrevMap() 
    {
        if (currentMapIndex < 0)
        {
            return;
        }
        currentMapIndex = 0;
        SetMaps();
    }

}

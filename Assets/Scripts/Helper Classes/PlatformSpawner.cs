using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _startingPlatform;
    [SerializeField]
    private GameObject _platformPrefab;
    [SerializeField]
    private GameObject _collectible;

    private Vector3 _lastPos;
    private float _size;

    internal bool _gameOver;

    [SerializeField]
    private Color[] _colors;
    private List<GameObject> _platforms = new List<GameObject>();

    private void Start()
    {
        _lastPos = _platformPrefab.transform.position;
        _size = _platformPrefab.transform.localScale.x;

        // for the first set of platforms
        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }
    }

    public void StartSpawningPlatforms()
    {
        //continuos spawning of platforms
        InvokeRepeating(nameof(SpawnPlatforms), .5f, 0.2f);
    }

    private void Update()
    {
        if (GameManager.Instance.gameOver)
        {
            CancelInvoke(nameof(SpawnPlatforms));
        }
    }

    private void SpawnPlatforms()
    {
        int rand = UnityEngine.Random.Range(0, 6);
        if(rand < 3)
        {
            SpawnAtX();
        }
        else if (rand >= 3)
        {
            SpawnAtZ();
        }
    }

    public void ChangePlatformColor()
    {
        if(_colors.Length > 0 && _platforms.Count > 0)
        {
            Color randomColor = _colors[UnityEngine.Random.Range(0, _colors.Length)];

            foreach (GameObject item in _platforms)
            {
                Renderer platformRenderer = item.GetComponent<MeshRenderer>();
                if(platformRenderer != null )
                {
                    platformRenderer.material.color = randomColor;
                }
            }
            _startingPlatform.GetComponent<MeshRenderer>().material.color = randomColor;
        }
    }

    private void SpawnAtX()
    {
        Vector3 pos = _lastPos;
        pos.x += _size;
        _lastPos = pos;
        GameObject platform = Instantiate(_platformPrefab, pos, Quaternion.identity);
        AddPlatformToList(platform);
        SpawnDiamonds(pos);
    }

    private void SpawnAtZ() 
    {
        Vector3 pos = _lastPos;
        pos.z += _size;
        _lastPos = pos;
        GameObject platform = Instantiate(_platformPrefab, pos, Quaternion.identity);
        AddPlatformToList(platform);

        SpawnDiamonds(pos);

    }

    private void AddPlatformToList(GameObject platform)
    {
        _platforms.Add(platform);
    }

    internal void RemovePlatformFromList(GameObject platform)
    {
        _platforms.Remove(platform);
    }

    private void SpawnDiamonds(Vector3 pos)
    {
        int rand = UnityEngine.Random.Range(0, 4);

        if (rand < 1)
        {
            // spawn collectibles
            Instantiate(_collectible, new Vector3(pos.x, pos.y + 1, pos.z), _collectible.transform.rotation);
        }
    }

}

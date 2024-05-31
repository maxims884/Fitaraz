using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
public class TileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _tilePrefabWithBonus;
    [SerializeField] private GameObject _tilePrefabHole;
    [SerializeField] private int maxCount;
    [SerializeField] private List<Tile> _tiles = new List<Tile>();
    private float speed = 8;
    private float maxSpeed = 40;
    private float increaseSpeedStep = 0.2f;
    private float countTimer = 0;

    public bool isPauseGenerate = false;
    private System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        _tiles.First().speed = speed;
        _tiles[1].speed = speed;
        for (int i = 0; i < maxCount; i++)
        {
            GenerateTile();
        }
        SetPauseGenerate();
    }

    // Update is called once per frame
    void Update()
    {
        if (_tiles.Count < maxCount && !isPauseGenerate)
        {
            GenerateTile();
        }
    }

    void FixedUpdate()
    {
        if (!isPauseGenerate)
        {
            if (countTimer > 350)
            {
                countTimer = 0;
                IncreaseSpeed();
            }
            countTimer++;
        }
    }

    public bool GetGenerate()
    {
        return isPauseGenerate;
    }

    public void SetPauseGenerate() { 
        isPauseGenerate = true;

        foreach (Tile tile in _tiles)
        {
            tile.setPause();
        }
    }

    public void SetStartGenerate()
    {
        isPauseGenerate = false;

        foreach (Tile tile in _tiles)
        {
            tile.setUnPause();
        }
    }

    private void GenerateTile()
    {
        int IsNeedBonusTile = getRand(1, 5);
        int IsNeedAddHole = getRand(3, 7);
        GameObject _prefab;
        if(IsNeedAddHole == 5 && !String.Equals(_tiles.Last().name, "TileHole(Clone)") && !String.Equals(_tiles.Last().name,"TileHole"))
        {
            _prefab = _tilePrefabHole;
            _prefab.transform.localScale = new Vector3(_prefab.transform.localScale.x, _prefab.transform.localScale.y, getRand(5,20));
             
        } else {
            if (IsNeedBonusTile == 3)
            {
                _prefab = _tilePrefabWithBonus;
            } 
            else { 
                _prefab = _tilePrefab;  
            }
        }

        float lastCenter = _tiles.Last().transform.localScale.z /2;
        float prefCenter = _prefab.transform.localScale.z /2;
        float sdvigZ =  lastCenter +  prefCenter;

        GameObject newTileObject;
        newTileObject = Instantiate(_prefab, _tiles.Last().transform.position + Vector3.forward *sdvigZ, Quaternion.identity);

        Tile newTile = newTileObject.GetComponent<Tile>();
        newTile.speed = speed;

        _tiles.Add(newTile);
    }

    private void OnTriggerEnter(Collider other)
    {
        _tiles.Remove(other.GetComponent<Tile>());
        Destroy(other.gameObject);
    }

    private void IncreaseSpeed()
    {
        if(speed < maxSpeed)
        {
            speed += increaseSpeedStep;
            for (int i = 0; i < _tiles.Count; i++)
            {
                Tile tile = _tiles[i];
                tile.speed = speed;
            }
        }
    }

    private int getRand(int minValue, int maxValue)
    {
       return rand.Next(minValue, maxValue);
    }
}

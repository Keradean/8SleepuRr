using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{

    [SerializeField] private int _gridSize;
    [SerializeField] private List<GameObject> _tiles = new List<GameObject>();

    [SerializeField] private int _seed;
    [SerializeField] private Grid _grid ;
    private Vector3 _position = Vector3.zero;
    private Quaternion _rotation = Quaternion.Euler(-90, 0, 0);
    private Vector2Int _crashSite;
    private Vector2Int _targetPoint;
    [SerializeField] private bool _customSeed;
    System.Random _seededRandomGenerator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // _grid = GetComponent<Grid>();

        generateLevel(_seed);

    }

    public void clearLevel()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            #if UNITY_EDITOR
                        DestroyImmediate(transform.GetChild(i).gameObject);
            #else
                    Destroy(transform.GetChild(i).gameObject);
            #endif
        }
    }

    public void generateLevel(int seed = 0)
    {   
        clearLevel();

        // setting the seeded random generator
        if (!_customSeed)
        {
            seed = Random.Range(1, 100000000);
            _seed = seed;
        }
        _seededRandomGenerator = new System.Random(seed);

        _crashSite.x = 0;
        _crashSite.y = _seededRandomGenerator.Next(1, _gridSize);

        _targetPoint.x = _seededRandomGenerator.Next(_gridSize - 2, _gridSize);
        _targetPoint.y = _seededRandomGenerator.Next(1, _gridSize);


        for (int posX = 0; posX < _gridSize; posX++)
        {
            _position.x = posX * _grid.cellSize.x;
            for (int posZ = 0; posZ < _gridSize; posZ++)
            {
                _position.z = posZ * _grid.cellSize.z;


                GameObject currentTile = Instantiate(_tiles[_seededRandomGenerator.Next(0, _tiles.Count)], _position, _rotation, transform);

                if (posX == _crashSite.x && posZ == _crashSite.y)
                {
                    currentTile.name = "Tile x " + posX + ", z " + posZ + " --Crash site";

                }
                else if (posX == _targetPoint.x && posZ == _targetPoint.y)
                {
                    currentTile.name = "Tile x " + posX + ", z " + posZ+" --Target point";
                } else currentTile.name = "Tile x " + posX + ", z " + posZ;


                }
        }
        /*
        Debug.Log("Generated current level using seed: "+seed);
        Debug.Log("Crashsite at: "+_crashSite);
        Debug.Log("Target Point at"+_targetPoint);
        */

    }

}

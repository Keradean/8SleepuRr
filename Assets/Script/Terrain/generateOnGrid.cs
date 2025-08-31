using System.Collections.Generic;
using UnityEngine;

public class generateOnGrid : MonoBehaviour
{
    [Header("Grid Attributes")]
    [SerializeField] private int _gridSize;
    [SerializeField] private List<GameObject> _tiles = new List<GameObject>();
    [Space]
    [Tooltip("Seed used for level generation: Use 0 for random seed")]
    [SerializeField] private int _seed;
    private Grid _grid;
    private Vector3 _position = Vector3.zero;
    private Quaternion _rotation = Quaternion.Euler(-90, 0, 0);
    private double _crashSite;
    private double _targetPoint;
    System.Random _seededRandom;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _grid = GetComponent<Grid>();

        if (_seed == 0)
        {
            _seed = Random.Range(1, 100000000);
        }
        _seededRandom = new System.Random(_seed);


        Debug.Log("Generated using seed: " + _seed);
        for (int i = 1; i < 4; i++)
        {
            Debug.Log("Random Number " + i + ". = " + _seededRandom.Next(1, 100));
        }




        for (int posX = 0; posX < _gridSize; posX++)
        {
            _position.x = posX * _grid.cellSize.x;
            for (int posZ = 0; posZ < _gridSize; posZ++)
            {
                _position.z = posZ * _grid.cellSize.z;
                Instantiate(_tiles[_seededRandom.Next(0, _tiles.Count)], _position, _rotation, transform);
            }




        }

    }



}

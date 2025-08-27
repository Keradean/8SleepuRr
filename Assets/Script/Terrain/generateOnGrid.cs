using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class generateOnGrid : MonoBehaviour
{

    [SerializeField] private int _gridSize;
    [SerializeField] private List<GameObject> _tiles = new List<GameObject>();
    [SerializeField] private int _seed;
    private Grid _grid;
    private Vector3 _position = Vector3.zero;
    private Quaternion _rotation = Quaternion.Euler(-90,0,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_seed == 0)
        {
            _seed = 1;
        }


        _grid = GetComponent<Grid>();

        for (int posX = 0; posX < _gridSize; posX++)
        {
            _position.x = posX * _grid.cellSize.x;
            for (int posZ = 0; posZ < _gridSize; posZ++)
            {
                _position.z = posZ * _grid.cellSize.z;
                Instantiate(_tiles[0], _position, _rotation);
            }




        }

    }

    

}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Tile{
    public string Id { get; }
    public string Name { get; }
    public int Size { get; }
    public int Row { get; }
    public int Col { get; }

    public Tile(string name, int row, int col){
        Id = Guid.NewGuid().ToString("N").Substring(0, 9);
        Name = name;
        switch (name)
        {
            case "L":
                Size = 16;
                break;
            case "M":
                Size = 4;
                break;
            default:
                Size = 1;
                break;
        }
        Row = row;
        Col = col;
    }
}
public class WorldGen : MonoBehaviour
{
    public GameObject[] largeTilePrefabs; // Large tiles
    public GameObject[] mediumTilePrefabs; // Medium tiles
    public GameObject[] smallTilePrefabs; // Small tiles

    [SerializeField] private int worldSize = 64; 
    private Tile [,] grid;


    // Start is called before the first frame update
    void Start()
    {
        grid = new Tile[worldSize, worldSize];
        instantiateTileGrid();
        instantiateTiles();
    }
bool IsValidPlacement(Tile tile, int row, int col)
{
    for (int i = row; i < Math.Min(row + tile.Size, worldSize); i++)
    {
        for (int j = col; j < Math.Min(col + tile.Size, worldSize); j++)
        {
            if (grid[i, j] != null)
            {
                return false;
            }
        }
    }
    return true;
}


    // Function to instantiate tiles
    void instantiateTileGrid()
    {
        int largeTileAmount = UnityEngine.Random.Range(0, 8)+ UnityEngine.Random.Range(0, 8);
        int upperBound = (16 - largeTileAmount) * 4;
        int mediumTileAmount = UnityEngine.Random.Range(0, upperBound/2) + UnityEngine.Random.Range(0, upperBound/2);
        int smallTileAmount =256 - (largeTileAmount * 16) - (mediumTileAmount * 4);

        Debug.Log("largeTileAmount: " + largeTileAmount + ", " + "mediumTileAmount: " + mediumTileAmount + ", " + "smallTileAmount: " + smallTileAmount + ". Total spaces occupied: " + ((largeTileAmount * 16) + (mediumTileAmount * 4) + smallTileAmount));

        for (int i = 0; i < largeTileAmount; i++)
        {
            while(true){
                int row = UnityEngine.Random.Range(0, worldSize-16);
                int col = UnityEngine.Random.Range(0, worldSize-16);
                var tile = new Tile("L", row, col);
                if (IsValidPlacement(tile, row, col))
                {
                    for (int k = row; k < row + tile.Size; k++)
                    {
                        for (int l = col; l < col + tile.Size; l++)
                        {
                            grid[k, l] = tile;
                        }
                    }
                    break;
                }
            }
        }

        for (int i = 0; i < mediumTileAmount; i++)
        {
            while(true){
                int row = UnityEngine.Random.Range(0, worldSize-4);
                int col = UnityEngine.Random.Range(0, worldSize-4);
                var tile = new Tile("M", row, col);
                if (IsValidPlacement(tile, row, col))
                {
                    for (int k = row; k < row + tile.Size; k++)
                    {
                        for (int l = col; l < col + tile.Size; l++)
                        {
                            grid[k, l] = tile;
                        }
                    }
                    break;
                }
            }
        }
        for (int i = 0; i < worldSize; i++)
        {
            for (int j = 0; j < worldSize; j++)
            {
                if (grid[i, j] == null)
                {
                    grid[i, j] = new Tile("S", i, j);
                }
            }
        }

     
    }
    void instantiateTiles(){
        for (int i = 0; i < worldSize; i++)
        {
            for (int j = 0; j < worldSize; j++)
            {
                GameObject prefabToInstantiate = null;
                float offset = 0;
                switch (grid[i, j].Name)
                {
                    case "L":
                        prefabToInstantiate = largeTilePrefabs[UnityEngine.Random.Range(0, largeTilePrefabs.Length)];
                        offset = 1.5f;
                        break;
                    case "M":
                        prefabToInstantiate = mediumTilePrefabs[UnityEngine.Random.Range(0, mediumTilePrefabs.Length)];
                        offset = 0.5f;
                        break;
                    default:
                        prefabToInstantiate = smallTilePrefabs[UnityEngine.Random.Range(0,UnityEngine.Random.Range(0, smallTilePrefabs.Length))];
                        break;
                        
                }
                if (prefabToInstantiate != null)
                {
                    Vector3 position = new Vector3(i - offset, 0, j - offset);
                    Instantiate(prefabToInstantiate, position, Quaternion.identity);
                }
            }
        }
    }
   
}


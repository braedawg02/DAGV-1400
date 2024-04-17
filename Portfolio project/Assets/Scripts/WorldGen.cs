using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Mathematics;
using TMPro;
using System.Diagnostics;

public class Tile
{
    public string Id { get; }
    public string Name { get; }
    public int Size { get; }
    public int Row { get; }
    public int Col { get; }

    public Tile(string name, int row, int col)
    {
        Id = Guid.NewGuid().ToString("N").Substring(0, 9);
        Name = name;
        switch (name)
        {
            case "L":
                Size = 4;
                break;
            case "M":
                Size = 2;
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
    public GameObject waterTilePrefab; // Water tile

    [SerializeField] public int worldSize = 256;

    public int largeRelativeSize;
    public int mediumRelativeSize;
    public int smallRelativeSize;
    public Tile[,] grid;

    // Start is called before the first frame update
    void Start()
    {// worldSize = 256
        UnityEngine.Debug.Log("largeRelativeSize: " + largeRelativeSize + ", " + "mediumRelativeSize: " + mediumRelativeSize + ", " + "smallRelativeSize: " + smallRelativeSize);
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
        int largeTileAmount = rollDice(4, 4);
        //int largeTileAmount = 1-16;
        int mediumTileAmount = rollDice(4, 16);
        //int mediumTileAmount = 1-64;
        int smallTileAmount = 256 - (mediumTileAmount * 2 + largeTileAmount * 4);
        //int smallTileAmount = 1-256;
        UnityEngine.Debug.Log("largeTileAmount: " + largeTileAmount + ", " + "mediumTileAmount: " + mediumTileAmount + ", " + "smallTileAmount: " + smallTileAmount + ". Total tiles occupied: " + (largeTileAmount * 4 + mediumTileAmount * 2 + smallTileAmount));

        for (int i = 0; i < largeTileAmount; i++)
        {
            int attempts = 0;
            while (true)
            {

                int row = largeRelativeSize * UnityEngine.Random.Range(0, (worldSize / largeRelativeSize));
                int col = largeRelativeSize * UnityEngine.Random.Range(0, (worldSize / largeRelativeSize));
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
                if (attempts > 50)
                {
                    break;
                }
                attempts++;
            }
        }

        for (int i = 0; i < mediumTileAmount; i++)
        {
            int attempts = 0;
            while (true)
            {
                int row = mediumRelativeSize * UnityEngine.Random.Range(0, (worldSize / mediumRelativeSize) - 1);
                int col = mediumRelativeSize * UnityEngine.Random.Range(0, (worldSize / mediumRelativeSize) - 1);
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
                if (attempts > 100)
                {
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
    int rollDice(int noOfDice, int sides)
    {
        int sum = 0;
        for (int i = 0; i < noOfDice; i++)
        {
            sum += UnityEngine.Random.Range(1, sides);
        }
        return sum;
    }

    void instantiateTiles()
    {
        for (int i = 0; i < worldSize; i++)
        {
            for (int j = 0; j < worldSize; j++)
            {
                if (i >= worldSize || j >= worldSize)
                {
                    break;
                }
                GameObject prefabToInstantiate = null;
                float offset = 12.5f;
                float relativeOffset = 0.0f;
                switch (grid[i, j].Name)
                {
                    case "L":
                        if (i % 4 == 0 && j % 4 == 0) // Check if the tile is the first tile of a 4x4 group
                        {
                            // Instantiate your Large tile here
                            prefabToInstantiate = largeTilePrefabs[UnityEngine.Random.Range(0, largeTilePrefabs.Length)];
                         
                        }
                        relativeOffset = 1.5f;
                        
                        break;
                    case "M":
                        if (i % 2 == 0 && j % 2 == 0) // Check if the tile is the first tile of a 2x2 group
                        {
                            // Instantiate your Medium tile here
                            prefabToInstantiate = mediumTilePrefabs[UnityEngine.Random.Range(0, mediumTilePrefabs.Length)];
                            relativeOffset = .5f;
                        }
                        break;
                    default:
                        prefabToInstantiate = smallTilePrefabs[UnityEngine.Random.Range(0, UnityEngine.Random.Range(0, smallTilePrefabs.Length))];
                        relativeOffset = 0f;
                        break;
                }
                if (prefabToInstantiate != null)
                {
                    Vector3 position = new Vector3((i * offset) + (offset * relativeOffset) - 193.75f, 0, (j * offset) + (offset * relativeOffset) - 193.75f);
                    Quaternion rotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 3) * 90, 0);
                    GameObject tile = Instantiate(prefabToInstantiate, position, rotation);
                    if (tile.CompareTag("Water"))
                    {
                        GameObject waterTile = Instantiate(waterTilePrefab, position, rotation);
                        waterTile.transform.localPosition = new Vector3(position.x, -1, position.z);
                        switch (grid[i, j].Name)
                        {

                            case "L":
                                waterTile.transform.localScale = new Vector3(1, 1, 1);

                                break;
                            case "M":
                                waterTile.transform.localScale = new Vector3(0.5f, 1, 0.5f);
                                break;
                            default:
                                waterTile.transform.localScale = new Vector3(0.25f, 1, 0.25f);
                                break;
                        }
                    }
                }

            }
        }
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public GameObject[] largeTilePrefabs; // Array of tile prefabs to spawn
    public GameObject[] mediumTilePrefabs; // Array of tile prefabs to spawn
    public GameObject[] smallTilePrefabs;
    private Mesh test; // Array of tile prefabs to spawn
    
    [SerializeField]private int worldSize = 200; // Size of the world
    

    // Start is called before the first frame update
    void Start()
    {
     
        instantiateTiles();
    }

 
    // Function to instantiate tiles
    void instantiateTiles()
    {
        int largeTileAmount = Random.Range(0, 16);
        
        int upperBound = (16 - largeTileAmount) * 4;

        int mediumTileAmount = Random.Range(0, upperBound);
        
        int smallTileAmount = Random.Range(0, (upperBound - mediumTileAmount) * 4);
        
        Debug.Log("largeTileAmount: " + largeTileAmount + ", " + "mediumTileAmount: " + mediumTileAmount + ", " + "smallTileAmount: " + smallTileAmount);
        int placedTiles = 0;
        List<Vector3> occupiedPositions = new List<Vector3>(); // List to store occupied positions

        // Randomly place large tiles
        do
        {
            int x = (Random.Range(-2, 2) * 50) + 25;
            int z = (Random.Range(-2, 2) * 50) + 25;
            int y = 0;
            int index = Random.Range(0, largeTilePrefabs.Length);
            Vector3 position = new Vector3(x, y, z);

            // Check if the position is already occupied
            if (!IsPositionOccupied(position, occupiedPositions))
            {
                GameObject tile = Instantiate(largeTilePrefabs[index], position, Quaternion.identity);
                placedTiles++;
                occupiedPositions.Add(position); // Add the occupied position to the list
            }

        } while (placedTiles < largeTileAmount);
    }

    bool IsPositionOccupied(Vector3 position, List<Vector3> occupiedPositions)
    {
        foreach (Vector3 occupiedPosition in occupiedPositions)
        {
            // Check if the distance between the positions is less than the minimum distance
            if (Vector3.Distance(position, occupiedPosition) < 10f)
            {
                return true; // Position is occupied
            }
        }
        return false; // Position is not occupied
    }
}


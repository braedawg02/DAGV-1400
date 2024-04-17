using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoilageGenerator : MonoBehaviour
{
    public GameObject[] treePrefabs;
    public GameObject[] cliffPrefabs;
    public GameObject[] rockPrefabs;
    public GameObject[] SmallRockPrefabs;
    public GameObject[] plantPrefabs;
    public GameObject[] woodPrefabs;
    public int treeCount = 1000;
    public int worldsize;
    // Start is called before the first frame update
    void Start()
    {
    WorldGen worldGen = FindObjectOfType<WorldGen>();
    if (worldGen != null)
    {
        worldsize = worldGen.worldSize * (25/2);
    }
    else
    {
        Debug.LogError("WorldGent script not found! Setting default world size to 256");
        worldsize = 256 * (25/2);

    }
    for (int i = 0; i < treeCount; i++)
    {
        int x = Random.Range(0, worldsize);
        int z = Random.Range(0, worldsize);
        int foilageIndex = Random.Range(0, treePrefabs.Length);
        GameObject foilage = Instantiate(treePrefabs[foilageIndex], new Vector3(x, 0, z), Quaternion.identity);
        foilage.transform.parent = transform;
    }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

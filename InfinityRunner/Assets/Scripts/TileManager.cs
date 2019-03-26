using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Links used:
 * https://www.youtube.com/watch?v=WnvW6m4Fqmo&index=8&list=PLLH3mUGkfFCXps_IYvtPcE9vcvqmGMpRK
 * 
 * 
 */
public class TileManager : MonoBehaviour
{
    //because tile manager needs to know what it is allowed to spawn
    public GameObject[] tilePrefabs;

    //need a reference to the player
    //Because it is the player who is moving around in the map
    //and is the one who triggers it
    private Transform playerTransform;

    //stands for where in z we should spawn the object
    private float spawnZ = -6.31f;

    //also needs the length of the object
    private float tileLength = 6.31f;

    //how many tiles do we need on the screen (depends on machine)
    private int amountOfTilesOnScreen = 7;

    //List to keep track of older tiles
    private List<GameObject> activeTiles;

    private float safeZone = 15.0f;

    private int lastPrefabIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; //gets position  
        //to spawn tiles at start, eventually this will run out, so we continue in update
        for (int i = 0; i < amountOfTilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //when we cross a certain point a new tile is created
        if (playerTransform.position.z  - safeZone > (spawnZ - amountOfTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile(int prefabIndex = -1)
    {
        //need a gameobject
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RndPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        //set the parent to my own transform, so that every spawned object is under TileManager
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]); //removes tile at index 0, saves memory
        activeTiles.RemoveAt(0); //removes tile at index 0
    }

    private int RndPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
            return 0;

        //this is also our return value
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs; 
    public float zSpawn = 0;
    public float tileLength = 200;

    private int amountTiles = 3;

    public Transform playerTransform;

    public float safeZone = 400;

    private List<GameObject> activeTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(0);
        SpawnTile(0);
     
        
      


    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone > zSpawn - (amountTiles * tileLength)) {

            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex) {

        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile() {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}

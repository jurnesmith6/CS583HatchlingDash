using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject rockPrefab;
    public int cols = 4;
    public int rows = 12;
    public float xSpacing = 12f;
    public float ySpacing = 14f;
   
   
    
    
    public void SpawnTerrain()
    {
        // clear rocks
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Rock"))
        {
            Destroy(obj);
        }

        // clear seaweed
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Seaweed"))
        {
            Destroy(obj);
        }

        //spawn rocks

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 position = new Vector3(x * xSpacing, y * ySpacing, 0);

                position.x += Random.Range(-6f, 6f);
                position.y += Random.Range(-6f, 6f);

                Instantiate(rockPrefab, position, Quaternion.identity);
            }

        }

    }

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

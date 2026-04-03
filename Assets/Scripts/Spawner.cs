using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject rockPrefab;
    public GameObject crabPrefab;
    public int cols = 4;
    public int rows = 12;
    public float xSpacing = 12f;
    public float ySpacing = 14f;
   
   
    List<Vector3> rockPos = new List<Vector3>(); 
    
    
    public void SpawnTerrain()
    {
        // clear rocks
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Rock"))
        {
            Destroy(obj);
        }
        rockPos.Clear();
        

        //spawn rocks

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 position = new Vector3(x * xSpacing, y * ySpacing, 0);
                
                position.x += Random.Range(-4f, 4f);
                position.y += Random.Range(-5f, 5f);
                rockPos.Add(position);
                Instantiate(rockPrefab, position, Quaternion.identity);
            }

        }

    }

    public void SpawnCrab()
    {
        // clear crabs
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Crab"))
        {
            Destroy(obj);
        }
        
        
        for (int i = 0; i < rockPos.Count; ++i)
        {
            for (int j = rockPos.Count - 1; j > 0 + i; j--)
            {
                Vector3 rockA = rockPos[i];
                Vector3 rockB =  rockPos[j];
                float distance = Vector3.Distance(rockA, rockB);
                
                if (distance <= 15f && distance > 3f)
                {
                    Vector3 spawnPos = (rockA + rockB) / 2f;

                    GameObject crab = Instantiate(crabPrefab, spawnPos, Quaternion.identity);

                    CrabMovement movement = crab.GetComponent<CrabMovement>();
                    movement.pointA = rockA;
                    movement.pointB = rockB;
                    
                }
                
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

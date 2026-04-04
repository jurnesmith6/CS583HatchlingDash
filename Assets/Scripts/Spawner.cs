using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject rockPrefab;
    public GameObject crabPrefab;
    public GameObject seagullPrefab;
    public Camera cam;
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

    public void StopSeagullSpawn()
    {
        CancelInvoke("SpawnSeagull");
    }

    public void SeagullSpawn()
    {
        CancelInvoke("SpawnSeagull");
        InvokeRepeating("SpawnSeagull", 5f, 5f);
    }

    public void SpawnSeagull()
    {
       // Vector3 pos = new Vector3((Random.Range(0, 2) == 0) ? seagullSpawnXPos1 : seagullSpawnXPos2,
       //     Random.Range(seagullSpawnYPos1, seagullSpawnYPos2), 0);
        
       // Camera cam = Camera.main;

       
        // Get camera bounds in world space
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float halfW = camWidth / 2f + 2f;
        float halfH = camHeight / 2f + 2f;

        Vector3 camPos = cam.transform.position;

        // Pick a random edge: 0=left, 1=right, 2=top, 3=bottom
        int edge = Random.Range(0, 4);

        Vector3 pos = edge switch
        {
            0 => new Vector3(camPos.x - halfW, camPos.y + Random.Range(-halfH, halfH), 0f), // left
            1 => new Vector3(camPos.x + halfW, camPos.y + Random.Range(-halfH, halfH), 0f), // right
            2 => new Vector3(camPos.x + Random.Range(-halfW, halfW), camPos.y + halfH, 0f), // top
            _ => new Vector3(camPos.x + Random.Range(-halfW, halfW), camPos.y - halfH, 0f), // bottom
        };
        Instantiate(seagullPrefab, pos, Quaternion.identity);
        


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

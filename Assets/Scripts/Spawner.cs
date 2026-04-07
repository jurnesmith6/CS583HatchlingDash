using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject rockPrefab;
    public GameObject crabPrefab;
    public GameObject seagullPrefab;
    public GameObject treePrefab;
    public Camera cam;
    private int cols = 4;
    private int rows = 10;
    private float xSpacing;
    private float ySpacing;
    private float xJitter, yJitter;
    private float seagullSpeed;
    private float platformLength = 182f;
    private float platformWidth = 60f;
    
  
   
   
    List<Vector3> rockPos = new List<Vector3>(); 
    
    
    public void SpawnTerrain(int cols, int rows)
    
    {
       
        xSpacing = platformWidth / cols;
        ySpacing = platformLength / rows;
        float xJitter = xSpacing / 4;
        float yJitter = ySpacing / 2;
        
        // clear rocks
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Rock"))
        {
            Destroy(obj);
        }
        rockPos.Clear();
        
        //clear trees
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PalmTree"))
        {
            Destroy(obj);
        }
        

        //spawn rocks

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 position = new Vector3(x * xSpacing, y * ySpacing, 0);
                
                position.x += Random.Range(-xJitter, xJitter);
                position.y += Random.Range(-yJitter, yJitter);
                rockPos.Add(position);
                Instantiate(rockPrefab, position, Quaternion.identity);
            }

        }
        
       // SpawnTrees();

    }

    void SpawnTrees()
    {
        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Vector3 position = new Vector3(x * 24f, y * 18.2f, 0);
                position.x += Random.Range(-6f, 6f);
                position.y += Random.Range(-9f, 9f);
                Instantiate(treePrefab, position, Quaternion.identity);
            }

        }
    }

    public void SpawnCrab(float speed)
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
                float maxDistance = Mathf.Sqrt(xSpacing * xSpacing + ySpacing * ySpacing);
                float minDistance = Mathf.Sqrt(xJitter * xJitter + yJitter * yJitter);
                if (distance <= maxDistance && distance > minDistance)
                {
                    Vector3 spawnPos = (rockA + rockB) / 2f;

                    GameObject crab = Instantiate(crabPrefab, spawnPos, Quaternion.identity);

                    CrabMovement movement = crab.GetComponent<CrabMovement>();
                    movement.pointA = rockA;
                    movement.pointB = rockB;
                    movement.SetSpeed(speed);
                    
                }
                
            }
            
        }
        
    }

    public void SeagullSpawn(float seagullSpeed, float time)
    {
        this.seagullSpeed = seagullSpeed;
        CancelInvoke("SpawnSeagull");
        InvokeRepeating("SpawnSeagull", time,time);
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
        GameObject seagull = Instantiate(seagullPrefab, pos, Quaternion.identity);
        
        SeagullMovement movement = seagull.GetComponent<SeagullMovement>();
        movement.SetSpeed(seagullSpeed);



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

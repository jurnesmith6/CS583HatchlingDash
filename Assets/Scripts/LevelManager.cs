using System;
using UnityEngine;



    public class LevelManager : MonoBehaviour
    {
        public GameObject spawner;
        public static LevelManager instance;
        public int currentLevel = 1;
        int rows = 10;
        int cols = 3;
        float crabSpeed = 3f;
        float seagullSpeed = 5f;
        float seagullQuantum = 12f;
        int peakDiff = 30;
        

        void Awake()
        {
           
            instance = this;
            FindAnyObjectByType<Spawner>().SpawnTerrain(cols, rows);
            FindAnyObjectByType<Spawner>().SpawnCrab(crabSpeed);
            FindAnyObjectByType<Spawner>().SeagullSpawn(seagullSpeed, seagullQuantum);
           
        }

        public void NextLevel()
        {
            currentLevel++;
            Debug.Log("Level: " + currentLevel);
            
            // reset player position
            
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(19, -11, 0);
            
           

            // set difficult scaling and limit
            
            if (currentLevel % 5 == 0 && currentLevel <= 15 )
            {
                crabSpeed ++;
                cols++;
                seagullQuantum -= 2;

            } 
            if (currentLevel % 3 == 0 && currentLevel <= 18)
            {
                rows++; 
                seagullSpeed ++;
            }
            
            

            // clear and respawn enemies
            FindAnyObjectByType<Spawner>().SpawnTerrain(cols, rows);
            FindAnyObjectByType<Spawner>().SpawnCrab(crabSpeed);
            FindAnyObjectByType<Spawner>().SeagullSpawn(seagullSpeed, seagullQuantum);
        }

       
    }

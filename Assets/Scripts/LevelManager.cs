using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
    {
        public GameObject spawner;
        public static LevelManager instance;
        public int currentLevel = 1;
        public static ScoreCounter scoreCounter;
        int rows = 10;
        int cols = 3;
        float crabSpeed = 3f;
        float seagullSpeed = 10f;
        float seagullQuantum = 12f;
        int peakDiff = 30;
        

        void Awake()
        {
           
            // Find the ScoreCounter object 
            GameObject scoreGo = GameObject.Find("ScoreCounter");
            scoreCounter = scoreGo.GetComponent<ScoreCounter>();
            
            instance = this;
            FindAnyObjectByType<Spawner>().SpawnTerrain(cols, rows);
            FindAnyObjectByType<Spawner>().SpawnCrab(crabSpeed);
            FindAnyObjectByType<Spawner>().SeagullSpawn(seagullSpeed, seagullQuantum);
           
        }

        public void NextLevel()
        {

            
            scoreCounter.updateScore(++currentLevel);
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
        
        public void RestartGame()
        {
            
            HighScore.TRY_SET_HIGH_SCORE(currentLevel);
            StartCoroutine(DeathSequence());
            
        }

        IEnumerator DeathSequence()
        {
            // Freeze game
            Time.timeScale = 0f;
            
            yield return new WaitForSecondsRealtime(0.5f);

            // Unfreeze before reload
            Time.timeScale = 1f;
            
            // restart game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        

       
    }

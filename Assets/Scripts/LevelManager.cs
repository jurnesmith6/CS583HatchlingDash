using UnityEngine;



    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;
        public int currentLevel = 1;

        void Awake()
        {
            instance = this;
            FindAnyObjectByType<Spawner>().SpawnTerrain();
            FindAnyObjectByType<Spawner>().SpawnCrab();
        }

        public void NextLevel()
        {
            currentLevel++;
            Debug.Log("Level: " + currentLevel);
            
            // reset player position
            
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(19, -11, 0);
            
            // clear and respawn enemies

            FindAnyObjectByType<Spawner>().SpawnTerrain();
            FindAnyObjectByType<Spawner>().SpawnCrab();
        }
        
    }

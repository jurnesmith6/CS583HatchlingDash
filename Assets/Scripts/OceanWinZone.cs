using UnityEngine;

public class OceanWinZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            Debug.Log("Level " + LevelManager.instance.currentLevel+ " Complete!");
            LevelManager.instance.NextLevel();

        }
    }
}

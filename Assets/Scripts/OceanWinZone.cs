using UnityEngine;

public class OceanWinZone : MonoBehaviour
{
    
    public AudioClip oceanSplash;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            audioSource.PlayOneShot(oceanSplash);
            Debug.Log("Level " + LevelManager.instance.currentLevel+ " Complete!");
            LevelManager.instance.NextLevel();

        }
    }
}

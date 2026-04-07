using UnityEngine;

public class CrabAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;

    public float minTime = 2f;
    public float maxTime = 6f;

    void Start()
    {
        
        Invoke("PlayClick", Random.Range(minTime, maxTime));
    }

    void PlayClick()
    {
        audioSource.PlayOneShot(clickSound);
        Invoke("PlayClick", Random.Range(minTime, maxTime));
    }
}
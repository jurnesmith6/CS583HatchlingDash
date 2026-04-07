using UnityEngine;

public class SeagullAudio : MonoBehaviour
{
    public AudioClip seagullCall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource.PlayClipAtPoint(seagullCall, transform.position, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

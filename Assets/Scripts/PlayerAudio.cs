using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioClip footstepClip;
    public float stepInterval = 0.3f;

    private float stepTimer = 0;
    private Rigidbody2D rb;

    void Start()
    {
        footstepSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0.5f)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0)
            {
                footstepSource.PlayOneShot(footstepClip);
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0;
        }
    }
    
    
}
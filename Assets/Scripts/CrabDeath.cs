using UnityEngine;

public class CrabDeath : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("YOU DIED");
            
        }
    }
}


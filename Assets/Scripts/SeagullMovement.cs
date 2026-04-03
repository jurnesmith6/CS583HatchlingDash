using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float playerRadius = 10f;

    private Vector3 direction;
    private bool targetLock;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        
        direction = (player.position - transform.position);
        targetLock = true;
        
        
    }

    void Update()
    {

        if (direction.magnitude > playerRadius && targetLock)
        {
            //lock on to target
            direction = (player.position - transform.position);
            transform.position += direction.normalized * (speed * Time.deltaTime);
        }
        else
        {
            // lose lock
            targetLock = false;
            transform.position += direction.normalized * (2f * speed * Time.deltaTime);
                
        }

        if ((transform.position.x < -15 || transform.position.x > 55 || transform.position.y < -35 ||
             transform.position.y > 205))
        {
            Destroy(gameObject);
        }

    }
}

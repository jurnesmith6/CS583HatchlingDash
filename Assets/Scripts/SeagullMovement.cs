using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    public Transform player;
    float speed = 10f;
    private float diveSpeed = 15f;
    float playerRadius = 7f;
    float diveRadius = 15f;

    private Vector3 direction;
    private bool targetLock;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        
        direction = (player.position - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        targetLock = true;
        
        
    }

    void Update()
    {

        if (direction.magnitude > playerRadius && targetLock)
        {
            //lock on to target
            direction = (player.position - transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            transform.position += direction.normalized * (((direction.magnitude < diveRadius ) ? diveSpeed : speed) * Time.deltaTime);
        }
        else
        {
            // lose lock
            targetLock = false;
            
            transform.position += direction.normalized * (((direction.magnitude < playerRadius ) ? diveSpeed : speed) * Time.deltaTime);
                
        }

        if ((transform.position.x < -15 || transform.position.x > 55 || transform.position.y < -35 ||
             transform.position.y > 205))
        {
            Destroy(gameObject);
        }

    }
}

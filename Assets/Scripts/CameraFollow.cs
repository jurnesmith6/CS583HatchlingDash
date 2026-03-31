using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform target;
    public float offsetX = 0f;     // Horizontal camera offset
    public float offsetY = 5f;     // Vertical offset above the player
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {

        if (target != null)
        {
            // Only follow the Y (vertical) movement
            Vector3 newPosition = transform.position;
            newPosition.y = target.position.y + offsetY;
            newPosition.x = offsetX;        // fixed horizontal position
            newPosition.z = -10f;           // keep camera in front
            transform.position = newPosition;
        
        }
        
    }
}

using UnityEngine;

public class CrabMovement : MonoBehaviour
{
    
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;
    private Vector3 target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        // If close to target, switch direction
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float speed = 2.0f; 
    [SerializeField] float distance = 5.0f; 

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingToEnd = true;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0, distance, 0); 
    }

    void Update()
    {
        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            if (transform.position == endPosition)
            {
                movingToEnd = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (transform.position == startPosition)
            {
                movingToEnd = true;
            }
        }
    }

}

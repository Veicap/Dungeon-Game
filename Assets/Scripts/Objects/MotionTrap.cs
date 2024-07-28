using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTrap : MonoBehaviour
{
    [SerializeField] float speed = 0.5f; 
    [SerializeField] float distance = 3.0f; 
    [SerializeField] GameObject interactMotionTrapGameObject;
    private IInteractMotionTrap interactMotionTrap;
    private float timeToDestroy = 0.7f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingToEnd = true;
    private bool isTouching = false;

    void Start()
    {
        if (interactMotionTrap == null)
        {
            interactMotionTrap = interactMotionTrapGameObject.GetComponent<IInteractMotionTrap>();
        }
       //ebug.Log()
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(distance, 0, 0); 
        
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
        if(interactMotionTrap.IsTouchingMotionTrap())
        {
            isTouching = true;
        }
        if(isTouching)
        {
            interactMotionTrapGameObject.gameObject.SetActive(false);
            timeToDestroy -= Time.deltaTime;
            if (timeToDestroy < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

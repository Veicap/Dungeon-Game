using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apple : ItemCollection
{
    private bool isCounting = false;
    private void Update()
    {
        if (IsTouchingPlayer())
        {
            isFirstTime = true;
            if(!isCounting)
            {
                ItemCollectedManager.Instance.CountNumberOfAppleCollected();
            }
            isCounting = true;
        }
        if (isFirstTime)
        {

            timeToDestroy -= Time.deltaTime;
            if (timeToDestroy < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectedManager : MonoBehaviour
{
    public static ItemCollectedManager Instance {  get; private set; }  
    private int numberOfAppleCollected;
    private void Awake()
    {
        Instance = this;
        numberOfAppleCollected = 0;
    }
    public void CountNumberOfAppleCollected()
    {
        numberOfAppleCollected++;
    }
    public int GetNumberOfAppleCollected()
    {
        return numberOfAppleCollected;
    }
    
}

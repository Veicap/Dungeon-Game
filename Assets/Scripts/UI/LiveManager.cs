using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LiveManager : MonoBehaviour
{
    public static LiveManager Instance { get; private set; }
    private int numberOfLive;
    [SerializeField] GameObject heart;
    private List<GameObject> heartList;
    private float loselifeTimer = 1f;
    private float counter = 1f;
    private bool canTrap = true;
    private void Awake()
    {
        Instance = this;
        heart.SetActive(false);
        numberOfLive = 3;
        heartList = new List<GameObject>();

    }
    private void Start()
    {
        for(int i = 0; i < numberOfLive; i++)
        {
            GameObject heartObject = Instantiate(heart, gameObject.transform);
            heartObject.transform.localPosition = Vector3.zero;
            heartObject.SetActive(true);
            heartList.Add(heartObject);

        }
    }
    private void Update()
    {
        if(Player.Instance.IsTrap())
        {
            if(canTrap)
            {
                counter = loselifeTimer;
                if(heartList.Count > 0)
                {
                    Destroy(heartList[heartList.Count - 1]);
                    heartList.RemoveAt(heartList.Count - 1);
                }
                
                canTrap = false;
            }
            
            
        }
        if (!canTrap)
        {
            counter -= Time.deltaTime;
            if (counter < 0)
            {
                canTrap = true;

            }
        }
        
    }
    public bool IsAlive()
    {
        if(heartList.Count == 0)
        {
            return false;
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] questionPool;
    [SerializeField] private int victoryPoints = 3;
    [SerializeField] private int defeatThreshhold = -3;
    [HideInInspector] public int currentPoints;
    private string[] answers = new string[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoints == victoryPoints)
        {
            Debug.Log("YOU WIN");
        }
        if(currentPoints == defeatThreshhold)
        {
            Debug.Log("YOU SUCK!!1!!11!");
        }
    }

    void ReducePoints()
    {
        currentPoints--;
    }
    void AddPoints()
    {
        currentPoints++;
    }
}

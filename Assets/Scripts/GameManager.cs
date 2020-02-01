using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] questionPool;
    [SerializeField] private int victoryPoints = 3;
    [SerializeField] private int defeatThreshhold = 3;
    [HideInInspector] public int correct = 0;
    [HideInInspector] public int wrong = 0;

    private string[] answers = new string[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(correct == victoryPoints)
        {
            Debug.Log("YOU WIN");
        }
        if(wrong == defeatThreshhold)
        {
            Debug.Log("YOU SUCK!!1!!11!");
        }
    }

    void ReducePoints()
    {
        wrong++;
    }
    void AddPoints()
    {
        correct++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{
    public string joke;
    public string rightAnswer;
    public string wrongAnswer_1;
    public string wrongAnswer_2;
    public string wrongAnswer_3;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    [SerializeField] private AnimationManager animationManager;
    [SerializeField] private Question[] questionPool;
    [SerializeField] private int defeatThreshhold = 3;
    [HideInInspector] public int wrong = 0;

    private string[] answers = new string[3];
    private string[] randomizedAnswers = new string[3];
    private int[] randomQuestionsIndex;

    [SerializeField] private int maxQuestions = 10;
    private int questionIndex = 0;

    private bool failed = false;
    private bool answered = false;



    private void Start()
    {
        randomQuestionsIndex = new int[maxQuestions - 1];
    }


    private void ReducePoints()
    {
        wrong++;
        if (wrong == defeatThreshhold)
        {
            failed = true;
        }
    }


    private void MakeAnwserArray()
    {
        answers[0] = questionPool[questionIndex].correctAnswer;
        answers[1] = questionPool[questionIndex].wrongAnswer_1;
        answers[2] = questionPool[questionIndex].wrongAnswer_2;
    }


    private void RandomizeAnswers()
    {
        MakeAnwserArray();
        //Randomize
    }


    private void RandomizeQuestions()
    {
        // Randomize




        RandomizeAnswers();
    }


    public void CheckAnswer()
    {
        if (GetComponentInChildren<TMPro.TextMeshProUGUI>().text == questionPool[randomQuestionsIndex[questionIndex]].correctAnswer)
        {
            // Play animation
        }
        else
        {
            // Play animation
            ReducePoints();
        }
        answered = true;
    }


    private IEnumerator StartGameSession()
    {
        ResetGame();
        // Curtain comes animation
        while (questionIndex < maxQuestions && failed == false)
        {
            RandomizeAnswers();
            uiController.SetQuizText(questionPool[randomQuestionsIndex[questionIndex]].joke, randomizedAnswers[0], randomizedAnswers[1], randomizedAnswers[2]);
            while (answered == false)
            {
                yield return new WaitForSeconds(1);
            }
            // Wait x second, depends on animation duration
            yield return new WaitForSeconds(1);
            questionIndex = questionIndex + 1;
            answered = false;
        }
        // play ending animation, enable main menu
        // Wait x second, depends on animation duration
        yield return new WaitForSeconds(1);

    }


    private void ResetGame()
    {
        questionIndex = 0;
        failed = false;
        wrong = 0;
    }


    public void PlayGame()
    {
        StartCoroutine(StartGameSession());
    }


    public void EndGame()
    {
        // Play animation, enable main menu
        StopCoroutine(StartGameSession());
    }
}

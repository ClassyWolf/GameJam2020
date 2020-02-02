using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    [SerializeField] private AnimationManager animationManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Question[] questionPool;
    [SerializeField] private int defeatThreshhold = 3;
    [HideInInspector] public int wrong = 0;

    //private string[] answers = new string[3];
    private List<string> answers = new List<string>();
    private int[] randomQuestionsIndex;

    [SerializeField] private int maxQuestions = 10;
    private int questionIndex = 0;

    private bool failed = false;
    private bool answered = false;
    private string tempAnswer;

    private List<Question> questions = new List<Question>();



    private void Start()
    {
        animationManager.CurtainOpen();
        randomQuestionsIndex = new int[maxQuestions];
    }


    private void ReducePoints()
    {
        wrong++;
        if (wrong == defeatThreshhold)
        {
            failed = true;
        }
    }


    private void MakeAnwserList()
    {
        answers.Clear();
        answers.Add(questions[questionIndex].correctAnswer);
        answers.Add(questions[questionIndex].wrongAnswer_1);
        answers.Add(questions[questionIndex].wrongAnswer_2);
    }


    private void RandomizeAnswers()
    {
        //Randomize
        Debug.Log("randomize answers");
        MakeAnwserList();
        Shuffle(answers);
        Debug.Log("answers randomized");
    }


    private void RandomizeQuestions()
    {
        Debug.Log("randomising questions");

        for (int i = 0; i < questionPool.Length; i++)
        {
            questions.Add(questionPool[i]);
        }
        Shuffle(questions);
        Debug.Log("questions randomized");
    }

    public IList Shuffle(IList ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
        return ts;
    }


    public void CheckAnswer_Button_1()
    {
        tempAnswer = uiController.answerButtonText_1.GetComponent<TMPro.TextMeshProUGUI>().text;
        if (tempAnswer == questions[questionIndex].correctAnswer)
        {
            // Play animation
            Debug.Log("Correct answer");
        }
        else
        {
            // Play animation
            Debug.Log("Wrong answer");
            ReducePoints();
            uiController.LoseTomatoes();
        }
        answered = true;
    }


    public void CheckAnswer_Button_2()
    {
        tempAnswer = uiController.answerButtonText_2.GetComponent<TMPro.TextMeshProUGUI>().text;
        if (tempAnswer == questions[questionIndex].correctAnswer)
        {
            // Play animation
        }
        else
        {
            // Play animation
            ReducePoints();
            uiController.LoseTomatoes();
        }
        answered = true;
    }


    public void CheckAnswer_Button_3()
    {
        tempAnswer = uiController.answerButtonText_3.GetComponent<TMPro.TextMeshProUGUI>().text;
        if (tempAnswer == questions[questionIndex].correctAnswer)
        {
            // Play animation
        }
        else
        {
            // Play animation
            ReducePoints();
            uiController.LoseTomatoes();
        }
        answered = true;
    }


    private IEnumerator StartGameSession()
    {
        ResetGame();
        StartCoroutine(ToGameAndMainMenu());
        RandomizeQuestions();
        while (questionIndex < maxQuestions && failed == false)
        {
            Debug.Log("In loop");
        yield return new WaitForSeconds(1);
            RandomizeAnswers();
            uiController.SetQuizText(questions[questionIndex].joke, answers[0], answers[1], answers[2]);
        yield return new WaitUntil(() => answered);
           uiController.FillQuiz(questions[questionIndex].joke, tempAnswer);
            // Wait x second, depends on animation duration
            yield return new WaitForSeconds(1);
            questionIndex = questionIndex + 1;
            answered = false;
        }
        // play ending animation, enable main menu
        StartCoroutine(GameEnding());
        Debug.Log("Done");
    }


    private void ResetGame()
    {
        uiController.ResetTomatotoes();
        questionIndex = 0;
        failed = false;
        wrong = 0;
    }


    public void PlayGame()
    {
        Debug.Log("Playing");
        StartCoroutine(StartGameSession());
    }


    public void EndGame()
    {
        StopCoroutine(StartGameSession());
        StartCoroutine(ToGameAndMainMenu());
    }


    private IEnumerator Quitting()
    {
        animationManager.CurtainClose();
        yield return new WaitForSeconds(0.7f);
        Application.Quit();
    }


    public void QuitGame()
    {
        StartCoroutine(Quitting());
    }


    private IEnumerator ToGameAndMainMenu()
    {
        animationManager.CurtainClose();
        yield return new WaitForSeconds(0.7f);
        uiController.MainMenuPanelState();
        uiController.GamePanelState();
        yield return new WaitForSeconds(0.5f);
        animationManager.CurtainOpen();
        yield return new WaitForSeconds(0.7f);
    }


    private IEnumerator GameEnding()
    {
        // Show ending panel
        animationManager.CurtainClose();
        yield return new WaitForSeconds(0.7f);
        uiController.GamePanelState();
        uiController.EndingText(wrong);
        uiController.EndGamePanelState();
        yield return new WaitForSeconds(0.5f);
        animationManager.CurtainOpen();
        yield return new WaitForSeconds(0.7f);

        yield return new WaitForSeconds(1f);

        // Back to main
        animationManager.CurtainClose();
        yield return new WaitForSeconds(0.7f);
        uiController.MainMenuPanelState();
        uiController.EndGamePanelState();
        yield return new WaitForSeconds(0.5f);
        animationManager.CurtainOpen();
        yield return new WaitForSeconds(0.7f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] AnimationManager aniManager;
    [SerializeField] GameManager gM;
    [SerializeField] GameObject[] startScene;
    [SerializeField] GameObject[] scene;
    [SerializeField] GameObject[] endScene;

    [SerializeField] TextMeshProUGUI jokeText;
    [SerializeField] TextMeshProUGUI answerButtonText_1;
    [SerializeField] TextMeshProUGUI answerButtonText_2;
    [SerializeField] TextMeshProUGUI answerButtonText_3;
    [SerializeField] private GameObject[] answerButtons;

    [SerializeField] private TextMeshProUGUI endingText;


    void Intro()
    {
        gM.wrong = 0;

        for (int i = 0; i <= startScene.Length; i++)
            startScene[i].SetActive(true);

        for (int i = 0; i <= scene.Length; i++)
            scene[i].SetActive(false);

        for (int i = 0; i <= endScene.Length; i++)
            endScene[i].SetActive(false);
    }


    void Scene()
    {
        //add call to the curtain animation here

        for (int i = 0; i <= startScene.Length; i++)
            startScene[i].SetActive(false);

        for (int i = 0; i <= scene.Length; i++)
            scene[i].SetActive(true);

        for (int i = 0; i <= endScene.Length; i++)
            endScene[i].SetActive(false);
    }


    void Outro()
    {
        //add call to the curtain animation here

        for (int i = 0; i <= startScene.Length; i++)
            startScene[i].SetActive(true);

        for (int i = 0; i <= scene.Length; i++)
            scene[i].SetActive(false);

        for (int i = 0; i <= endScene.Length; i++)
            endScene[i].SetActive(false);
    }


    public void SetQuizText(string joke, string answer_1, string answer_2, string answer_3)
    {
        foreach (var button in answerButtons)
        {
            button.SetActive(true);
        }

        jokeText.text = joke + " __________";
        answerButtonText_1.text = answer_1;
        answerButtonText_2.text = answer_2;
        answerButtonText_3.text = answer_3;
    }


    public void FillQuiz(string joke, string answer)
    {
        foreach (var button in answerButtons)
        {
            button.SetActive(false);
        }

        jokeText.text = joke + " " + answer;
    }
}

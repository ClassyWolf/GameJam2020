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
    public TextMeshProUGUI answerButtonText_1;
    public TextMeshProUGUI answerButtonText_2;
    public TextMeshProUGUI answerButtonText_3;
    [SerializeField] private GameObject[] answerButtons;

    [SerializeField] private TextMeshProUGUI endingText;

    [SerializeField] private GameObject[] tomateImages;
    private int tomatoCounter = 0;


    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject mainmenuPanel;
    [SerializeField] GameObject endgamePanel;

    [SerializeField] private GameObject[] muteImages;

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


    private IEnumerator LoseTomato()
    {
        tomatoCounter = tomatoCounter + 1;

        yield return new WaitForSeconds(1);

        if (tomatoCounter == 1)
        {
            tomateImages[0].SetActive(false);
        }
        if (tomatoCounter == 2)
        {
            tomateImages[1].SetActive(false);
        }
        if (tomatoCounter == 3)
        {
            tomateImages[2].SetActive(false);
        }
    }


    public void LoseTomatoes()
    {
        StartCoroutine(LoseTomato());
    }


    public void ResetTomatotoes()
    {
        tomatoCounter = 0;
        tomateImages[0].SetActive(true);
        tomateImages[1].SetActive(true);
        tomateImages[2].SetActive(true);
    }


    public void GamePanelState()
    {
        if (gamePanel.activeInHierarchy == true)
        {
            gamePanel.SetActive(false);
        }
        else
        {
            gamePanel.SetActive(true);
        }
    }


    public void MainMenuPanelState()
    {
        if (mainmenuPanel.activeInHierarchy == true)
        {
            mainmenuPanel.SetActive(false);
        }
        else
        {
            mainmenuPanel.SetActive(true);
        }
    }


    public void EndGamePanelState()
    {
        if (endgamePanel.activeInHierarchy == true)
        {
            endgamePanel.SetActive(false);
        }
        else
        {
            endgamePanel.SetActive(true);
        }
    }


    public void EndingText(int wrongAnswers)
    {
        if (wrongAnswers == 3)
        {
            endingText.text = "You lost! The audience was not happy with your performance.";
        }
        else
        {
            endingText.text = "You won! The audience was enthralled with your performance.";
        }
    }

    public void ChangeMuteImage()
    {
        if (muteImages[0].activeInHierarchy == true )
        {
            muteImages[0].SetActive(false);
            muteImages[1].SetActive(true);
        }
        else
        {
            muteImages[0].SetActive(true);
            muteImages[1].SetActive(false);
        }
    }
}

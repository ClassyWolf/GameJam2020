using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] AnimationManager aniManager;
    [SerializeField] GameManager gM;
    [SerializeField] GameObject[] startScene;
    [SerializeField] GameObject[] scene;
    [SerializeField] GameObject[] endScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Intro()
    {
        gM.correct = 0;
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
}

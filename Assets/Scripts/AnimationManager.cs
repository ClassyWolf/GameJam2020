﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator curtainAnim;

    private bool curtainsOpen = false;

    public void Curtains()
    {
        if (curtainsOpen == true)
            curtainsOpen = false;
        else
            curtainsOpen = true;
        //add the opening and end curtains
        StartCoroutine("CurtainStates");
    }

    IEnumerator CurtainStates()
    {
        if(curtainsOpen == false)
            curtainAnim.Play("CurtainsOpen");
        if(curtainsOpen == true)
            curtainAnim.Play("CurtainsClose");

        yield return new WaitForSeconds(0.30f);
    }

    void Kick()
    {
        //if wrong answer, comedian kicks stuff in face
    }

    void DissapointmentObjects()
    {
        //boos and audience throwing shit in the commedians face
    }

    void AppreciationObjects()
    {
        //applause and roses and other shit
    }

    void SpeachBubbles()
    {
        //speachbubbles have slight animation to make them less statik
    }
}

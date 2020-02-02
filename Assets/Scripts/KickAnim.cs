using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickAnim : MonoBehaviour
{
    public Animator animator;
    

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();    
    }

    void Update()
    {
            
    }
}

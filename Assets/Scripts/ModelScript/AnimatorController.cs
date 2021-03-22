using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator arm;
    public Animator cockpit;
    public Animator cabin;
    public Animator railL;
    public Animator railR;
    public Animator engine;

    private void Start()
    {
    }

    public virtual void Separate()
    {
        arm.SetBool("separate", true);
        cockpit.SetBool("separate", true);
        cabin.SetBool("separate", true);
        railL.SetBool("separate", true);
        railR.SetBool("separate", true);
        engine.SetBool("separate", true);
    }
    
    public virtual void DeSeparate()
    {
        arm.SetBool("separate", false);
        cockpit.SetBool("separate", false);
        cabin.SetBool("separate", false);
        railL.SetBool("separate", false);
        railR.SetBool("separate", false);
        engine.SetBool("separate", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacAnimController : MonoBehaviour
{

    [SerializeField] private Animator baseAnim;
    [SerializeField] private Animator bearingAnim;
    [SerializeField] private Animator coverAnim;
    [SerializeField] private Animator fanHolderAnim;
    [SerializeField] private Animator gaintAnim;
    [SerializeField] private Animator noselAnim;
    //[SerializeField] private Animator VanesAnim;
    [SerializeField] private Animator RollerAnim;
    [SerializeField] private Animator FrontCovanim;

    public void Separate()
    {
        baseAnim.SetBool("separate", true);
        bearingAnim.SetBool("separate", true);
        coverAnim.SetBool("separate", true);
        fanHolderAnim.SetBool("separate", true);
        gaintAnim.SetBool("separate", true);
        noselAnim.SetBool("separate", true);
        //VanesAnim.SetBool("separate", true);
        RollerAnim.SetBool("separate", true);
        FrontCovanim.SetBool("separate", true);
    }
    public void DeSeparate()
    {
        baseAnim.SetBool("separate", false);
        bearingAnim.SetBool("separate", false);
        coverAnim.SetBool("separate", false);
        fanHolderAnim.SetBool("separate", false);
        gaintAnim.SetBool("separate", false);
        noselAnim.SetBool("separate", false);
        //VanesAnim.SetBool("separate", false);
        RollerAnim.SetBool("separate", false);
        FrontCovanim.SetBool("separate", false);
    }
}

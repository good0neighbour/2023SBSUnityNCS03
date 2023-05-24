using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUnit : MonoBehaviour
{
    [SerializeField]
    Animator mAnimator = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoAniIdle()
    {
        mAnimator.SetTrigger("trigIdle");
    }
    public void DoAniRSP()
    {
        mAnimator.SetBool("bRSP", true);
    }
}

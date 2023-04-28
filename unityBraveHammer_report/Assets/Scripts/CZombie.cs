using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CZombie : CEnemy//MonoBehaviour
{

    public Animator mpAnimator = null;
    // Start is called before the first frame update
    void Start()
    {
        mpAnimator =
            GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void DoAniDamage()
    {
        Debug.Log("CSlime.DoAniDamage");
        mpAnimator.SetTrigger("trigAniDamage");
    }
}

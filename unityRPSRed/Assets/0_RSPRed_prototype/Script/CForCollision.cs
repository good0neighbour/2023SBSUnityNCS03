using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CForCollision : MonoBehaviour
{
    [SerializeField]
    CGrid mGrid = null;

    [SerializeField]
    CUnit[] mUnits = null;

    [SerializeField]
    CUIPlayGame mUIPlayGame = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CForCollision.OnTriggerEnter");

        //직접 호출하겠다.
        mGrid.DoStopScroll();

        //mUnits[0].DoAniIdle();
        foreach (var t in mUnits)
        {
            t.DoAniIdle();
        }

        mUIPlayGame.Show();
    }
}

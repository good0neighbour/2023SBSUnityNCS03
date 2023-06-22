using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAttribute_1 : MonoBehaviour
{
    [ContextMenuItem("Random", "DoRandomNumber")]
    [ContextMenuItem("Reset", "DoResetNumber")]
    [SerializeField]
    int mNumber = 0;

    void DoRandomNumber()
    {
        mNumber = Random.Range(0, 100);
    }
    void DoResetNumber()
    {
        mNumber = 0;
    }
}

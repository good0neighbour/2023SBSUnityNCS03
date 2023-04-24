using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScenePlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CRyuMgr.GetInst();
        
        Debug.Log(CRyuMgrStaticConstructor.GetInst.mTestScore.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

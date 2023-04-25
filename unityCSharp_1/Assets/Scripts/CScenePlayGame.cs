using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScenePlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //쌩 클래스, GetInst호출 시 만들어진다.
        CRyuMgr.GetInst();
        
        //쌩 클래스, 정적생성자를 이용하여 mpInst선언 시 할당되어 만들어진다
        Debug.Log(CRyuMgrStaticConstructor.GetInst.mTestScore.ToString());


        //MonoBehaviour를 고려하여 만들어진 것.유니티 에디터 상에서 배치를 통해 미리 만들어져 있다.
        Debug.Log(CRyuMgrMono.GetInst.mTestExp.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

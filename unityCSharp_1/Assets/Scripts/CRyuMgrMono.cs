using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgrMono : MonoBehaviour
{
    private static CRyuMgrMono mpInst = null;
    //선언 시 할당할 것이 아니다.
    //생성자에서 할당할 것도 아니다.
    //<-- 그러므로 readonly는 적용하지 않았다.

    //프로퍼티
    public static CRyuMgrMono GetInst
    {
        get
        {
            if (null == mpInst)
            {
                //FindObjectOfType<T>()
                //해당 클래스 스크립트 컴포넌트가 부착된 게임오브젝트를 검색하여 찾는 것이다.
                mpInst = FindObjectOfType<CRyuMgrMono>() as CRyuMgrMono;
            }

            return mpInst;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

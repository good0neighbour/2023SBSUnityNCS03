using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgrMono : MonoBehaviour
{
    //데이터를 전역적으로 관리한다고 가정
    public int mTestExp = 1024;

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

    //게임오브젝트가 생성되면 가장 먼저 호출되는 이벤트 함수
    //( MonoVehaviour의 생성자 역할 정도를 한다라고 보면 된다 )
    private void Awake()
    {
        if(null == mpInst)
        {
            mpInst = this;
        }
        else if(null != mpInst)
        {
            //Destroy
            //유니티에서 준비해둔, 게임오브젝트를 소멸 시키는 함수
            Destroy(this.gameObject);
        }

        //DontDestroyOnLoad
        //유니티에서 준비해둔, 게임오브젝트를 유지시키는 함수( 이를테면 장면 전환시에도 삭제하지 않고 유지 )
        DontDestroyOnLoad(this.gameObject);
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

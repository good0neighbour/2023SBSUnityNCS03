using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgr
{
    private static CRyuMgr mpInst = null;

    //prefab link
    public CUnit PFUnit = null;

    //object pooling collection
    Stack<CUnit> mUnitStack = null;
    //<--CUnit은 참조타입

    //singleton pattern 적용
    private CRyuMgr()
    {
        mpInst = null;
    }

    public static CRyuMgr GetInst()
    {
        if (null == mpInst)
        {
            mpInst = new CRyuMgr();
        }
        return mpInst;
    }

    //미리 객체를 확보한다.
    public void CreateRyu()
    {
        if (null == PFUnit)
        {
            PFUnit = Resources.Load<CUnit>("PFUnit");
        }


        if (null == mUnitStack)
        {
            mUnitStack = new Stack<CUnit>();
        }

        if (null != mUnitStack)
        {
            //일단 n개만 만든다.(여기서는 일단 5개를 하겠다 )
            int ti = 0;
            int tCount = 5;
            CUnit tUnit = null;

            for (ti = 0; ti < tCount; ++ti)
            {
                tUnit = null;
                tUnit = GameObject.Instantiate<CUnit>(PFUnit, Vector3.zero, Quaternion.identity);

                GameObject.DontDestroyOnLoad(tUnit.gameObject);
                tUnit.gameObject.SetActive(false);//메모리에 할당되어 있지만 비활성화

                mUnitStack.Push(tUnit);
            }
        }
    }

    //객체 풀을 이용하여 객체를 할당(실제로 할당은 아니다)<--게임오브젝트를 활성
    public CUnit NewUnit()
    {
        CUnit t = null;

        //스택(pool)에서 가져온다
        if (mUnitStack.Count > 0)
        {
            t = mUnitStack.Pop();
        }
        else
        {
            //풀pool이 없으므로 좀더 확보한다.
            //일단 m개만 만든다.(여기서는 일단 5개를 하겠다 )
            int ti = 0;
            int tCount = 5;
            CUnit tUnit = null;

            for (ti = 0; ti < tCount; ++ti)
            {
                tUnit = null;
                tUnit = GameObject.Instantiate<CUnit>(PFUnit, Vector3.zero, Quaternion.identity);

                GameObject.DontDestroyOnLoad(tUnit.gameObject);
                tUnit.gameObject.SetActive(false);//메모리에 할당되어 있지만 비활성화

                mUnitStack.Push(tUnit);
            }

            //스택(pool)에서 가져온다
            t = mUnitStack.Pop();
        }


        t.gameObject.SetActive(true);
        t.CreatRyu();//<--해당 유닛에서 동작할당?시 필요한 처리를 수행한다(이를테면 코루틴 등)

        return t;
    }
    //객체 풀을 이용하여 객체를 해제(실제로 해제는 아니다)<--게임오브젝트를 비활성
    public void DeleteUnit(CUnit t)
    {
        t.DestroyRyu();//<--해당 유닛에서 해제?시 필요한 처리를 수행한다(이를테면 코루틴 등)
        t.gameObject.SetActive(false);
        //스택(pool)에 다시 넣는다
        mUnitStack.Push(t);
    }
}

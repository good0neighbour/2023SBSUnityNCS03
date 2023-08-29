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
}

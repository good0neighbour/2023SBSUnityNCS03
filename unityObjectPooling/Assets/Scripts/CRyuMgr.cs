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
    //<--CUnit�� ����Ÿ��

    //singleton pattern ����
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

    //�̸� ��ü�� Ȯ���Ѵ�.
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
            //�ϴ� n���� �����.(���⼭�� �ϴ� 5���� �ϰڴ� )
            int ti = 0;
            int tCount = 5;
            CUnit tUnit = null;

            for (ti = 0; ti < tCount; ++ti)
            {
                tUnit = null;
                tUnit = GameObject.Instantiate<CUnit>(PFUnit, Vector3.zero, Quaternion.identity);

                GameObject.DontDestroyOnLoad(tUnit.gameObject);
                tUnit.gameObject.SetActive(false);//�޸𸮿� �Ҵ�Ǿ� ������ ��Ȱ��ȭ

                mUnitStack.Push(tUnit);
            }
        }
    }
}

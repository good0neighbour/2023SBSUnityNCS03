using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgrMono : MonoBehaviour
{
    private static CRyuMgrMono mpInst = null;
    //���� �� �Ҵ��� ���� �ƴϴ�.
    //�����ڿ��� �Ҵ��� �͵� �ƴϴ�.
    //<-- �׷��Ƿ� readonly�� �������� �ʾҴ�.

    //������Ƽ
    public static CRyuMgrMono GetInst
    {
        get
        {
            if (null == mpInst)
            {
                //FindObjectOfType<T>()
                //�ش� Ŭ���� ��ũ��Ʈ ������Ʈ�� ������ ���ӿ�����Ʈ�� �˻��Ͽ� ã�� ���̴�.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScenePlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�� Ŭ����, GetInstȣ�� �� ���������.
        CRyuMgr.GetInst();
        
        //�� Ŭ����, ���������ڸ� �̿��Ͽ� mpInst���� �� �Ҵ�Ǿ� ���������
        Debug.Log(CRyuMgrStaticConstructor.GetInst.mTestScore.ToString());


        //MonoBehaviour�� ����Ͽ� ������� ��.����Ƽ ������ �󿡼� ��ġ�� ���� �̸� ������� �ִ�.
        Debug.Log(CRyuMgrMono.GetInst.mTestExp.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

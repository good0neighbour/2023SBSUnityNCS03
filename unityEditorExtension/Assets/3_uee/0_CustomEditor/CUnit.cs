using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUnit : MonoBehaviour//<--Unity�� Object�迭�̹Ƿ� �翬�� ����ȭ �����
{
    public CUnitInfo mInfo = null;//<--Serializable�� ����� Ŀ���� Ŭ����Ÿ���� �������

    public CUnitInfo[] mInfos = null;

    [Range(0, 255)]
    public int mBaseAP = 0;//<--����Ƽ�� ����ȭ ��Ģ�� ������ public ����� ����� ����ȭ��
    [Range(0, 99)]
    public int mEndurance = 0;
    [Range(0, 9)]
    public int mStr = 0;

    //������Ƽ<--����Ƽ�� �⺻ ����ȭ ��Ģ���� ���ܵ�
    public int mAP
    {
        get
        {
            //������ �������� ���ݷ� ����
            return mBaseAP + Mathf.FloorToInt(mBaseAP * (mEndurance + mStr - 8) / 16);
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

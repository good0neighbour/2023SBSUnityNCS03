using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

//������ Ŭ���� �뵵�� Ŭ������. ����� public

//��¥ Ŭ������ ����ȭ�� �����ϴ� �Ӽ�
[Serializable]
public class CUnitInfo
{
    //�������
    [Range(0, 255)]
    public int mBaseAP = 0;//<--����Ƽ�� ����ȭ ��Ģ�� ������ public ����� ����� ����ȭ��
    [Range(0, 255)]
    public int mEndurance = 0;
    [Range(0, 255)]
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
}

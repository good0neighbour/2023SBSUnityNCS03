using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[Serializable]
//�������� �������� ����
public class CItemData
{
    public int mId = 0; //�ش� �������� ����ũ�� �ĺ���

    public string mName = "";   //�������� �̸� ����
    public string mDesc = "";   //�������� �� ���� ����

    public int mRscId = 0;  //�������� UI���� ǥ�� �̹��� ����

    //�� �ܿ� ���� ���ȿ� ���� ������ ���� �� �ְڴ�.
    public int mCritialRatio = 0;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    CRyuSnd ������ �����ϴ� ������ Ŭ����

    �������� <-- �ڷᱸ���� ����
    Play
    Stop
*/
public class CRyuSndMgr
{
    private static CRyuSndMgr mInstance = null;

    //AudioSource�� �����ϴ� �ڷᱸ��
    //�˻��� Ű�� string <--�ҽ��ڵ� �ۼ� �� ���������� �ϱ� ����, 
    //Dictionary�� ������ ������ �˻��� �ð����⵵�� O(1)�̱� ������ �˻��� �ſ� �����Ƿ�
    public Dictionary<string, AudioSource> mDictionary = new Dictionary<string, AudioSource>();

    private CRyuSndMgr()
    {
        mInstance = null;
    }

    public static CRyuSndMgr GetInst()
    {
        if (null == mInstance)
        {
            mInstance = new CRyuSndMgr();
        }
        return mInstance;
    }

    //����AudioSource ������ ���
    public void DoRegist(AudioSource tAS)
    {
        //�����߰�
        mDictionary.Add(tAS.clip.name, tAS);
    }

    //����AudioSource ������ ��� ����
    public void DoUnRegist(AudioSource tAS)
    {
        //���һ���
        mDictionary.Remove(tAS.clip.name);
    }

    public void testDisplayAll()
    {
        foreach (KeyValuePair<string, AudioSource> t in mDictionary)
        {
            Debug.Log(t.Key);
        }
    }





    public void Play(string tKey)
    {
        //O(1)
        mDictionary[tKey].Play();
    }
    public void Stop(string tKey)
    {
        //O(1)
        mDictionary[tKey].Stop();
    }
}

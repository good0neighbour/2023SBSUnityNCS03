using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    CRyuSnd 음원을 관리하는 관리자 클래스

    음원관리 <-- 자료구조로 관리
    Play
    Stop
*/
public class CRyuSndMgr
{
    private static CRyuSndMgr mInstance = null;

    //AudioSource를 관리하는 자료구조
    //검색의 키는 string <--소스코드 작성 시 직관적으로 하기 위해, 
    //Dictionary를 선택한 이유는 검색의 시간복잡도가 O(1)이기 때문에 검색이 매우 빠르므로
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

    //음원AudioSource 정보를 등록
    public void DoRegist(AudioSource tAS)
    {
        //원소추가
        mDictionary.Add(tAS.clip.name, tAS);
    }

    //음원AudioSource 정보를 등록 해제
    public void DoUnRegist(AudioSource tAS)
    {
        //원소삭제
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

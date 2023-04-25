/*
    Collection

        .NET Framwork에서 제공하는 자료구조

    Collection.Generic

        .NET Framwork에서 제공하는 일반화된(타입에 대해서 범용적인) 자료구조


    Array
        배열

        모든 배열의 암묵적인 부모클래스
        CLR은 배열에 대해서 '연속된 메모리 공간'을 할당한다
        그러므로, 인덱스로 접근하는 속도가 매우 빠르다.
        또한 캐쉬적중률을 높이므로 빠르다.
        그러나, 일단 생성된 배열의 크기는 고정된다.

        배열 자체는 참조 타입이다.


    List<T>
        가변배열

        실행 중에 원소를 추가, 삭제 가능한 배열이다.
        맨 끝에 원소를 추가, 삭제하는 것은 효율적으로 이루어지지만 중간에 삽입하는 것은 속도면에서 비효율적이다.
*/

//Array에 기능을 사용하기 위해
using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CExam_0 : MonoBehaviour
{
    //a가 포함되어 있는지 여부 검사 함수
    bool IsContain_a(string tName)
    {
        return tName.Contains("a");
    }

    // Start is called before the first frame update
    void Start()
    {
        //int[] tArray = new int[3] { 1, 2, 3 };
        int[] tArray = { 3, 2, 1 };

        //열거문
        //foreach열거문은 Object를 대상으로 만들어져 있다.
        //그래서 값타입을 쓰면 boxing이 일어나는 것이다.
        //그러므로 느리다.
        foreach(var t in tArray)
        {
            Debug.Log(t.ToString());
        }

        Array.Sort(tArray);

        Debug.Log("after sort");
        foreach (var t in tArray)
        {
            Debug.Log(t.ToString());
        }


        //string[] tNames = new string[3] { "Robert", "Jack", "Gill" };
        string[] tNames = { "Robert", "Jack", "Gill" };
        foreach (var t in tNames)
        {
            Debug.Log(t);
        }

        //Array.Find 함수
        string tResult = Array.Find<string>(tNames, IsContain_a);
        Debug.Log($"find {tResult}");



        //가변배열
        List<int> tInts = new List<int>();

        //실행 중에 원소를 추가 가능하다.
        tInts.Add(3);
        tInts.Add(2);
        tInts.Add(1);

        Debug.Log("List<int>========");
        foreach(var t in tInts)
        {
            Debug.Log(t.ToString());
        }

        tInts.Sort();

        foreach (var t in tInts)
        {
            Debug.Log(t.ToString());
        }

        List<string> tJobs = new List<string>();

        tJobs.Add("knight");
        tJobs.Add("magician");

        for(int ti = 0; ti < tJobs.Count; ++ti)
        {
            Debug.Log(tJobs[ti]);
        }

        tJobs.AddRange(new string[] { "paladin", "druid" });
        Debug.Log("after AddRange========");
        for (int ti = 0; ti < tJobs.Count; ++ti)
        {
            Debug.Log(tJobs[ti]);
        }


        tJobs.Insert(0, "fighter");
        Debug.Log("after Insert========");
        for (int ti = 0; ti < tJobs.Count; ++ti)
        {
            Debug.Log(tJobs[ti]);
        }


        tJobs.InsertRange(1, new string[] { "gobline", "slime" });
        Debug.Log("after InsertRange========");
        for (int ti = 0; ti < tJobs.Count; ++ti)
        {
            Debug.Log(tJobs[ti]);
        }

        tJobs.RemoveAt(3);
        tJobs.Remove("fighter");
        Debug.Log("after Remove========");
        for (int ti = 0; ti < tJobs.Count; ++ti)
        {
            Debug.Log(tJobs[ti]);
        }

        tJobs.RemoveRange(0, 2);    //index, count
        Debug.Log("after RemoveRange========");
        for (int ti = 0; ti < tJobs.Count; ++ti)
        {
            Debug.Log(tJobs[ti]);
        }


        Debug.Log("ForEach========");
        //여기의 ForEach는 List<T>에 관해 만들어져 있다. 성능상 불이익은 없다.
        //열거, 순회구문, 순회하면서 해야될 일을 델리게이트로 만든다.
        //여기서는 람다를 만들어 델리게이트에 넘겼다.
        tJobs.ForEach(t => { Debug.Log(t); });

        tJobs.RemoveAll(t => t.StartsWith("p"));
        Debug.Log("RemoveAll========");
        tJobs.ForEach(t => { Debug.Log(t); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

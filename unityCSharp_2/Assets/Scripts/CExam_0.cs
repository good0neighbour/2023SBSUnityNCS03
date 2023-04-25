/*
    Collection

        .NET Framwork���� �����ϴ� �ڷᱸ��

    Collection.Generic

        .NET Framwork���� �����ϴ� �Ϲ�ȭ��(Ÿ�Կ� ���ؼ� ��������) �ڷᱸ��


    Array
        �迭

        ��� �迭�� �Ϲ����� �θ�Ŭ����
        CLR�� �迭�� ���ؼ� '���ӵ� �޸� ����'�� �Ҵ��Ѵ�
        �׷��Ƿ�, �ε����� �����ϴ� �ӵ��� �ſ� ������.
        ���� ĳ�����߷��� ���̹Ƿ� ������.
        �׷���, �ϴ� ������ �迭�� ũ��� �����ȴ�.

        �迭 ��ü�� ���� Ÿ���̴�.


    List<T>
        �����迭

        ���� �߿� ���Ҹ� �߰�, ���� ������ �迭�̴�.
        �� ���� ���Ҹ� �߰�, �����ϴ� ���� ȿ�������� �̷�������� �߰��� �����ϴ� ���� �ӵ��鿡�� ��ȿ�����̴�.
*/

//Array�� ����� ����ϱ� ����
using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CExam_0 : MonoBehaviour
{
    //a�� ���ԵǾ� �ִ��� ���� �˻� �Լ�
    bool IsContain_a(string tName)
    {
        return tName.Contains("a");
    }

    // Start is called before the first frame update
    void Start()
    {
        //int[] tArray = new int[3] { 1, 2, 3 };
        int[] tArray = { 3, 2, 1 };

        //���Ź�
        //foreach���Ź��� Object�� ������� ������� �ִ�.
        //�׷��� ��Ÿ���� ���� boxing�� �Ͼ�� ���̴�.
        //�׷��Ƿ� ������.
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

        //Array.Find �Լ�
        string tResult = Array.Find<string>(tNames, IsContain_a);
        Debug.Log($"find {tResult}");



        //�����迭
        List<int> tInts = new List<int>();

        //���� �߿� ���Ҹ� �߰� �����ϴ�.
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
        //������ ForEach�� List<T>�� ���� ������� �ִ�. ���ɻ� �������� ����.
        //����, ��ȸ����, ��ȸ�ϸ鼭 �ؾߵ� ���� ��������Ʈ�� �����.
        //���⼭�� ���ٸ� ����� ��������Ʈ�� �Ѱ��.
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

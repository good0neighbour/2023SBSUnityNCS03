/*
    �迭
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_0 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        //C#������ �迭�� Ÿ���̶�� ������ ���� ��Ȯ������. �׷��� ǥ����� �̷��� ���������.
        //�迭�� '����Ÿ��'�� '��ü'��.
        //���� �ֻ����� �θ�Ŭ������ object(����Ÿ���� �迭)�̴�.

        char[] tArray = new char[5];

        tArray[0] = 'a';
        tArray[1] = 'e';
        tArray[2] = 'i';
        tArray[3] = 'o';
        tArray[4] = 'u';

        for(int ti = 0; ti < tArray.Length; ++ti)
        {
            Debug.Log(tArray[ti].ToString());
        }


        Debug.Log("========");

        //step_1
        char[] tArray_0 = { 'a', 'e', 'i', 'o', 'u' };


        for (int ti = 0; ti < tArray.Length; ++ti)
        {
            string tString = $"tArray[{ti.ToString()}]: {tArray[ti].ToString()}";

            Debug.Log(tString);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

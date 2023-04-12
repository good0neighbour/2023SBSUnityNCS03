/*
    배열
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
        //C#에서는 배열이 타입이라는 개념이 좀더 명확해졌다. 그래서 표기법이 이렇게 만들어졌다.
        //배열은 '참조타입'의 '객체'다.
        //가장 최상위의 부모클래스는 object(참조타입의 계열)이다.

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

/*
    '값타입' vs '참조 타입'

    구조체 vs 클래스

    C# 언어에서는
    구조체는 값 타입으로 취급된다
    클래스는 참조 타입으로 취급된다

*/
/*
    이를테면, C++에서 다음과 같은 표현이 있다면

        가)
	    CUnit tUnit;

        나)
	    CUnit* tUnit = nullptr;
	    tUnit = new CUnit();

        가)는 값타입으로 다루는 방법이고, 나)는 참조타입으로 다루는 방법이다.
        즉, C#에서 참조타입이란 C++에서 포인터변수를 다루는 방법을 보다 쉽게 만들어 놓은 것이다.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SPoint
{
    //구조체는 멤버변수 선언 시 초기화 표현이 불가능하다.
    public int mX;// = 0;
    public int mY;// = 0;
}

public class CRyuPoint
{
    //클래스는 멤버변수 선언 시 초기화 표현이 가능하다.
    public int mX = 0;
    public int mY = 0;
}



public class CExam_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //배열은 참조타입
        SPoint[] tPointArray_0 = null;
        tPointArray_0 = new SPoint[5];
        //설정
        for(int ti = 0; ti < tPointArray_0.Length; ++ti)
        {
            tPointArray_0[ti].mX = ti;
            tPointArray_0[ti].mY = ti;
        }
        //표시
        for (int ti = 0; ti < tPointArray_0.Length; ++ti)
        {
            string tString = $"x: {tPointArray_0[ti].mX.ToString()}, y: {tPointArray_0[ti].mY.ToString()}";

            Debug.Log(tString);
        }

        Debug.Log("==============");


        CRyuPoint[] tPointArray_1 = null;
        tPointArray_1 = new CRyuPoint[5];

        //설정
        for (int ti = 0; ti < tPointArray_1.Length; ++ti)
        {
            //CRyuPoint타입으로 만들어진 원소에는 null이 세트죄어 있다.
            //그러므로 실제 객체를 만들어주어야 한다.
            tPointArray_1[ti] = new CRyuPoint();

            tPointArray_1[ti].mX = ti;
            tPointArray_1[ti].mY = ti;
        }
        //표시
        for (int ti = 0; ti < tPointArray_1.Length; ++ti)
        {
            string tString = $"x: {tPointArray_1[ti].mX.ToString()}, y: {tPointArray_1[ti].mY.ToString()}";

            Debug.Log(tString);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

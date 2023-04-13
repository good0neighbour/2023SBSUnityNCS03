/*
    스택, 힙 메모리

        지역변수, 매개변수는 스택에 적재된다

        참조타입의 인스턴스( 메모리에 실제로 만들어진 객체 )
        ( 그러므로 참조타입의 인스턴스란 '포인터 변수에 의해 가리켜진 동적할당된 객체')
        는 힙 메모리에 적재된다.
        <-- C#에서 동적할당된 메모리는 명시적으로 해지할 수 없다.
            참조가 사라진 객체(메모리누수, 댕글링 포인터)는 자동으로 수거된다.( 자동으로 메모리가 관리된다 )



    확정배정


*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//StringBuilder클래스를 사용하기 위해
using System.Text;

public class CExam_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        int tResult = 0;    //기본타입들은 값 타입으로 취급한다
        tResult = DoFactorial(3);
        Debug.Log($"DoFactorial {tResult.ToString()}");


        //step_1
        StringBuilder tRef_0 = new StringBuilder("object0");
        Debug.Log(tRef_0);

        StringBuilder tRef_1 = new StringBuilder("object1");
        StringBuilder tRef_2 = tRef_1;
        Debug.Log(tRef_2);


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    int DoFactorial(int tN)
    {
        if (0 == tN)
        {
            return 1;
        }
        else
        {
            return tN * DoFactorial(tN - 1);
        }
    }
}

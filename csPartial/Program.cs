using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    partial 클래스는 class를 정의할 때 한군데가 아닌
    여러 군데에서 class를 정의할 수 있도록 하는 문법이다.

    세 가지 정도의 경우를 예로 들 수 있다.

*/


//case 0
//같은 클래스에 속한 함수라고 하더라도
//수정 빈도에 따라 분리하고자 할 때

partial class CTestCase_0
{
    public void DoFunctionFixed()
    {
        Console.WriteLine("DoFunctionFixed");
    }
}


partial class CTestCase_0
{
    public void DoFunctionFlexed()
    {
        Console.WriteLine("DoFunctionFlexed");
    }
}



//case 1
//같은 클래스라 하더라도 N명의 개발자가 N개의 함수를 각각 제작하여야 하는 경우
partial class CTestCase_1
{
    public void DoFunctionMrKim()
    {
        Console.WriteLine("DoFunctionMrKim");
    }
}


partial class CTestCase_1
{
    public void DoFunctionMrsYang()
    {
        Console.WriteLine("DoFunctionMrsYang");
    }
}


//case 2
//---partial 함수---를 만들고 이를 선언과 정의를 분리하여 관리하려는 경우에 사용 가능하다.
//                  선언만 있고 정의가 되어 있지 않다면 해당 함수는 컴파일 시 제외
//
//      partial함수는 다음 세 가지 rule이 적용된다.
//  i) 당연히 선언과 정의는 형태가 같아야 한다.
//  ii) 함수는 반드시 void를 리턴타입으로 가진다 <---제약사항
//  iii) 예약어는 partial을 적용한다 <--접근제한수준은 private다.<--- 특이사항

partial class CTestCase_2
{
    partial void DoitDeclared();
}

partial class CTestCase_2
{
    public void DoFunctionPublic()
    {
        Console.WriteLine("DoFunctionMrsYang");

        DoitDeclared();//<---private
    }

    partial void DoitDeclared()
    {
        Console.WriteLine("DoitDeclared");
    }
}



namespace csPartial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");

            CTestCase_0 tTestCase_0 = new CTestCase_0();
            tTestCase_0.DoFunctionFixed();
            tTestCase_0.DoFunctionFlexed();

            CTestCase_1 tTestCase_1 = new CTestCase_1();
            tTestCase_1.DoFunctionMrKim();
            tTestCase_1.DoFunctionMrsYang();

            CTestCase_2 cTestCase_2 = new CTestCase_2();
            cTestCase_2.DoFunctionPublic();
            //cTestCase_2.DoitDeclared();//<---private


            Console.ReadLine();
        }
    }
}

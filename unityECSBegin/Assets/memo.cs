/*

    unity에서 DOTS기술이 적용된 도구가 바로 ETC다.

    DOTS
    Data Oriented Technology Stack
    <--- DOP의 일환으로 유니티가 여러가지 기술을 모아놓은 집합
        (ECS, Burst컴파일러, Job시스템, ... )
            -ECS: 메모리 레이아웃을 최적화하여 '성능을 끌어올린다'
            -Burst: 좀더 성능이 좋은 버스트 컴파일러(실행중 컴파일러, IL --> native)를 이용하여 '성능을 끌어올린다.'
            -Job: 멀티스레딩을 이용하여 '성능을 끌어올린다'


    structured programming
    OOP Object Oriented Programming
        <-- 클래스간 관계, 객체 간 관계를 기반으로 프로그램 구조를 작성하는 방법론

        장점: 사람에 생각에 보다 가깝게 추상화하여 다루는 방법이다.
            ( 기능을 관련있는 데이터와 묶어 다룬다 )
        단점: 기능과 관련 있는 데이터끼리 묶어 메모리에 배치되므로 컴퓨터 입장에서 보면 성능상 굉장한 단점이 된다.
            --> 메모리가 파편화될 가능성이 매우 크다.


        배열: 동일한 타입의 원소의 연속적인 메모리 블럭 ( 캐쉬적중률이 높아진다 ---> 프로그램 성능이 좋아진다 )

    General Programming

    Data Oriented Programming
        <-- 프로그램 성능을 높이기 위해, '데이터 중심'으로 프로그래밍 하는 방법이다.
            <--- '동일한 타입의 원소를 연속적으로 배치하는 것이 핵심'이다.
                ( 캐쉬적중률이 높아진다 ---> 프로그램 성능이 좋아진다 )

            <--- OOP의 단점을 극복하기 위한 방법론이다.
            <--- OOP의 방법을 버리므로 즉, unity의 기존의 시스템의 장점을 버리게 된다
                (체계가 완전히 다르다)


        <--- 데이터를 묶는(연속적으로 배치하는) 방법
            class CSlime
            {
                mX:float
                mHP:int
            }


            i) sparse type
                mX/mX/mX/mX/...
                mHP/mHP/mHP/mHP...
            
            ii) arche type
                (mX/mHP)/(mX/mHP)/(mX/mHP)/...



    unity ECS 도구

        ECS
            Entity:     ECS에서 게임오브젝트를 이야기한다 (Component의 집합이다)
                Component:  ECS에서 컴토넌트를 이야기한다 (의미 있는 최소 단위의 데이터 집합)

                            <--- arche type 방식을 쓴다.

            System:     ECS에서 기능(method)에 해당하는 것이다.



    여기서는 Hybrid ECS방법을 사용하겠다.
    ( Hybrid ECS: ECS프로그래밍 방법을 기존의 unity의 방법과 절충하여 사용하는 방법 )


    System의 개념: -----'기능( 로직 )'-----을 담는 클래스(구조체)다.

        System~클래스(구조체)를 만드는 두 가지 방식

            ISystem: 좀더 raw 한 방식

                <--- Unmanaged 방식이다.
                <--- MultiThread로 동작한다.( 공유된 데이터의 관리가 핵심이다 )

                    <--- struct로 작성해야 한다.
                        ( 보다 raw한 원시적인 형태로 다루므로 구조체(값타입)로 만든다.
                    <--- partial예약어를 적용해야 한다.
                        ( 그렇다는 것은 ecs시스템 안에서 우리가 만든 System기능의 클래스(구조체)의 일정 부분을 담당하고 있는 구조가 존재한다고 추정가능하다 )

                    <--- ISystem인터페이스를 상속받는다
                        Interface: 모양만 제공하는 클래스( 형태를 강제한다 )

            SystemBase: 좀더 편리한 방식

                <--- Managed 방식이다.
                <--- SingleThread로 동작한다.
                    ( 뇌피셜: 추정컨데, 작성하는 응용프로그램의 코드가 싱글스레드를 가정했다는 이야기로 보인다. 실제 하부에서의 동작은 job을 이용하므로 job을 이용한 코드는 멀티스레드일 것으로 추정한다. )

                    <--- class로 작성해야 한다.
                    <--- partial예약어를 적용해야 한다.
                        ( 그렇다는 것은 ecs시스템 안에서 우리가 만든 System기능의 클래스(구조체)의 일정 부분을 담당하고 있는 구조가 존재한다고 추정가능하다 )

                        Interface: 모양만 제공하는 클래스( 형태를 강제한다 )
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

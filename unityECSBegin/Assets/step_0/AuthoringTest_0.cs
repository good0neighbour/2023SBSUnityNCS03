using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//entity�� �ٷ�� ���ؼ� �ʿ��ϴ�
using Unity.Entities;

//component�� ������.( ecs������ component )
//<--- IComponentData��� �������̽��� ��ӹ޾� �����
//<--- ����ü�� �����
struct Test_0:IComponentData
{

}


//entity�� �ϳ� ����� ����ϴ� ������ �Ѵ�
public class AuthoringTest_0 : MonoBehaviour
{
    //embedded class
    class BakerTest_0: Baker<AuthoringTest_0>
    {
        public override void Bake(AuthoringTest_0 authoring)
        {
            //������Ʈ�� �߰��Ѵ�.
            AddComponent<Test_0>();
        }
    }
}

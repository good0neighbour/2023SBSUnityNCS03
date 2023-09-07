using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;

//component
struct SpawnerCube_2:IComponentData
{
    public Entity PFCube;//<--ecs ���ؿ��� �ٷ�� ���ӿ�����Ʈ(������)
}



public class AuthoringTest_2 : MonoBehaviour
{
    public UnityEngine.GameObject PFCube = null;
    //<---������ unity���ӿ�����Ʈ ���ؿ��� �ٷ�� ������ ����
    class BakerTest_2:Baker<AuthoringTest_2>
    {
        public override void Bake(AuthoringTest_2 authoring)
        {
            AddComponent<SpawnerCube_2>
                (
                    new SpawnerCube_2
                    {
                        //���� unity���ӿ�����Ʈ ���ؿ� prefab ---> entity ���ؿ� prefab
                        PFCube = GetEntity(authoring.PFCube)
                    }
                );
        }
    }
}

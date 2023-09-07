using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;

//component
struct SpawnerCube_2:IComponentData
{
    public Entity PFCube;//<--ecs 수준에서 다루는 게임오브젝트(프리팹)
}



public class AuthoringTest_2 : MonoBehaviour
{
    public UnityEngine.GameObject PFCube = null;
    //<---기존의 unity게임오브젝트 수준에서 다루는 프리팹 개념
    class BakerTest_2:Baker<AuthoringTest_2>
    {
        public override void Bake(AuthoringTest_2 authoring)
        {
            AddComponent<SpawnerCube_2>
                (
                    new SpawnerCube_2
                    {
                        //기존 unity게임오브젝트 수준에 prefab ---> entity 수준에 prefab
                        PFCube = GetEntity(authoring.PFCube)
                    }
                );
        }
    }
}

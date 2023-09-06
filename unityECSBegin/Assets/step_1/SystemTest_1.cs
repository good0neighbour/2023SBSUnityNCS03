using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;



/*
    System~클래스를 만드는 두 가지 방식

    ISystem: 좀더 raw 한 방식

    SystemBase: 좀더 편리한 방식

*/

[BurstCompile]
public class SystemTest_1 : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState tState)
    {

    }
    [BurstCompile]
    public void OnDestroy(ref SystemState tState)
    {

    }
    [BurstCompile]
    public void OnUpdate(ref SystemState tState)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;



/*
    System~Ŭ������ ����� �� ���� ���

    ISystem: ���� raw �� ���

    SystemBase: ���� ���� ���

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

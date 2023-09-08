using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;

[BurstCompile]
partial struct SystemActorMove : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState tState)
    {
        tState.RequireForUpdate<RyuActor>();
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState tState)
    {

    }
    [BurstCompile]
    public void OnUpdate(ref SystemState tState)
    {
        float tDeltaTime = SystemAPI.Time.DeltaTime;//�����Ӵ� �ð� ���ϱ�

        // �Է¿� ���� ��ġ�� ���� �ڵ�
        float tForward = Input.GetAxis("Vertical");
        float tRight = Input.GetAxis("Horizontal");

        Vector3 tVelocity = Vector3.forward * tForward + Vector3.right * tRight;
        tVelocity.Normalize();

        //�ʴ� 10����
        tVelocity = tVelocity * 10f * tDeltaTime;


        //RyuActor������Ʈ�� �����Ǿ� �ִ� ��ƼƼ�� ���ؼ�
        //LocalTransform������Ʈ�� ���� ����(��ȸ)�Ѵ�.
        foreach (var (tTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuActor>())
        {
            //�ش� ��ġ�� ����
            tTransform.ValueRW = tTransform.ValueRO.Translate<LocalTransform>(tVelocity);
        }





        //LocalTransform������Ʈ�� �ִ� ��ƼƼ�� ���� ��� ��ȸ
        //foreach (var (tTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>())
        //{
        //    //�ش� ��ġ�� ����
        //    tTransform.ValueRW = tTransform.ValueRO.Translate<LocalTransform>(tVelocity);
        //}

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;
using Unity.Collections;//<---������ Collections�� �ƴ϶� ecs�� �ִ� ���̴�.
using Unity.Transforms;
using Unity.Mathematics;



/*
    System�� ����: -----'���( ���� )'-----�� ��� Ŭ����(����ü)��.

    System~Ŭ����(����ü)�� ����� �� ���� ���

        ISystem: ���� raw �� ���

            <--- Unmanaged ����̴�.
            <--- MultiThread�� �����Ѵ�.( ������ �������� ������ �ٽ��̴� )

                <--- struct�� �ۼ��ؾ� �Ѵ�.
                    ( ���� raw�� �������� ���·� �ٷ�Ƿ� ����ü(��Ÿ��)�� �����.
                <--- partial���� �����ؾ� �Ѵ�.
                    ( �׷��ٴ� ���� ecs�ý��� �ȿ��� �츮�� ���� System����� Ŭ����(����ü)�� ���� �κ��� ����ϰ� �ִ� ������ �����Ѵٰ� ���������ϴ� )

                    Interface: ��縸 �����ϴ� Ŭ����( ���¸� �����Ѵ� )

        SystemBase: ���� ���� ���

*/
[BurstCompile]
partial struct SystemTest_2 : ISystem
{
    bool mIsBe;


    [BurstCompile]
    public void OnCreate(ref SystemState tState)
    {
        mIsBe = false;

        //SpawnerCube������Ʈ�� �ε�Ǿ��־�߸� OnUpdate�� ���������ϰ� ����
        tState.RequireForUpdate<SpawnerCube_2>();
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState tState)
    {

    }
    [BurstCompile]
    public void OnUpdate(ref SystemState tState)
    {
        if (!mIsBe)
        {


            //����ص� ������Ʈ�� ��´�.
            var tSpawnerCube = SystemAPI.GetSingleton<SpawnerCube_2>();

            //��ƼƼ ���ӿ�����Ʈ�� ����(�ù����̼�)��Ű�µ� �ʿ��� ��ɹ� ���� �������� ������� ��´�
            var tECBSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();

            //��ɹ� ���۸� �����.
            EntityCommandBuffer tECB = tECBSingleton.CreateCommandBuffer(tState.WorldUnmanaged);

            //��ƼƼ ���ӿ�����Ʈ�� �������� �����Ͽ� �ϳ� �����.
            //Entity tCube = tECB.Instantiate(tSpawnerCube.PFCube);

            //5���� entity�� ������.
            NativeArray<Entity> tCubes = CollectionHelper.CreateNativeArray<Entity>(5, Allocator.Temp);
            tECB.Instantiate(tSpawnerCube.PFCube, tCubes);
            //<---�ڷᱸ���� ���� ������ ��ƼƼ�� ä���ش�


            mIsBe = true;
        }

        //��Ƽ������ ���ۿ��� ������ �������� �������� �����ϱ� ���� �����
        //�߻�ȭ�Ǿ� ������� �ִ�.
        //RefRW: reference read write
        //RefRO: reference read only

        //������ ������ ��ġ���� ����
        float3 tPos = float3.zero;
        //entity ��ü ��Ͽ� ���� ��ȸ
        foreach(var (tTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>())
        {
            var tAngle = (0.5f + noise.cnoise(tPos / 10.0f)) * 4f * math.PI;
            math.sincos(tAngle, out tPos.x, out tPos.z);

            tTransform.ValueRW._Position = tPos * 5f;
            //ValueRW: value read write
        }



        float tDeltaTime = SystemAPI.Time.DeltaTime;//�����Ӵ� �ð� ���ϱ�
        foreach (var (tTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>())
        {
            //ȸ�� �ڵ�
            //y���� ȸ�������� ȸ��
            tTransform.ValueRW = tTransform.ValueRO.RotateY(2.0f * tDeltaTime);

            //�ش� ��ġ�� ����
            //tTransform.ValueRW = tTransform.ValueRO.Translate(tPos);
        }




        //update ����
        //tState.Enabled = false;
    }
}

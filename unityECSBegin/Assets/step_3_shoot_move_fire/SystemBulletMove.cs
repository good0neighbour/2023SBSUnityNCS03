using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;

[BurstCompile]
partial struct SystemBulletMove : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState tState)
    {
        tState.RequireForUpdate<RyuBullet>();
    }
    [BurstCompile]
    public void OnDestroy(ref SystemState tState)
    {

    }
    [BurstCompile]
    public void OnUpdate(ref SystemState tState)
    {

        //탄환의 발사 시작위치를 (주인공기체의 위치로) 설정한다.
        //foreach (var (tBulletTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuBullet>())
        foreach (var (tBulletTransform, t, tBullet) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform, RefRW<RyuBullet>>())
        {
            foreach (var (tActorTransform, tB) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuActor>())
            {
                //발사되어 이동이 아직 시작되지 않은 탄환은 발사시작지점을 설정
                if (false == tBullet.ValueRO.mIsFire)
                {
                    tBulletTransform.ValueRW = tActorTransform.ValueRO;

                    tBullet.ValueRW.mIsFire = true;
                }
            }
        }




        float tDeltaTime = SystemAPI.Time.DeltaTime;//프레임당 시간 구하기

        Vector3 tVelocity = Vector3.forward;
        //초당 10미터
        tVelocity = tVelocity * 10f * tDeltaTime;


        //RyuBullet컴포넌트가 부착되어 있는 엔티티에 대해서
        //LocalTransform컴포넌트에 대해 질의(조회)한다.
        foreach (var (tTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuBullet>())
        {
            //해당 위치로 지정
            tTransform.ValueRW = tTransform.ValueRO.Translate<LocalTransform>(tVelocity);
        }



    }
}

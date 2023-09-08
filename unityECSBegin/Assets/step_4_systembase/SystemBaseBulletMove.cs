using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

using Unity.Transforms;//TransformAspect
using Unity.Mathematics;

partial class SystemBaseBulletMove : SystemBase
{
    protected override void OnCreate()
    {
        base.OnCreate();
    }

    protected override void OnDestroy()
    {
    }

    protected override void OnUpdate()
    {
        var tDeltaTime = SystemAPI.Time.DeltaTime;


        //탄환의 발사 시작위치를 (주인공기체의 위치로) 설정한다.
        //foreach (var (tBulletTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuBullet>())
        foreach (var (tBulletTransform, t, tBullet) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform, RefRW<RyuBaseBullet>>())
        {
            foreach (var (tActorTransform, tB) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuBaseActor>())
            {
                //발사되어 이동이 아직 시작되지 않은 탄환은 발사시작지점을 설정
                if (false == tBullet.ValueRO.mIsFire)
                {
                    tBulletTransform.ValueRW = tActorTransform.ValueRO;

                    tBullet.ValueRW.mIsFire = true;
                }
            }
        }



        Vector3 tVelocity = Vector3.forward;
        //초당 10미터
        tVelocity = tVelocity * 10f * tDeltaTime;

        //ISystem버전의 코드보다 훨씬 직관적이다.
        Entities.WithAny<RyuBaseBullet>().ForEach(
            (Entity t, TransformAspect tAspect) =>
            {
                float3 tVel = (float3)tVelocity;

                tAspect.LocalPosition = tAspect.LocalPosition + tVel;
            }
            ).ScheduleParallel();//<---뇌피셜: 잡시스템을 이용하여 멀티스레드로 작동할 것으로 추정한다.
    }
}

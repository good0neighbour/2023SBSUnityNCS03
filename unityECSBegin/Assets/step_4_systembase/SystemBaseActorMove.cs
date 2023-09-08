using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

using Unity.Transforms;//TransformAspect
using Unity.Mathematics;

partial class SystemBaseActorMove : SystemBase
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

        // 입력에 의한 위치값 갱신 코드
        float tForward = Input.GetAxis("Vertical");
        float tRight = Input.GetAxis("Horizontal");

        Vector3 tVelocity = Vector3.forward * tForward + Vector3.right * tRight;
        tVelocity.Normalize();

        //초당 10미터
        tVelocity = tVelocity * 10f * tDeltaTime;

        //ISystem버전의 코드보다 훨씬 직관적이다.
        Entities.WithAny<RyuBaseActor>().ForEach(
            (Entity t, TransformAspect tAspect) =>
            {
                float3 tVel = (float3)tVelocity;

                tAspect.LocalPosition = tAspect.LocalPosition + tVel;
            }
            ).ScheduleParallel();//<---뇌피셜: 잡시스템을 이용하여 멀티스레드로 작동할 것으로 추정한다.
    }
}

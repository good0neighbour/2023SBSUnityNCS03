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

        // �Է¿� ���� ��ġ�� ���� �ڵ�
        float tForward = Input.GetAxis("Vertical");
        float tRight = Input.GetAxis("Horizontal");

        Vector3 tVelocity = Vector3.forward * tForward + Vector3.right * tRight;
        tVelocity.Normalize();

        //�ʴ� 10����
        tVelocity = tVelocity * 10f * tDeltaTime;

        //ISystem������ �ڵ庸�� �ξ� �������̴�.
        Entities.WithAny<RyuBaseActor>().ForEach(
            (Entity t, TransformAspect tAspect) =>
            {
                float3 tVel = (float3)tVelocity;

                tAspect.LocalPosition = tAspect.LocalPosition + tVel;
            }
            ).ScheduleParallel();//<---���Ǽ�: ��ý����� �̿��Ͽ� ��Ƽ������� �۵��� ������ �����Ѵ�.
    }
}

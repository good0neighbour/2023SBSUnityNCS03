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


        //źȯ�� �߻� ������ġ�� (���ΰ���ü�� ��ġ��) �����Ѵ�.
        //foreach (var (tBulletTransform, t) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuBullet>())
        foreach (var (tBulletTransform, t, tBullet) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform, RefRW<RyuBaseBullet>>())
        {
            foreach (var (tActorTransform, tB) in SystemAPI.Query<RefRW<LocalTransform>, LocalTransform>().WithAny<RyuBaseActor>())
            {
                //�߻�Ǿ� �̵��� ���� ���۵��� ���� źȯ�� �߻���������� ����
                if (false == tBullet.ValueRO.mIsFire)
                {
                    tBulletTransform.ValueRW = tActorTransform.ValueRO;

                    tBullet.ValueRW.mIsFire = true;
                }
            }
        }



        Vector3 tVelocity = Vector3.forward;
        //�ʴ� 10����
        tVelocity = tVelocity * 10f * tDeltaTime;

        //ISystem������ �ڵ庸�� �ξ� �������̴�.
        Entities.WithAny<RyuBaseBullet>().ForEach(
            (Entity t, TransformAspect tAspect) =>
            {
                float3 tVel = (float3)tVelocity;

                tAspect.LocalPosition = tAspect.LocalPosition + tVel;
            }
            ).ScheduleParallel();//<---���Ǽ�: ��ý����� �̿��Ͽ� ��Ƽ������� �۵��� ������ �����Ѵ�.
    }
}

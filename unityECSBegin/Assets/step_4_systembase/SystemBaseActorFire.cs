using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

using Unity.Transforms;//TransformAspect
using Unity.Mathematics;

partial class SystemBaseActorFire : SystemBase
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
        //źȯ ����
        bool tIsFire = Input.GetKeyDown(KeyCode.Space);
        if (tIsFire)
        {
            //ISystem�������� �ڵ尡 �������̴�.
            var tActor = SystemAPI.GetSingleton<RyuBaseActor>();
            EntityManager.Instantiate(tActor.PFBullet);
        }
    }
}

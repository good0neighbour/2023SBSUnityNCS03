using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;

[BurstCompile]
partial struct SystemActorFire : ISystem
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
        //ÅºÈ¯ »ý¼º
        bool tIsFire = Input.GetKeyDown(KeyCode.Space);
        if (tIsFire)
        {
            var tRyuActor = SystemAPI.GetSingleton<RyuActor>();
            var tECBSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
            EntityCommandBuffer tECB = tECBSingleton.CreateCommandBuffer(tState.WorldUnmanaged);

            Entity tCube = tECB.Instantiate(tRyuActor.PFBullet);
        }

    }
}

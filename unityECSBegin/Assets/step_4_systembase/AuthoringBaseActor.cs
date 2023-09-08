using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

struct RyuBaseActor : IComponentData
{
    public Entity PFBullet;
}

public class AuthoringBaseActor : MonoBehaviour
{
    public GameObject PFBullet = null;
    class BakeBaseActor : Baker<AuthoringBaseActor>
    {
        public override void Bake(AuthoringBaseActor authoring)
        {
            AddComponent<RyuBaseActor>(
                new RyuBaseActor
                {
                    PFBullet = GetEntity(authoring.PFBullet)
                }
                );
        }
    }
}

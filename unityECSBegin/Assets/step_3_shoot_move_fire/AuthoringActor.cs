using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

struct RyuActor : IComponentData
{
    public Entity PFBullet;
}

public class AuthoringActor : MonoBehaviour
{
    public GameObject PFBullet = null;
    class BakeActor : Baker<AuthoringActor>
    {
        public override void Bake(AuthoringActor authoring)
        {
            AddComponent<RyuActor>(
                new RyuActor
                {
                    PFBullet = GetEntity(authoring.PFBullet)
                }
                );
        }
    }
}

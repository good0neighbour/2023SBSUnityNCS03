using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

struct RyuBullet : IComponentData
{
    public bool mIsFire;//탄환 발사 여부
}

public class AuthoringBullet : MonoBehaviour
{
    public bool mIsFire = false;
    class BakerBullet : Baker<AuthoringBullet>
    {
        public override void Bake(AuthoringBullet authoring)
        {
            AddComponent<RyuBullet>(
                new RyuBullet
                {
                    mIsFire = authoring.mIsFire
                }
                );
        }
    }
}

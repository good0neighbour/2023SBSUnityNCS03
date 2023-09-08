using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

struct RyuBaseBullet : IComponentData
{
    public bool mIsFire;//탄환 발사 여부
}

public class AuthoringBaseBullet : MonoBehaviour
{
    public bool mIsFire = false;
    class BakerBaseBullet : Baker<AuthoringBaseBullet>
    {
        public override void Bake(AuthoringBaseBullet authoring)
        {
            AddComponent<RyuBaseBullet>(
                new RyuBaseBullet
                {
                    mIsFire = authoring.mIsFire
                }
                );
        }
    }
}

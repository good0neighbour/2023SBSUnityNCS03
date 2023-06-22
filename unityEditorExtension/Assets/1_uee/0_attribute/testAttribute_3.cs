using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAttribute_3 : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField]
    CPlayer mPlayer = null;


    //embedded class
    [Serializable]
    public class CPlayer
    {
        [Tooltip("플레이어의 이름을 나타냅니다.")]
        public string mName = "player name";
        [Tooltip("플레이어의 체력을 나타냅니다.")]
        public int mHP = 100;
    }


    [Header("Game Settings")]
    [SerializeField]
    Color mColorBackground = Color.red;


    //public인 경우 유니티의 규칙에 따라 직렬화가 적용되어 유니티 에디터 상에 노출된다
    public int mA = 1024;
    [SerializeField]
    int mB = 2048;

    //HideInInspector: 유니티 에디터에 노출시키지 않는다
    [HideInInspector]
    public int mC = 1024;
    //<-- OOP 즉 C# 문법 상으로는 어디서나 접근 가능으로
    //  유니티 에디터 상에는 노출시키고 싶지 않은 경우
    //  의 표현이다.
}

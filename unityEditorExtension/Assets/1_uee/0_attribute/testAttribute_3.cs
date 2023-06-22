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
        [Tooltip("�÷��̾��� �̸��� ��Ÿ���ϴ�.")]
        public string mName = "player name";
        [Tooltip("�÷��̾��� ü���� ��Ÿ���ϴ�.")]
        public int mHP = 100;
    }


    [Header("Game Settings")]
    [SerializeField]
    Color mColorBackground = Color.red;


    //public�� ��� ����Ƽ�� ��Ģ�� ���� ����ȭ�� ����Ǿ� ����Ƽ ������ �� ����ȴ�
    public int mA = 1024;
    [SerializeField]
    int mB = 2048;

    //HideInInspector: ����Ƽ �����Ϳ� �����Ű�� �ʴ´�
    [HideInInspector]
    public int mC = 1024;
    //<-- OOP �� C# ���� �����δ� ��𼭳� ���� ��������
    //  ����Ƽ ������ �󿡴� �����Ű�� ���� ���� ���
    //  �� ǥ���̴�.
}

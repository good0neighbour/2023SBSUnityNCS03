using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAttribute_2 : MonoBehaviour
{
    [SerializeField]
    Color mColor_0;

    //�÷� ��Ŀ( color picker )â�� alpha �����
    [ColorUsage(false)]
    [SerializeField]
    Color mColor_1;

    //�÷� ��Ŀ( color picker )â�� alpha ���̱�, HDR �޴� ���̱�
    [ColorUsage(true, true)]
    [SerializeField]
    Color mColor_2;
}

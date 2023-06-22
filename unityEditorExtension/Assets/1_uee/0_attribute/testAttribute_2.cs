using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAttribute_2 : MonoBehaviour
{
    [SerializeField]
    Color mColor_0;

    //컬러 픽커( color picker )창에 alpha 숨기기
    [ColorUsage(false)]
    [SerializeField]
    Color mColor_1;

    //컬러 픽커( color picker )창에 alpha 보이기, HDR 메뉴 보이기
    [ColorUsage(true, true)]
    [SerializeField]
    Color mColor_2;
}

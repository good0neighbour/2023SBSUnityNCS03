using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CHPGuageBar : MonoBehaviour
{
    //소스코드 상에 초기값과 유니티 에디터 상에 설정한 값 중
    //유니티 에디터 상에 설정한 값이 우선한다.
    public float mMaxHP = 500.0f;
    public float mCurHP = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().maxValue = mMaxHP;

        this.mCurHP = 70.0f;

        this.GetComponent<Slider>().value = mCurHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

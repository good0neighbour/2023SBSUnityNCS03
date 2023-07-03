using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testHandle2DGUI : MonoBehaviour
{
    float mFPS = 0f; //초당 프레임
    float mTime = 0f;//시간누적
    float mFrameTime = 0f;//프레임 시간 간격

    public string mString = string.Empty;//read only 빈 문자열

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //'초당 프레임'과 '프레임 시간'

        mFPS++;

        //timeScale 게임 세계의 시간의 흐름을 조절할 수 있는 변수

        //mTime += Time.deltaTime;    //시간 누적 <--프레임 시간 간격 <-- timeScale에 영향을 받음
        mTime += Time.unscaledDeltaTime;    //시간 누적 <--프레임 시간 간격 <-- timeScale에 영향을 받지 않는다

        if (mTime > 1f)
        {
            mFrameTime = mTime / mFPS;    //보정한 프레임 시간을 구함
            mTime -= 1f;    //시간 누적 초기화

            mString = $"FPS:{mFPS.ToString()}, Frame Time: {mFrameTime.ToString()}";

            mFPS = 0f;//FPS초기화
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCam_1 : MonoBehaviour
{
    [SerializeField]
    GameObject mPChar = null;

    //오프셋, 캐릭터로부터 오프셋( 얼마나 떨어져 있는지에 대한 변위 )
    [SerializeField]
    Vector3 mOffset = Vector3.zero;

    float mXVal = 0f;   //마우스 X입력값
    float mYVal = 0f;   //마우스 Y입력값

    //캐릭터로부터 카메라가 떨어진 거리, 길이
    [SerializeField]
    float mArmLength = 0.0f;

    bool mIsCameraRotation = false;


    // Start is called before the first frame update
    void Start()
    {
        //유니티 에디터에서 설정한 값을 계산하여 기억해둔다.
        //  임의의 벡터 = 목적지점 - 시작지점
        //mOffset = this.transform.position - mPChar.transform.position;
        //mYVal = this.transform.rotation.eulerAngles.x;  //오일러각 x축 회전축 degree

        //카메라 암 길이 설정
        mOffset = new Vector3(0f, 0f, -1f * mArmLength);
        mYVal = 30f;    //x축 회전축으로 하는 각도 설정( degree )
        mYVal = this.transform.rotation.eulerAngles.x;  //오일러각 x축 회전축 degree

        //설정된 회전값을 한번 적용
        this.transform.rotation = Quaternion.Euler(mYVal, mXVal, 0f);

        mIsCameraRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mIsCameraRotation = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            mIsCameraRotation = false;
        }

        //마우스 오른쪽 버튼이 눌려있는 경우에만, 카메라의 회전 동작을 하도록 한다
        if (mIsCameraRotation)
        {
            float tMouseX = Input.GetAxis("Mouse X");   //[-1, 1]
            float tMouseY = Input.GetAxis("Mouse Y");   //[[-1, 1]

            mXVal = mXVal + tMouseX;
            mYVal = mYVal + tMouseY * (-1.0f);
            //윈도우 좌표계 기준으로는 y축 양의 방향이 아래쪽인데
            //유니티의 좌표계는 y축 양의 방향이 위쪽이므로
            //-1을 곱해주어 맞췄다.

            //Quaternion 사원수 <-- 네 개의 항을 결합하여 만든 수체계
            //Quaternion vs Euler
            this.transform.rotation = Quaternion.Euler(mYVal, mXVal, 0f);
            //<-- 마우스 입력에 기반하여 카메라의 x축 회전( mouse y 입력값에 대응 ), y축 회전( mouse x 입력값에 대응 )을 하려고 하는 것이다
        }
    }

    private void LateUpdate()
    {
        //카메라의 위치를 캐릭터로부터 오프셋만큼 떨어진 위치로 지정
        //this.transform.position = mPChar.transform.position + mOffset;

        //카메라의 화전까지 적용된 오프셋으로 계산하여 카메라의 위치를 지정
        //<-- 결과적으로는 캐릭터를 중심에 두고 카메라가 회전한다
        this.transform.position = mPChar.transform.position + this.transform.rotation * mOffset;
        //this.transform.rotation * mOffset: 사원수 * 벡터의 곱셈연산
        //사원수는 벡터의 회전을 위한 연산으로 사용 가능하다.
        //  즉 여기서는 mOffset이라는 벡터를
        //  사원수 공간(대수적인 의미)으로 가져가서
        //  해당 방향에 맞게 회전(크기는 그대로, 방향을 변경)시키고
        //  다시 사원수 공간에서 벡터 공간(대수적인 의미)으로 끄집어내어
        //  3D공간(기하적인 의미)의 벡터로 돌려주는 것이다
    }
}

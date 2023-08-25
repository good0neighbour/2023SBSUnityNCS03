using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CSlimeCSharp : MonoBehaviour
{
    //이것을 사용하기 위해서는 InputActionCSharp 인풋액션즈 애셋을 스크립트로 만들어주어야 한다.
    InputActionCSharp mInputActions = null;

    // Start is called before the first frame update
    void Start()
    {
        mInputActions = new InputActionCSharp();//<--해당 인풋액션즈 객체를 생성
        mInputActions.ActionmapsAxis.DoMove_ForwardAxis.Enable();
        //<--해당 액션을 활성화
        mInputActions.ActionmapsAxis.DoRotate.Enable();
        //<--해당 액션을 활성화
    }

    // Update is called once per frame
    void Update()
    {
        //지속적인 입력체크를 위해 Update에 작성
        float tScalar = mInputActions.ActionmapsAxis.DoMove_ForwardAxis.ReadValue<float>();

        mVelocity = this.transform.forward;
        mVelocity = mVelocity * tScalar * 10f * Time.deltaTime;//1유닛씩 이동
                                             //해당 속도로 이동
        this.transform.Translate(mVelocity, Space.World);

        //입력에 따른 좌우 선회
        float tScalarRotate = mInputActions.ActionmapsAxis.DoRotate.ReadValue<float>();
        this.transform.Rotate(Vector3.up, tScalarRotate);
    }

    Vector3 mVelocity = Vector3.zero;

    public void DoMove(InputAction.CallbackContext tContext)
    {
        //Performed:입력수행 완료의 의미다
        //if (tContext.phase == InputActionPhase.Performed)
        //{
            Debug.Log("DoMove");
            //축입력이므로 임의의 스칼라 타입의 데이터를 얻는다. 이것은 액션에서 ControlType으로 설정한 것이다.
            float tScalar = tContext.ReadValue<float>();

            Debug.Log($"CSlimeBasic.DoMove: {tScalar.ToString()}");
            //입력에 의한 속도 산출

            mVelocity = Vector3.forward;
            mVelocity = mVelocity * tScalar * 1f;//1유닛씩 이동
            //해당 속도로 이동
            this.transform.Translate(mVelocity, Space.World);
        //}

    }
}

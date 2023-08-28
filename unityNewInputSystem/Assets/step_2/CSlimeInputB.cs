using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSlimeInputB : MonoBehaviour
{
    InputActions_ActionMaps mInputActions = null;

    Vector3 mVelocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        mInputActions = new InputActions_ActionMaps();//<--해당 인풋액션즈 객체를 생성
        mInputActions.ActionMapsSlimeB.DoMoveForwardAxis.Enable();
        //<--해당 액션을 활성화
        mInputActions.ActionMapsSlimeB.DoMoveRotate.Enable();
        //<--해당 액션을 활성화
    }

    // Update is called once per frame
    void Update()
    {
        //지속적인 입력체크를 위해 Update에 작성
        float tScalar = mInputActions.ActionMapsSlimeB.DoMoveForwardAxis.ReadValue<float>();

        mVelocity = this.transform.forward;
        mVelocity = mVelocity * tScalar * 10f * Time.deltaTime;//1유닛씩 이동
                                                               //해당 속도로 이동
        this.transform.Translate(mVelocity, Space.World);

        //입력에 따른 좌우 선회
        float tScalarRotate = mInputActions.ActionMapsSlimeB.DoMoveRotate.ReadValue<float>();
        this.transform.Rotate(Vector3.up, tScalarRotate * 100f * Time.deltaTime);
    }

    void OnDoFire()
    {
        Debug.Log("CSlimeInputA.OnDoFire");
    }
}

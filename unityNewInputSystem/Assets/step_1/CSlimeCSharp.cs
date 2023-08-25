using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CSlimeCSharp : MonoBehaviour
{
    //�̰��� ����ϱ� ���ؼ��� InputActionCSharp ��ǲ�׼��� �ּ��� ��ũ��Ʈ�� ������־�� �Ѵ�.
    InputActionCSharp mInputActions = null;

    // Start is called before the first frame update
    void Start()
    {
        mInputActions = new InputActionCSharp();//<--�ش� ��ǲ�׼��� ��ü�� ����
        mInputActions.ActionmapsAxis.DoMove_ForwardAxis.Enable();
        //<--�ش� �׼��� Ȱ��ȭ
        mInputActions.ActionmapsAxis.DoRotate.Enable();
        //<--�ش� �׼��� Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        //�������� �Է�üũ�� ���� Update�� �ۼ�
        float tScalar = mInputActions.ActionmapsAxis.DoMove_ForwardAxis.ReadValue<float>();

        mVelocity = this.transform.forward;
        mVelocity = mVelocity * tScalar * 10f * Time.deltaTime;//1���־� �̵�
                                             //�ش� �ӵ��� �̵�
        this.transform.Translate(mVelocity, Space.World);

        //�Է¿� ���� �¿� ��ȸ
        float tScalarRotate = mInputActions.ActionmapsAxis.DoRotate.ReadValue<float>();
        this.transform.Rotate(Vector3.up, tScalarRotate);
    }

    Vector3 mVelocity = Vector3.zero;

    public void DoMove(InputAction.CallbackContext tContext)
    {
        //Performed:�Է¼��� �Ϸ��� �ǹ̴�
        //if (tContext.phase == InputActionPhase.Performed)
        //{
            Debug.Log("DoMove");
            //���Է��̹Ƿ� ������ ��Į�� Ÿ���� �����͸� ��´�. �̰��� �׼ǿ��� ControlType���� ������ ���̴�.
            float tScalar = tContext.ReadValue<float>();

            Debug.Log($"CSlimeBasic.DoMove: {tScalar.ToString()}");
            //�Է¿� ���� �ӵ� ����

            mVelocity = Vector3.forward;
            mVelocity = mVelocity * tScalar * 1f;//1���־� �̵�
            //�ش� �ӵ��� �̵�
            this.transform.Translate(mVelocity, Space.World);
        //}

    }
}

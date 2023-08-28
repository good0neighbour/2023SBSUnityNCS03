using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSlimeInputA : MonoBehaviour
{
    InputActions_ActionMaps mInputActions = null;

    Vector3 mVelocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        mInputActions = new InputActions_ActionMaps();//<--�ش� ��ǲ�׼��� ��ü�� ����
        mInputActions.ActionMapsSlimeA.DoMoveForwardAxis.Enable();
        //<--�ش� �׼��� Ȱ��ȭ
        mInputActions.ActionMapsSlimeA.DoMoveRotate.Enable();
        //<--�ش� �׼��� Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        //�������� �Է�üũ�� ���� Update�� �ۼ�
        float tScalar = mInputActions.ActionMapsSlimeA.DoMoveForwardAxis.ReadValue<float>();

        mVelocity = this.transform.forward;
        mVelocity = mVelocity * tScalar * 10f * Time.deltaTime;//1���־� �̵�
                                                               //�ش� �ӵ��� �̵�
        this.transform.Translate(mVelocity, Space.World);

        //�Է¿� ���� �¿� ��ȸ
        float tScalarRotate = mInputActions.ActionMapsSlimeA.DoMoveRotate.ReadValue<float>();
        this.transform.Rotate(Vector3.up, tScalarRotate * 100f * Time.deltaTime);
    }

    void OnDoFire()
    {
        Debug.Log("CSlimeInputA.OnDoFire");
    }
}

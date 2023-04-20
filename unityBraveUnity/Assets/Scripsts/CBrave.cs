using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBrave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DoMoveForward()
    {
        Debug.Log("CBrave.DoMoveForward");

        //Vector3.forward (0.0f, 0.0f, 1.0f)
        float tSpeedScalar = 1.0f;
        Vector3 tVelocity = Vector3.forward * tSpeedScalar;

        //�ӵ��� �� ĭ��, ��ǥ������ ���� ��ǥ��, �ҿ������� �̵�
        this.transform.Translate(tVelocity, Space.World);


        //��� ó��
        if (this.transform.position.z > 4.0f)
        {
            //���ɻ��� ������ �ٰŷ� �̷� ǥ���� �����ִ�.( �̷��� ǥ���� �����Ϸ��� C++�� ���۵� ���̺귯�� �������� ���������ϴµ� �װ��� ���� �ٸ� ���� ������� �κ��� ����� �Ͼ�� �ȴ�. �װ��� ���ɻ� �������� �ʷ��Ѵ� )
            //  �׷��Ƿ� �̰��� �ȵ�
            //this.transform.position.x = 4.0f;

            //�캯�� ǥ���� Vector3�� struct�Ƿ� ��Ÿ���� ����(position)�� ������� ����Ǿ� ���ԵǴ� ���̴�.
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 4.0f - 0.2f);
        }
    }
    public void DoMoveBackward()
    {
        Debug.Log("CBrave.DoMoveBackward");

        //Vector3.forward (0.0f, 0.0f, 1.0f)
        float tSpeedScalar = 1.0f;
        Vector3 tVelocity = (-1.0f) * Vector3.forward * tSpeedScalar;
        //�ӵ��� �� ĭ��, ��ǥ������ ���� ��ǥ��, �ҿ������� �̵�
        this.transform.Translate(tVelocity, Space.World);

        if (this.transform.position.z < 0.0f)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f - 0.2f);
        }
    }
}

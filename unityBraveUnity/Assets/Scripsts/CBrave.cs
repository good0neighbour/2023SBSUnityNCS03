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

        //속도는 한 칸씩, 좌표기준은 월드 좌표계, 불연속적인 이동
        this.transform.Translate(tVelocity, Space.World);


        //경계 처리
        if (this.transform.position.z > 4.0f)
        {
            //성능상의 이유를 근거로 이런 표현은 막혀있다.( 이러한 표현이 가능하려면 C++로 제작된 라이브러리 수준으로 내려가야하는데 그것은 서로 다른 언어로 만들어진 부분의 통신이 일어나게 된다. 그것은 성능상 불이익을 초래한다 )
            //  그러므로 이것은 안됨
            //this.transform.position.x = 4.0f;

            //우변의 표현은 Vector3가 struct므로 값타입의 벡터(position)가 만들어져 복사되어 대입되는 것이다.
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 4.0f - 0.2f);
        }
    }
    public void DoMoveBackward()
    {
        Debug.Log("CBrave.DoMoveBackward");

        //Vector3.forward (0.0f, 0.0f, 1.0f)
        float tSpeedScalar = 1.0f;
        Vector3 tVelocity = (-1.0f) * Vector3.forward * tSpeedScalar;
        //속도는 한 칸씩, 좌표기준은 월드 좌표계, 불연속적인 이동
        this.transform.Translate(tVelocity, Space.World);

        if (this.transform.position.z < 0.0f)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f - 0.2f);
        }
    }
}

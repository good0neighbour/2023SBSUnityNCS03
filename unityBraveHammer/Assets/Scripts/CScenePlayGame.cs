using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScenePlayGame : MonoBehaviour
{
    //������ ��ġ �ø��� ���� ����
    public int mScore = 0;

    //�÷��� ���� UI
    public CUIPlayGame mpUIPlayGame = null;


    public CGrid mpGrid = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input ����Ƽ���� �����ϴ� �Է� ���� Ŭ����
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("left mouse btn");

            //'������Ray'�� ������ ��ü�� '�浹'
            //<--�浹(�����ۿ�)�� �Ͼ�� �ϹǷ� �����ӿ� �浹ü(collider)������Ʈ�� �߰��Ѵ�

            //���콺�� Ŭ���� �������κ��� 3D������ �������� ������ �������� �����
            Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool tIsCollision = false;
            RaycastHit tHit;    //�������� ��ü�� �浹���� ����
            //Physics ���� ���� Ŭ����
            tIsCollision = Physics.Raycast(tRay, out tHit, Mathf.Infinity);
            
            if(tIsCollision)
            {
                //�浹�̴�
                Debug.Log("<color='green'>ray is collision</color>");

                //�±�tag(���ӳ����� ���Ǵ� ������ �ĺ��� ����ǥ) �˻�
                if (tHit.collider.CompareTag("tagEnemy"))
                {
                    //������ ��ġ
                    Debug.Log("<color='red'>Slime Touched</color>");

                    //���� ����
                    mScore += 10;

                    Debug.Log($"<color='blue'>{mScore.ToString()}</color>");

                    //UI����
                    mpUIPlayGame.UpdateScore(mScore);

                    //�������� ������ �ִϸ��̼� ����
                    mpGrid.mpCurrentSlime.DoAniDamage();
                }
            }


        }
        
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Debug.Log("right mouse btn");
        //}

        //if (Input.GetMouseButtonDown(2))
        //{
        //    Debug.Log("mouse wheel btn");
        //}
    }
}

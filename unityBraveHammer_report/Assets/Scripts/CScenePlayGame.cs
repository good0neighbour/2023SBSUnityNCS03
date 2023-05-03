using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

            RaycastHit tHit;    //�������� ��ü�� �浹���� ����
            //Physics ���� ���� Ŭ����
            bool tIsCollision = Physics.Raycast(tRay, out tHit, Mathf.Infinity);
            
            if(tIsCollision)
            {
                //�浹�̴�
                Debug.Log("<color='green'>ray is collision</color>");

                //�±�tag(���ӳ����� ���Ǵ� ������ �ĺ��� ����ǥ) �˻�
                if (tHit.collider.CompareTag("tagEnemy"))
                {
                    OnEnemyClick(tHit, 10);
                }
                else if (tHit.collider.CompareTag("tagEnemyDouble"))
                {
                    OnEnemyClick(tHit, 20);
                }
                else if (tHit.collider.CompareTag("tagEnemyRed"))
                {
                    mpGrid._SpawnTime *= 0.9f;
                    OnEnemyClick(tHit, 10);
                }
                else
                {
                    Debug.Log("�꽺��");

                    //���� ����
                    mScore -= 5;

                    //UI����
                    mpUIPlayGame.UpdateScore(mScore);
                }
            }
        }
    }

    //�� Ŭ�� �� ������ �߻�ȭ
    private void OnEnemyClick(RaycastHit tHit, int tScoreGain)
    {
        //������ ��ġ
        Debug.Log("<color='red'>Slime Touched</color>");

        //���� ����
        mScore += tScoreGain;

        Debug.Log($"<color='blue'>{mScore.ToString()}</color>");

        //UI����
        mpUIPlayGame.UpdateScore(mScore);

        //�������� ������ �ִϸ��̼� ����
        //mpGrid.mpCurrentSlime.DoAniDamage();

        //tHit.collider.gameObject.GetComponent<CSlime>().DoAniDamage();
        tHit.collider.gameObject.GetComponent<CEnemy>().DoAniDamage();
    }
}

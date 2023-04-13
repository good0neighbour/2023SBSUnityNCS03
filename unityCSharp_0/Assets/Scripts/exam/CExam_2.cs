/*
    ������ �迭

    C#�� ������ �迭���� ���� �� ������ �ִ�.
        retangular array
        jagged array

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //rectangular array step_0
        //���簢�� ����� �迭
        int[,] tArray_0 = new int[4, 3];

        for (int tRow = 0; tRow < tArray_0.GetLength(0); ++tRow)
        {
            for (int tCol = 0; tCol < tArray_0.GetLength(1); ++tCol)
            {
                tArray_0[tRow, tCol] = tRow * 3 + tCol;
            }
        }

        //string���� ������, ���� ���� �ڵ�� �ƴϴ�.
        string tString = string.Empty;
        for (int tRow = 0; tRow < tArray_0.GetLength(0); ++tRow)
        {
            for (int tCol = 0; tCol < tArray_0.GetLength(1); ++tCol)
            {
                tString = tString + $"{tArray_0[tRow, tCol].ToString()}    ";
            }

            tString = tString + "\n";
        }

        Debug.Log(tString);


        Debug.Log("=====");

        //rectangular array step_1
        //�̷��� ����� �ʱ�ȭ�� ���ÿ� �� ���� �ִ�.
        int[,] tArray_1 = new int[,]
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 }
        };

        //string���� ������, ���� ���� �ڵ�� �ƴϴ�.
        tString = string.Empty;
        for (int tRow = 0; tRow < tArray_1.GetLength(0); ++tRow)
        {
            for (int tCol = 0; tCol < tArray_1.GetLength(1); ++tCol)
            {
                tString = tString + $"{tArray_1[tRow, tCol].ToString()}    ";
            }

            tString = tString + "\n";
        }

        Debug.Log(tString);




        //jaged array step_0
        int[][] tArray_2 = new int[4][];

        //tArray_2.Length�� �� ���ؿ����� ����
        for (int tRow = 0; tRow < tArray_2.Length; ++tRow)
        {
            //�ึ�� ���� ������ ��� �ٸ��� �� ���� �ִ�. ���⼭�� ��ġ���״�.
            tArray_2[tRow] = new int[3];

            //tArray_2[tRow].Length�� ������ ���� �� ���ؿ����� ����
            for (int tCol = 0; tCol < tArray_2[tRow].Length; ++tCol)
            {
                tArray_2[tRow][tCol] = tRow * 3 + tCol;
            }
        }

        Debug.Log("////////////////");

        //string���� ������, ���� ���� �ڵ�� �ƴϴ�.
        tString = string.Empty;
        for (int tRow = 0; tRow < tArray_2.Length; ++tRow)
        {
            for (int tCol = 0; tCol < tArray_2[tRow].Length; ++tCol)
            {
                tString = tString + $"{tArray_2[tRow][tCol].ToString()}    ";
            }

            tString = tString + "\n";
        }
        Debug.Log(tString);

        //jaged array step_1
        //����� �ʱ�ȭ�� ���ÿ�
        int[][] tArray_3 = new int[][]
        {
            new int[] { 0, 1, 2 },
            new int[] { 3, 4 },
            new int[] { 5, 6, 7, 8 }
        };

        Debug.Log(">>>>>>>>>");
        //string���� ������, ���� ���� �ڵ�� �ƴϴ�.
        tString = string.Empty;
        for (int tRow = 0; tRow < tArray_3.Length; ++tRow)
        {
            for (int tCol = 0; tCol < tArray_3[tRow].Length; ++tCol)
            {
                tString = tString + $"{tArray_3[tRow][tCol].ToString()}    ";
            }

            tString = tString + "\n";
        }
        Debug.Log(tString);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CGameUnitInfoŸ���� ������(����)�� ������ PropertyAttribute�� ����� �����Ѵ�.

public class CGameUnitInfoAttribute : PropertyAttribute
{
    public string mName { get; set; }
    public string mLevel { get; set; }
    public string mTypeJob { get; set; }
}

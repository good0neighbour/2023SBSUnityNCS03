using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public enum TYPE_JOB
{
    JOB_KNIGHT,
    JOB_ARCHOR,
    JOB_MAGIC,
    JOB_PALADIN
}
//데이터 클래스
[Serializable]
public class CGameUnitInfo
{
    public string mName = "ironman";
    public int mLevel = 1;
    public TYPE_JOB mTypeJob = TYPE_JOB.JOB_KNIGHT;
}

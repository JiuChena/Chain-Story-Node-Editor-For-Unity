using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 排行榜单条数据
/// </summary>
public class RankInfo
{
    public string name;
    public float score;
    public float time;

    public RankInfo() { }
    public RankInfo(string name, float score, float time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }
}
public class RankList
{
    public List<RankInfo> rankList;
}

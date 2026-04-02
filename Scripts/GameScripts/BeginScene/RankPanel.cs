using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : PanelBase<RankPanel>
{
    public CustomGUIButton btnClose;
    public List<GameObject> list;


    private void Start()
    {
        btnClose.clickEvent += () =>
        {
            HidePanel();
            BeginPanel.Instance.ShowPanel();
        };

        //PlayerPrefs.DeleteAll();
        //GameDataManger.Instance.AddRankInfo("九尘上玄", 100, 5376);
        HidePanel();
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        UpdataInfo();
    }
    public void UpdataInfo()
    {
        //处理排行榜数据
        List<RankInfo> rankList = GameDataManger.Instance.rankData.rankList;

        for (int i = 0; i < rankList.Count; i++) 
        {
            list[i].transform.Find("Label (2)").GetComponent<CustomGUILabel>().content.text = rankList[i].name;
            list[i].transform.Find("Label (3)").GetComponent<CustomGUILabel>().content.text = rankList[i].score.ToString("F1");
            #region 对time进行时分秒转换
            int time = (int)rankList[i].time;
            string result = "";
            if (time / 3600 > 0)
            {
                result += time / 3600 + "h ";
                time %= 3600;
            }
            if (time / 60 > 0)
            {
                result += time / 60 + "min ";
                time %= 60;
            }
            if (time != 0)
            {
                result += time + "s";
            }
            #endregion
            list[i].transform.Find("Label (4)").GetComponent<CustomGUILabel>().content.text = result;
        }
    }

}

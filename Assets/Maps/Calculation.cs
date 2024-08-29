using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculation : MonoBehaviour
{
    private Location[] via = new Location[20];//各経由地
    public int[] disData = new int[20];
    public int[] dirData = new int[20];
    public int time = 0;
    public bool switchFlag = false;
    Location shibuya = new Location(35.658126d, 139.701616d);
    Location hakata = new Location(33.590322d, 130.420675d);
    public DirectionController directionController;
    public BrailleBlockPlacer brailleBlockPlacer;

    void Start()
    {
        // Debug.Log("例" + NaviMath.LatlngDistance(shibuya, hakata) + "km");
        // Debug.Log("例" + NaviMath.LatlngDirection(shibuya, hakata) + "度");

        // DirectionController directionController = GetComponent<DirectionController>();
    }
    void Update()
    {
        Location here = new Location(Input.location.lastData.latitude, Input.location.lastData.longitude);//現在地の位置情報
        // if (directionController.waylat[0] != "" && directionController.waylng[0] == "")
        // {
        for (int i = 0; i < 19; i++)
        {
            int j = i + 1;
            int k = i + 2;
            if (directionController.waylat[j] == "" && directionController.waylng[j] == "") break;
            double lat = double.Parse(directionController.waylat[i]);
            double lng = double.Parse(directionController.waylng[i]);
            via[i] = new Location(lat, lng);
            if (NaviMath.LatlngDistance(via[i], via[j]) < 10000 && switchFlag == false)
            {
                if (time >= 0)
                {
                    disData[0] = (int)(NaviMath.LatlngDistance(here, via[0]) * 1000);
                    dirData[0] = (int)NaviMath.LatlngDirection(here, via[0]);
                    disData[j] = (int)(NaviMath.LatlngDistance(via[i], via[j]) * 1000);
                    dirData[j] = (int)NaviMath.LatlngDirection(via[i], via[j]);
                    // Debug.Log("0~1番目" + NaviMath.LatlngDistance(here, via[0]) + "km");
                    // Debug.Log("0~1番目" + NaviMath.LatlngDirection(here, via[0]) + "度");
                    // Debug.Log(j + "~" + k + "番目" + NaviMath.LatlngDistance(via[i], via[j]) + "km");
                    // Debug.Log(j + "~" + k + "番目" + NaviMath.LatlngDirection(via[i], via[j]) + "度");
                    Debug.Log("0~1番目" + disData[0] + "m");
                    Debug.Log("0~1番目" + dirData[0] + "度");
                    Debug.Log(j + "~" + k + "番目" + disData[j] + "m");
                    Debug.Log(j + "~" + k + "番目" + dirData[j] + "度");
                }
                time++;
                if (time > 30)
                {
                    switchFlag = true;
                    brailleBlockPlacer.startFlag = true;
                }
            }
            if (i > 20) break;// 経路が多すぎるとUriFormatExceptionで落ちるため上限を設定しておく。
        }
        // }
        // else { Debug.Log("停止"); }
    }
}
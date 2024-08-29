using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculation : MonoBehaviour
{
    private Location[] via = new Location[20];//各経由地；
    Location shibuya = new Location(35.658126d, 139.701616d);
    Location hakata = new Location(33.590322d, 130.420675d);
    public DirectionController directionController;

    void Start()
    {
        Debug.Log("例" + NaviMath.LatlngDistance(shibuya, hakata) + "km");
        Debug.Log("例" + NaviMath.LatlngDirection(shibuya, hakata) + "度");

        // DirectionController directionController = GetComponent<DirectionController>();
    }
    void Update()
    {
        Location here = new Location(Input.location.lastData.latitude, Input.location.lastData.longitude);
        for (int i = 0; i < 19; i++)
        {
            Debug.Log("0~1番目" + NaviMath.LatlngDistance(here, via[0]) + "km");
            Debug.Log("0~1番目" + NaviMath.LatlngDirection(here, via[0]) + "度");
            int j = i + 1;
            int k = i + 2;
            if (directionController.waylat[j] == "" && directionController.waylng[j] == "") break;
            double lat = double.Parse(directionController.waylat[i]);
            double lng = double.Parse(directionController.waylng[i]);
            via[i] = new Location(lat, lng);
            Debug.Log(j + "~" + k + "番目" + NaviMath.LatlngDistance(via[i], via[j]) + "km");
            Debug.Log(j + "~" + k + "番目" + NaviMath.LatlngDirection(via[i], via[j]) + "度");
            if (i > 20) break;// 経路が多すぎるとUriFormatExceptionで落ちるため上限を設定しておく。
        }
    }
}
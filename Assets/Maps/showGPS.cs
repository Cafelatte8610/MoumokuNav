using System;
using UnityEngine;
using UnityEngine.UI;
 
public class ShowGPS : MonoBehaviour
{
    public GameObject LatitudeText = null;// 緯度を表示するための文字
    public GameObject LongitudeText = null;// 経度を表示するための文字
 
    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();// GPS機能の利用開始
    }
 
    // Update is called once per frame
    void Update()
    {
        Text latitude_component = LatitudeText.GetComponent<Text>();// 紐づけたLatitudeTextのオブジェクトを変数に格納
        Text longitude_component = LongitudeText.GetComponent<Text>();// 紐づけたLongitudeTextのオブジェクトを変数に格納
        latitude_component.text = Convert.ToString(Input.location.lastData.latitude);// Textオブジェクトのtext部分を取得したGPS情報の緯度で上書き
        longitude_component.text = Convert.ToString(Input.location.lastData.longitude);// Textオブジェクトのtext部分を取得したGPS情報の経度で上書き
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class DirectionController : MonoBehaviour
{
    private const string GOOGLE_DIRECTIONS_API_URL = "https://maps.googleapis.com/maps/api/directions/json?key=AIzaSyA9JnXILYeQeQqQc6KAragGK59qz1xEvY8&mode=walking";
    public InputField destination;// 目的地を入力させるInputField
    public string destinationRoute = "";// APIより取得した経路（staticMapControllerに渡すためのパラメータ）
    private int frame = 0;
    public string[] waylat = new string[20];//途中経路の緯度；
    public string[] waylng = new string[20];//途中経路の経度；

    void Start()
    {

    }

    void Update()
    {
        if (frame >= 300 && destination.text != "")// 更新は5秒に一度、目的地が設定されていない場合は取得しない。
        {
            Debug.Log(UnityWebRequest.UnEscapeURL(destination.text));
            StartCoroutine(GetDirection());
            frame = 0;
        }
        frame++;
    }

    private IEnumerator GetDirection()
    {
        var query = "&origin=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", Input.location.lastData.latitude, Input.location.lastData.longitude));// origin=開始地点。現在地からの経路を出したいので現在地を渡す。

        query += "&destination=" + UnityWebRequest.UnEscapeURL(destination.text);// destination=目的地。InputFieldに入力した文字列をエスケープして渡す。
        UnityWebRequest req = UnityWebRequest.Get(GOOGLE_DIRECTIONS_API_URL + query);
        yield return req.SendWebRequest();

        if (req.error == null)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(req.downloadHandler.text));// 返ってきたjsonをByte[]形式を処理できるMemoryStreamで受け取る

            var serializer = new DataContractJsonSerializer(typeof(GoogleDirectionData));// google DirectionのJSONをオブジェクトとして読み込めるようにシリアライザを作成

            GoogleDirectionData googleDirectionData = (GoogleDirectionData)serializer.ReadObject(ms);// 作成したJSON用のクラスにデシリアライズ

            var leg = googleDirectionData.routes[0].legs[0];// データの形式としてroutes[0].legs[0]は固定なので一旦変数に格納

            destinationRoute = "";// 書き込み前に初期化
            for (int i = 0; i < leg.steps.Count; i++)
            {
                int j = i + 1;
                waylat[i] = "";
                waylng[i] = "";

                destinationRoute += "|" + leg.steps[i].end_location.lat + "," + leg.steps[i].end_location.lng;// 経路は|緯度,経度|という書き方になるので、受け取ったlatitude, longitudeをパイプとカンマを付けて追加していく
                waylat[i] += leg.steps[i].end_location.lat;
                waylng[i] += leg.steps[i].end_location.lng;
                Debug.Log("0番目" + Input.location.lastData.latitude + "," + Input.location.lastData.longitude);
                Debug.Log(j + "番目" + waylat[i] + "," + waylng[i]);
                if (i > 20) break;// 経路が多すぎるとUriFormatExceptionで落ちるため上限を設定しておく。
            }
            // Debug.Log(destinationRoute);
        }
    }
}
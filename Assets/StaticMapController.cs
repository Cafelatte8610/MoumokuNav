using System.Collections;
using UnityEngine;
using UnityEngine.Networking;// Unity内でネットワークを使用するときに記入する
 
public class StaticMapController : MonoBehaviour
{
    private const string STATIC_MAP_URL = "https://maps.googleapis.com/maps/api/staticmap?key=AIzaSyA9JnXILYeQeQqQc6KAragGK59qz1xEvY8&zoom=15&size=640x640&scale=2&maptype=terrain&style=element:labels|visibility:off";// Google Maps Static API URL、${APIKey}を作成したapiキーに書き換える
    private int frame = 0;// マップの更新をする間隔の変数
 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getStaticMap());// getStaticMapを実行する
    }
 
    // Update is called once per frame
    void Update()
    {
        frame++;// frameを1ずつ変える

        if (frame >= 300)// もし、frameが300以上なら、
        {
            StartCoroutine(getStaticMap());// getStaticMapを実行する
            frame = 0;// frameを0にする
        }
    }
 
    IEnumerator getStaticMap()
    {
        var query = "";// queryを初期化する
        query += "&center=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", Input.location.lastData.latitude, Input.location.lastData.longitude));// centerで取得するミニマップの中央座標を設定
        query += "&markers=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", Input.location.lastData.latitude, Input.location.lastData.longitude));// markersで渡した座標(=現在位置)にマーカーを立てる
        var req = UnityWebRequestTexture.GetTexture(STATIC_MAP_URL + query);// リクエストの定義
        yield return req.SendWebRequest();// リクエスト実行
 
        if (req.error == null)// もし、リクエストがエラーでなければ、
        {
            Destroy(GetComponent<Renderer>().material.mainTexture); //マップをなくす
            GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)req.downloadHandler).texture; //マップを貼りつける
        }
    }
}
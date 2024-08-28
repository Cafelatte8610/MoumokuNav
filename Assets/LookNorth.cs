using System;
using UnityEngine;
using UnityEngine.UI;

public class LookAtNorth : MonoBehaviour
{
    public GameObject NorthText = null; // 緯度を表示するための文字
    public GameObject pushMetaButtonText = null; // Metaボタンが押されたことを表示するための文字
    public GameObject objectToRotate;   // 回転させる3Dオブジェクト
    private Quaternion initialRotation; // 初期の回転を保存するための変数

    void Start()
    {
        Input.location.Start(); // GPS機能を開始
        initialRotation = objectToRotate.transform.rotation; // 初期の回転を保存

        // 現在地の緯度経度を取得
        Location startLocation = new Location(Input.location.lastData.latitude, Input.location.lastData.longitude);
        Location endLocation = new Location(89.999999d, 139.544650d); // 北極の緯度経度

        // 方位角の計算
        double direction = NaviMath.LatlngDirection(startLocation, endLocation);
        // 3Dオブジェクトの回転を設定
        objectToRotate.transform.localEulerAngles = new Vector3(0, (float)direction, 0);

        // 方位角をテキストに表示
        Text northComponent = NorthText.GetComponent<Text>();
        northComponent.text = "現在地から北極の方位角は " + direction.ToString("F2") + "°";
    }

    void Update()
    {
        // Aボタンが押されたらリセット処理を実行
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            HandleAButtonPress();
        }
    }

    // Aボタンが押されたときに呼ばれるメソッド
    private void HandleAButtonPress()
    {
        Text pushMetaButtonComponent = pushMetaButtonText.GetComponent<Text>();
        pushMetaButtonComponent.text = "Aボタンが押され、正面リセットが行われました。";
        Debug.Log("Aボタンが押され、正面リセットが行われました。");

        // 3Dオブジェクトの回転をリセット
        objectToRotate.transform.rotation = initialRotation;
    }
}
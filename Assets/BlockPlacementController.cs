using System.Collections.Generic;
using UnityEngine;

public class BlockPlacementController : MonoBehaviour
{
    public GameObject blockPrefab; // 配置するブロックのプレハブ
    public Transform parentTransform; // ブロックをまとめる親オブジェクトのTransform
    public float scalingFactor = 1.0f; // 緯度・経度をUnity座標に変換する際のスケーリングファクター
    public DirectionController directionController; // DirectionControllerの参照
    public Calculation calculation;// Calculationの参照

    void Start()
    {
        // Startでブロックを配置するように呼び出し
        // RequestAndPlaceBlocks();
    }

    // public void RequestAndPlaceBlocks()
    // {
    //     // DirectionControllerから経路データを取得
    //     List<Vector2> positions = directionController.GetRouteData();

    //     // 取得したデータに基づいてブロックを配置
    //     if (positions != null && positions.Count > 0)
    //     {
    //         foreach (var position in positions)
    //         {
    //             Vector3 blockPosition = ConvertToUnityPosition(position.x, position.y);
    //             Instantiate(blockPrefab, blockPosition, Quaternion.identity, parentTransform);
    //             Debug.Log($"Placed block at: {blockPosition}");
    //         }
    //     }
    //     else
    //     {
    //         Debug.LogWarning("No positions received from DirectionController.");
    //     }
    // }

    private Vector3 ConvertToUnityPosition(float latitude, float longitude)
    {
        // 緯度経度をUnity座標に変換
        float x = longitude * scalingFactor;
        float z = latitude * scalingFactor;
        return new Vector3(x, 0, z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrailleBlockPlacer : MonoBehaviour
{
    public GameObject brailleBlockPrefab; // 点字ブロックのプレハブ
    public GameObject startBlockPrefab; // 直線の最初に配置するブロックのプレハブ
    public GameObject endBlockPrefab; // 直線の最後に配置するブロックのプレハブ
    public Calculation calculation; // Calculationの参照
    public bool startFlag = false;
    private List<GameObject> placedBlocks = new List<GameObject>(); // 配置したブロックのリスト
    private Vector3 initialPosition; // 初期位置

    void Start()
    {
        // 初期位置を設定
        initialPosition = transform.position;
    }

    void Update()
    {
        if (startFlag)
        {
            // 以前に配置した点字ブロックをすべて消去
            foreach (GameObject block in placedBlocks)
            {
                Destroy(block);
            }
            placedBlocks.Clear();

            // ブロック配置処理のための初期化
            Vector3 currentPos = initialPosition;

            for (int i = 0; i < calculation.disData.Length; i++)
            {
                float angleInRadians = calculation.dirData[i] * Mathf.Deg2Rad;
                Vector3 direction = new Vector3(Mathf.Sin(angleInRadians), 0, Mathf.Cos(angleInRadians));
                float remainingDistance = calculation.disData[i];
                float blockSize = 0.3f; // 30cm = 0.3m

                // 最初の位置にスタートブロックを配置
                if (i == 0)
                {
                    // currentPos -= direction * blockSize;
                    GameObject startBlock = Instantiate(startBlockPrefab, currentPos, Quaternion.LookRotation(direction));
                    placedBlocks.Add(startBlock);
                }

                // 直線の途中に通常の点字ブロックを配置
                while (remainingDistance > blockSize)
                {
                    currentPos += direction * blockSize * 17;
                    GameObject newBlock = Instantiate(brailleBlockPrefab, currentPos, Quaternion.LookRotation(direction));
                    placedBlocks.Add(newBlock);

                    remainingDistance -= blockSize;
                }

                // 最後の位置にエンドブロックを配置
                currentPos += direction * remainingDistance;
                GameObject endBlock = Instantiate(endBlockPrefab, currentPos, Quaternion.LookRotation(direction));
                placedBlocks.Add(endBlock);
            }

            // 処理が完了したらフラグをリセット
            startFlag = false;
        }
    }
}
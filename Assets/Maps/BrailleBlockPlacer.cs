using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrailleBlockPlacer : MonoBehaviour
{
    public GameObject brailleBlockPrefab; // 点字ブロックのプレハブ
    public Calculation calculation;// Calculationの参照
    public bool startFlag = false;

    void Start()
    {

    }

    void Update()
    {
        if (startFlag == true)
        {
            // ブロック配置処理を実行
            Vector3 currentPos = transform.position;

            for (int i = 0; i < calculation.disData.Length; i++)
            {
                float angleInRadians = calculation.dirData[i] * Mathf.Deg2Rad;
                Vector3 direction = new Vector3(Mathf.Cos(angleInRadians), 0, Mathf.Sin(angleInRadians));
                float remainingDistance = calculation.disData[i];
                float blockSize = 0.3f; // 30cm = 0.3m

                while (remainingDistance > 0)
                {
                    // 新しいブロックを生成し、配置
                    Instantiate(brailleBlockPrefab, currentPos, Quaternion.LookRotation(direction));

                    // 現在のポジションを更新
                    currentPos += direction * blockSize;

                    // 残りの距離を更新
                    remainingDistance -= blockSize;
                }
            }
            startFlag = false;
        }
    }
}


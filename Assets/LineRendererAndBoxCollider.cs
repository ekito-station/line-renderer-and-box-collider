using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererAndBoxCollider : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;

    void Start()
    {
        Vector3 startPos = new Vector3(1.0f, 1.0f, 5.0f);  // 始点
        Vector3 endPos = new Vector3(5.0f, 5.0f, 1.0f);    // 終点
        // Unityのシーンで始点と終点を指定する場合は以下の2行を用いる
        // Vector3 startPos = startPoint.transform.position;   // 始点
        // Vector3 endPos = endPoint.transform.position;       // 終点

        Vector3 lineVec = endPos - startPos;
        float dist = lineVec.magnitude;
        Vector3 lineX = new Vector3(dist, 0f, 0f);        

        // LineRendererで原点からX軸方向に線を引く
        GameObject line = new GameObject("Line");   // 空のゲームオブジェクトを作成
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();  // LineRendererをアタッチ
        lineRenderer.useWorldSpace = false; // ローカル座標
        Vector3[] linePositions = new Vector3[] {Vector3.zero, lineX};
        lineRenderer.SetPositions(linePositions);

        // BoxColliderを設置する
        BoxCollider col = line.AddComponent<BoxCollider>();

        // 線を本来の位置・向きに移動・回転させる
        line.transform.rotation = Quaternion.FromToRotation(lineX, lineVec);    // 本来の向きに
        line.transform.position += startPos;    // 本来の位置に
    }
}

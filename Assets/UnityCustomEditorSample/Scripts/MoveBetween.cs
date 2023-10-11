using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    [SerializeField] private float speed;
    
    // (プロパティなどで変更するようにした方が綺麗)
    public Vector3 destination;
    private Vector3 _origin;
    
    private void Start()
    {
        _origin = transform.position;
    }

    private void Update()
    {
        // 目標地点に向かって移動する
        var nextPosition = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        
        if (nextPosition == destination)
        {
            // 目標地点に到達したら、目標地点と原点を入れ替える
            (destination, _origin) = (_origin, destination);
        }
        
        transform.position = nextPosition;
    }
    
//  #if UNITY_EDITOR .. #endif で囲まれた範囲は、ビルドに含まれない
#if UNITY_EDITOR

    // Gizmos(シーンビューに表示される線や図形)を描画する時に使うイベント関数。デバッグ情報を表示するのに便利
    private void OnDrawGizmos()
    {
        // ゲームが再生されていないとき、原点を現在位置にする
        if(!Application.isPlaying) _origin = transform.position;
        
        // 線と目標点を描画する
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_origin, 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(destination, 0.5f);
        Gizmos.DrawLine(destination, _origin);
    }
#endif
}

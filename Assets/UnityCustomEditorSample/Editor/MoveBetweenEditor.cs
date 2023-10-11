using UnityEditor; // Editor拡張を使うときに使う
using UnityEngine;

// MoveBetweenクラスのインスペクターを拡張し、Editorクラスを継承する。
[CustomEditor(typeof(MoveBetween))]
public class MoveBetweenEditor : Editor
{
    // MoveBetweenコンポーネントがついたGameObjectを選択した時に呼ばれる(Updateみたいなもの)
    private void OnSceneGUI()
    {
        // targetはEditorクラスのプロパティで、選択中のコンポーネントを取得できる
        MoveBetween moveBetween = (MoveBetween)target;
        
        
        // 変更があったかどうかのチェックを開始する
        EditorGUI.BeginChangeCheck();
        // 位置を変更するハンドルを表示
        Vector3 position = Handles.PositionHandle(moveBetween.destination, Quaternion.identity);
        if(EditorGUI.EndChangeCheck())
        {
            // ハンドルに変更があった場合
            
            // Undoに登録する (Ctrl+Zに対応する)
            Undo.RecordObject(moveBetween, "Change Destination");
            // 目標地点を更新する
            moveBetween.destination = position;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HoopScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] bool isMovingHoopGame;
    [SerializeField] GameObject objectToMove;
    [SerializeField] float rotationSpeed = 0.1f;
    int score = 0;
    
    
    void Start()
    {
        //ScoreText = GameObject.Find("Hoop Score").GetComponent<TMP_Text>();
    }

    
    void Update()
    {
        if (isMovingHoopGame) 
        {
            objectToMove.transform.Rotate(0, rotationSpeed, 0 * Time.deltaTime);
        }
    }
    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }
}
//[CustomEditor(typeof(HoopScoreManager))]
//public class MyScriptEditor : Editor
//{
//    override public void OnInspectorGUI()
//    { 
//        var myScript = target as HoopScoreManager;

//        myScript.isMovingHoopGame = GUILayout.Toggle(myScript.isMovingHoopGame, "Moving?");

//        if (myScript.isMovingHoopGame)
//            myScript.objectToMove = (GameObject)EditorGUILayout.ObjectField("GameObject", myScript.objectToMove, typeof(GameObject), true);

//    }
//}

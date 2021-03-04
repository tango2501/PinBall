using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCountController : MonoBehaviour
{
    
    //スコアを表示するテキスト
    private Text scoreCount;
    
    
    //スコアをカウントする変数
    private int scorecounter;
    

    /*
    //インスペクタ用
    public Text ScoreCount;
    //スコア管理用
    private int score = 0;
    */


    // Start is called before the first frame update
    void Start()
    {
        
        
        //スコアを0で初期化
        scorecounter = 0;
        //シーン中のScoreCountオブジェクトを取得
        this.scoreCount = GameObject.Find("ScoreCount").GetComponent<Text>();
        
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
        this.scoreCount.text = scorecounter.ToString();
        
    }
}


/*
カウントする関数を別で作る。
当たったオブジェクトをタグで識別して、それに応じた点数をscorecounterに加算していく。
oncollision内にifで作れるっぽい
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//スクリプトでUIを操作する場合は、「using UnityEngine.UI;」を記述する。

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private Text scoreCount;


    //スコアをカウントする変数
    private int scorecounter;

   

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        
        //スコアを0で初期化
        scorecounter = 0;
        //シーン中のScoreCountオブジェクトを取得
        this.scoreCount = GameObject.Find("ScoreCount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z <this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "GameOver";
        }
        
    }

    //スコア加算関数を呼び出す
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            this.scorecounter += 20;
            this.scoreCount.text = scorecounter.ToString();
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            this.scorecounter += 30;
            this.scoreCount.text = scorecounter.ToString();
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            this.scorecounter += 40;
            this.scoreCount.text = scorecounter.ToString();
        }
        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            this.scorecounter += 50;
            this.scoreCount.text = scorecounter.ToString();
        }

        
    }


}

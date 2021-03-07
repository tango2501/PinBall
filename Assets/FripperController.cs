using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20f;
    //弾いたときの傾き
    private float frickAngle = -20f;
    //タッチされた座標
    private Vector2 touchPos;
    //タッチ状態
    private TouchPhase touchphase;

    //ID保存用
    Touch Rtouch;
    Touch Ltouch;
    //状態保存用
    TouchPhase Rtouchp;
    TouchPhase Ltouchp;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();
        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
        //上記二つでフリッパーの初期位置を設定している



    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        //左矢印キーとaキーを押したとき左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) | Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle(this.frickAngle);
        }
        //右矢印キーとdキーを押したとき右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.frickAngle);
        }

        //左矢印キーとaキーが離された時にフリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) | Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle(defaultAngle);
        }
        //右矢印キーとdキー離された時にフリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.RightArrow) | Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(defaultAngle);
        }
        //Sキーと下矢印キーで両方のフリッパーを動かす
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetAngle(this.frickAngle);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            SetAngle(defaultAngle);
        }
#endif
#if UNITY_ANDROID
        //タッチの検出
        if (Input.touchCount > 0)
        {
            //タッチした指の数だけ以下の処理をする
            for (int i = 0; i < Input.touchCount; i++)
            {

                //タッチした指の状態を管理
                touchphase = Input.GetTouch(i).phase;
                //タッチした指の座標を管理
                touchPos = Input.GetTouch(i).position;

                //タッチされた時の座標によって上げるフリッパーを選び、フリッパーを上げる
                if (touchPos.x > (Screen.width / 2) && touchphase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    //右フリッパーを上げた指の情報を記憶
                    Rtouchp = Input.GetTouch(i).phase;
                    Rtouch.fingerId = Input.GetTouch(i).fingerId;
                    
                    //フリッパーを上げる
                    SetAngle(this.frickAngle);
                    Debug.Log("rightup");
                    //Debug.Log(righttouch);
                }
                if (touchPos.x < (Screen.width / 2) && touchphase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    //左フリッパーを上げた指の情報を記憶
                    Ltouchp = Input.GetTouch(i).phase;
                    Ltouch.fingerId = Input.GetTouch(i).fingerId;

                    //フリッパーを上げる
                    SetAngle(this.frickAngle);
                    Debug.Log("leftup");
                    
                }

                //指が離れたときにその指のIDを参照して、その指が上げたフリッパーを下げる
                if (Input.GetTouch(i).phase == TouchPhase.Ended && Input.GetTouch(i).fingerId == Rtouch.fingerId && tag == "RightFripperTag")
                {
                    SetAngle(defaultAngle);
                    Debug.Log("rightdown");
                }
                if (Input.GetTouch(i).phase == TouchPhase.Ended && Input.GetTouch(i).fingerId == Ltouch.fingerId && tag == "LeftFripperTag")
                {
                    SetAngle(defaultAngle);
                    Debug.Log("leftdown");
                }
            }
        }
#endif
    }
    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring JointSpr = this.myHingeJoint.spring;
        JointSpr.targetPosition = angle;
        this.myHingeJoint.spring = JointSpr;
    }
}
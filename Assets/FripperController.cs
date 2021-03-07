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
    //タッチポジション格納
    private Vector2 touchPos;
    //タッチ状態確認
    private TouchPhase touchphase;
    



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
        //タッチ追跡用


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


        //タッチが効いているかどうかの確認用
        if (Input.touchCount > 0)
        {
            
            Touch[] myTouches = Input.touches;

            for (int i = 0; i < myTouches.Length; i++)
            {
                myTouches[i].fingerId = Input.GetTouch(i).fingerId;
                touchphase = Input.GetTouch(i).phase;
                touchPos = Input.GetTouch(i).position;
                /*
                int righttouch = Input.GetTouch(i).fingerId;
                int lefttouch = Input.GetTouch(i).fingerId;
                */

                if (touchPos.x > (Screen.width / 2) && touchphase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    
                    SetAngle(this.frickAngle);
                    Debug.Log("rightup");
                    //Debug.Log(righttouch);
                }
                if (touchPos.x > (Screen.width / 2) && touchphase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    SetAngle(defaultAngle);
                    Debug.Log("rightdown");
                    //Debug.Log(righttouch);
                }



                if (touchPos.x < (Screen.width / 2) && touchphase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    
                    SetAngle(this.frickAngle);
                    Debug.Log("leftup");
                    //Debug.Log(lefttouch);

                }
                if (touchPos.x < (Screen.width / 2) && touchphase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    SetAngle(defaultAngle);
                    Debug.Log("leftdown");
                    //Debug.Log(lefttouch);
                }



            }

        }



    }
    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring JointSpr = this.myHingeJoint.spring;
        JointSpr.targetPosition = angle;
        this.myHingeJoint.spring = JointSpr;
    }
}
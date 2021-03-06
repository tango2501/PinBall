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
    private TouchPhase  touchphase;
    int leftfripper = -1;
    int rightfripper = -2;

    TouchPhase lefttouchphase ;
    TouchPhase righttouchphase ;

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
        if (Input.GetKeyDown(KeyCode.LeftArrow) | Input.GetKeyDown(KeyCode.A)  && tag == "LeftFripperTag")
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
        
        //タッチがあった時
        if (Input.touchCount > 0)
        {
            //タッチされている指の数だけiを増やす
            for (int i = 0; i < Input.touchCount; i++)
            {
                /*Debug.Log("touches[" + i + "]");
                Debug.Log("  position.x : " + Input.touches[i].position.x);
                Debug.Log("  phase : " + Input.touches[i].phase);*/

                if (Input.GetTouch(i).position.x > Screen.width / 2 && touchphase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    SetAngle(this.frickAngle);
                    Debug.Log("rightup");
                    rightfripper = Input.touches[i].fingerId;
                    lefttouchphase = Input.GetTouch(i).phase;
                }
                else if(Input.GetTouch(i).position.x < Screen.width / 2 && touchphase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    SetAngle(this.frickAngle);
                    Debug.Log("lefttup");
                    leftfripper = Input.touches[i].fingerId;
                    lefttouchphase = Input.GetTouch(i).phase;
                }

                if(lefttouchphase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    SetAngle(defaultAngle);
                }
                if (righttouchphase == TouchPhase.Ended && leftfripper == leftfripper && tag == "RightFripperTag")
                {
                    SetAngle(defaultAngle);
                }
            }

         






            /*
            //タッチが効いているかどうかの確認用
            if (Input.touchCount > 0)
        {
            /*
            int i = Input.touchCount;
            var finid = Input.GetTouch(0);
            */
            /*
            int tes = Input.GetTouch(0).fingerId;

            Touch i = Input.touches;*/
            /*
            Touch[] myTouches = Input.touches;

            for (int i = 0; i < myTouches.Length; i++)
            {
                touchphase = Input.GetTouch(i).phase;
                touchPos = Input.GetTouch(i).position;
                int righttouch = Input.GetTouch(i).fingerId;
                int lefttouch = Input.GetTouch(i).fingerId;

                if (touchPos.x > (Screen.width / 2) && touchphase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    righttouch = Input.touches[i].fingerId;
                    SetAngle(this.frickAngle);
                    Debug.Log("rightup");
                    Debug.Log(righttouch);
                }
                if (touchphase == TouchPhase.Ended && righttouch == Input.GetTouch(i).fingerId && tag == "RightFripperTag")
                {
                    SetAngle(defaultAngle);
                    Debug.Log("rightdown");
                    Debug.Log(righttouch);
                }



                if (touchPos.x < (Screen.width / 2) && touchphase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    lefttouch = Input.touches[i].fingerId;
                    SetAngle(this.frickAngle);
                    Debug.Log("leftup");
                    Debug.Log(lefttouch);
                    
                }
                if (touchphase == TouchPhase.Ended && lefttouch == Input.GetTouch(i).fingerId && tag == "LeftFripperTag")
                {
                    SetAngle(defaultAngle);
                    Debug.Log("leftdown");
                    Debug.Log(lefttouch);
                }



            }
            */
            






                /*
                touchphase = Input.GetTouch(0).phase;
                touchPos = Input.GetTouch(0).position;


                //Debug.Log(TouchPos);

                if (touchPos.x > (Screen.width /2) &&  touchphase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    int righttouch = Input.GetTouch(0).fingerId;


                    SetAngle(this.frickAngle);
                    Debug.Log("rightup");
                    if (touchphase == TouchPhase.Ended && righttouch == Input.GetTouch(0).fingerId && tag == "RightFripperTag")
                    {
                        SetAngle(defaultAngle);
                        Debug.Log("rightdown");
                    }
                }
                */


                /*
                if (touchPos.x < (Screen.width / 2) && touchphase == TouchPhase.Began && tag == "LeftFripperTag")
                {

                    SetAngle(this.frickAngle);
                    Debug.Log("leftup");
                }
                if (touchphase == TouchPhase.Ended && finid.fingerId == i && tag == "LeftFripperTag")
                {
                    SetAngle(defaultAngle);
                    Debug.Log("leftdown");
                }
                */

                /*
                else if(TouchPos.x < (Screen.width / 2) && touchphase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    SetAngle(this.frickAngle);
                    Debug.Log("left");
                }

                if (TouchPos.x > (Screen.width / 2) && touchphase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    SetAngle(defaultAngle);
                    Debug.Log("rightdown");
                }
                else if (TouchPos.x < (Screen.width / 2) && touchphase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    SetAngle(defaultAngle);
                    Debug.Log("leftdown");
                }
                */


            }
        


    }
    //フリッパーの傾きを設定
    public void SetAngle (float angle)
    {
        JointSpring JointSpr = this.myHingeJoint.spring;
        JointSpr.targetPosition = angle;
        this.myHingeJoint.spring = JointSpr;
    }
}

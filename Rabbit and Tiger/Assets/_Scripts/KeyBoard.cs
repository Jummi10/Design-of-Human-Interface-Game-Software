using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.AI;


public class KeyBoard : MonoBehaviour
{
    public float speed = 10f;
    public Transform Player;        // 플레이어.
                                    //  public Transform Stick;         // 조이스틱.

    // 비공개/*
    /*  private Vector3 StickFirstPos;  // 조이스틱의 처음 위치.
     private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
     private float Radius;           // 조이스틱 배경의 반 지름.
     private bool MoveFlag;          // 플레이어 움직임 스위치.
     */
    public Animator _animator;
    private float m_currenth = 0;
    private float m_interpolation = 10;
    private float m_turnSpeed = 100;
    public Image background;
    //public static bb;
    public float Y;
    public float X;
    bool RabbitRun;



    Vector3 oldPos; // blue 수정 20190607


    // Start is called before the first frame update
    void Start()
    {
        //*       
        oldPos = new Vector3(Player.localRotation.x, Player.localRotation.y - 90, Player.localRotation.z);
        //Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        //StickFirstPos = Stick.transform.position;

        // 캔버스 크기에대한 반지름 조절.
        //float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        //Radius *= Can;

        //MoveFlag = false;
        //*/

    }

    // Update is called once per frame
    void Update()
    {
       


        background.GetComponent<JoyStick>().MoveFlag = false;
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            float h = Input.GetAxis("Horizontal");
            m_currenth = Mathf.Lerp(m_currenth, h, Time.deltaTime * m_interpolation);
            background.GetComponent<JoyStick>().MoveFlag = true;
            transform.Rotate(0, m_currenth * m_turnSpeed * Time.deltaTime, 0);
            _animator.SetBool("RabbitRun", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float h = Input.GetAxis("Horizontal");
            m_currenth = Mathf.Lerp(m_currenth, h, Time.deltaTime * m_interpolation);
            background.GetComponent<JoyStick>().MoveFlag = true;
            transform.Rotate(0, m_currenth * m_turnSpeed * Time.deltaTime, 0);
            _animator.SetBool("RabbitRun", true);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            background.GetComponent<JoyStick>().MoveFlag = true;
            transform.Translate((Vector3.forward * speed * Time.deltaTime) / 3f);
            _animator.SetBool("RabbitRun", true);
        }
        /*
        if (Input.GetKey(KeyCode.DownArrow))
        {
           background.GetComponent<JoyStick>().MoveFlag = true;
           transform.Translate((Vector3.down * speed * Time.deltaTime) / 3f);
           _animator.SetBool("RabbitRun", true);

        }*/

    }


   


}
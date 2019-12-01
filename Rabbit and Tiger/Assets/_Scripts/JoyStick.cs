using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    //https://truecode.tistory.com/32?category=611884
    //3D에서 조이스틱 구현하기 위해 코드 참고

    // 공개
    public Transform Player;        // 플레이어.
    public Transform Stick;         // 조이스틱.

    // 비공개
    private Vector3 StickFirstPos;  // 조이스틱의 처음 위치.
    private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
    private float Radius;           // 조이스틱 배경의 반 지름.
    public bool MoveFlag;          // 플레이어 움직임 스위치.
    public Vector3 Pos;
    public Animator _animator;
    bool RabbitRun;

    Vector3 oldPos; // blue 수정 20190607

    void Start()
    {
        oldPos = new Vector3(Player.localRotation.x, Player.localRotation.y - 90, Player.localRotation.z);
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        // 캔버스 크기에대한 반지름 조절.
        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;

        MoveFlag = false;
    }
    
    void Update()
    {
        if (MoveFlag)
        {
          //  Player.transform.Translate(Vector3.forward * Time.deltaTime * 3.3f); //토끼속도
            _animator.SetBool("RabbitRun", true);
        }
        else
        {
            _animator.SetBool("RabbitRun", false);
        }

    }

    // 드래그
    public void Drag(BaseEventData _Data)
    {
        MoveFlag = true;
        PointerEventData Data = _Data as PointerEventData;
          Pos = Data.position;
        //Vector3 Pos = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"),0);
        Debug.Log(Pos.x);
        Debug.Log("xx");
        Debug.Log(Pos.y);
        Debug.Log(Pos.z);
        // 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래)
        JoyVec = (Pos - StickFirstPos).normalized;

        // 조이스틱의 처음 위치와 현재 내가 터치하고있는 위치의 거리를 구한다.
        float Dis = Vector3.Distance(Pos, StickFirstPos);

        // 거리가 반지름보다 작으면 조이스틱을 현재 터치하고 있는 곳으로 이동.
        if (Dis < Radius)
        {
            Stick.position = StickFirstPos + JoyVec * Dis;
        }
        // 거리가 반지름보다 커지면 조이스틱을 반지름의 크기만큼만 이동.
        else
        {
            Stick.position = StickFirstPos + JoyVec * Radius;
        }


        Player.eulerAngles = new Vector3(0, Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg, 0) + oldPos; // blue 수정 20190607


    }

    // 드래그 끝.
    public void DragEnd()
    {
        oldPos = Player.eulerAngles; // blue 수정 20190607
        Stick.position = StickFirstPos; // 스틱을 원래의 위치로.
        JoyVec = Vector3.zero;          // 방향을 0으로.
        MoveFlag = false;
    }
}

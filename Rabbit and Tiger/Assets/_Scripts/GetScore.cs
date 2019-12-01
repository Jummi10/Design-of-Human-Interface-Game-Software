using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class GetScore : MonoBehaviour
{
    //Rabbit script
    int score = 0;  //먹은 곶감 개수
    float timer = 0f; //시간제한
    public Text scoreSet;

    public Animator _animator;  //토끼
    bool RabbitDie;

    public GameObject BigPeach;
    public GameObject Tiger;
    public GameObject Tiger2;
    public GameObject posionlight;
    public GameObject redlight;

    public GameObject peachgreen;
    public GameObject peachpink;
    public GameObject peachred;
    public GameObject peachblack;
    public GameObject peachblack2;
    public GameObject peachblack3;

    public Text BigPeachsound;
    public Text TigerRabbitSound;

    public GameObject Panel;
    public Text success;
    public Text fail;
    public Button home;
    public Button next;
    public Button home2;
    public Button retry;
    public Button End;
    public Image mission;
    public Button Skip;

    private AudioSource source;
    public AudioClip peach;
    public AudioClip Bigpeach;
    public AudioClip Poison;

    public GameObject player;

    public Image message1;
    public Image message2;
    public Image message3;
    public Image message4;

    private bool isPause = true; //게임종료시 모든 오브젝트 정지


    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        _animator.SetBool("RabbitDie", false);
        BigPeach.gameObject.SetActive(false);
        BigPeachsound.gameObject.SetActive(false);
        posionlight.gameObject.SetActive(false);
        redlight.gameObject.SetActive(false);
        mission.gameObject.SetActive(true);

        peachgreen.gameObject.SetActive(false);
        peachpink.gameObject.SetActive(false);
        peachred.gameObject.SetActive(false);
        peachblack.gameObject.SetActive(false);
        peachblack2.gameObject.SetActive(false);
        peachblack3.gameObject.SetActive(false);

        Panel.gameObject.SetActive(false);
        success.gameObject.SetActive(false);
        fail.gameObject.SetActive(false);
        home.gameObject.SetActive(false);
        home2.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
        retry.gameObject.SetActive(false);
        //End.gameObject.SetActive(false);
        TigerRabbitSound.gameObject.SetActive(false);

        message1.gameObject.SetActive(false);
        message2.gameObject.SetActive(false);
        message3.gameObject.SetActive(false);
        message4.gameObject.SetActive(false);


        source = GetComponent<AudioSource>();
        Time.timeScale = 1;

        StartCoroutine(missionstart());
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<KeyBoard>().speed > 10 || player.GetComponent<KeyBoard>().speed < 10)
        {
            timer += Time.deltaTime;
            if (timer >= 10.0)
            {
                player.GetComponent<KeyBoard>().speed = 10;
                timer = 0f;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Peach")
        {
            source.clip = peach;
            source.Play();
            score++;
            SetCountText();
            other.gameObject.SetActive(false);
        }

        if (other.tag == "BigP")
        {
            source.clip = Bigpeach;
            source.Play();
            other.gameObject.SetActive(false);
            Tiger.GetComponent<AudioSource>().Stop();  //호랑이 소리 멈추게
            Tiger2.GetComponent<AudioSource>().Stop();  //호랑이 소리 멈추게

            StartCoroutine(TimeStop1());
        }

        if (other.tag == "Tiger")
        {
            TigerRabbitSound.gameObject.SetActive(true);
            _animator.SetBool("RabbitDie", true);
            redlight.gameObject.SetActive(true);

            StartCoroutine(TimeStop2());
        }

        if (other.tag == "Poison")
        {
            source.clip = Poison;
            source.Play();
            posionlight.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            _animator.SetBool("RabbitDie", true);

            StartCoroutine(TimeStop2());
        }


        if (other.tag == "Item")
        {
            int random = Random.Range(0, 4);

            if (random == 0)
            { //토끼 속도 빠르게
                message1.gameObject.SetActive(true);
                Debug.Log("Item: Faster");
                player.GetComponent<KeyBoard>().speed = 20;
                StartCoroutine(TimeStop_M1());
            }

            if (random == 1) //토끼 속도 느리게
            {
                message2.gameObject.SetActive(true);
                Debug.Log("Item: Slower");
                player.GetComponent<KeyBoard>().speed = 5;
                StartCoroutine(TimeStop_M2());
            }

            if (random == 2)
            { //곶감 갯수 reset
                message3.gameObject.SetActive(true);
                Debug.Log("Item: Reset");
                score = 0;
                SetCountText();
                StartCoroutine(TimeStop_M3());
            }

            if (random == 3)
            { //곶감 갯수 +3
                message4.gameObject.SetActive(true);
                Debug.Log("Item: Add");
                score += 3;
                SetCountText();
                StartCoroutine(TimeStop_M4());
            }

            other.gameObject.SetActive(false);
        }

    }

    IEnumerator TimeStop1()
    {
        message1.gameObject.SetActive(false);
        message2.gameObject.SetActive(false);
        message3.gameObject.SetActive(false);
        message4.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);

        Panel.gameObject.SetActive(true);
        success.gameObject.SetActive(true);
        home.gameObject.SetActive(true);
        next.gameObject.SetActive(true);
        End.gameObject.SetActive(true);
        Skip.gameObject.SetActive(false);

        peachgreen.gameObject.SetActive(true);
        peachpink.gameObject.SetActive(true);
        peachred.gameObject.SetActive(true);

        Time.timeScale = 0; //정지, 시간이 어떤 속도로 흘러가는지, 모든 씬의 게임오브젝트들이 공유 영향받음
        isPause = false; //정지
    }

    IEnumerator TimeStop2()
    {
        message1.gameObject.SetActive(false);
        message2.gameObject.SetActive(false);
        message3.gameObject.SetActive(false);
        message4.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        Panel.gameObject.SetActive(true);
        fail.gameObject.SetActive(true);
        home2.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);
        Skip.gameObject.SetActive(false);

        peachblack.gameObject.SetActive(true);
        peachblack2.gameObject.SetActive(true);
        peachblack3.gameObject.SetActive(true);

        Time.timeScale = 0; //정지, 시간이 어떤 속도로 흘러가는지, 모든 씬의 게임오브젝트들이 공유 영향받음
        isPause = false; //정지
    }

    IEnumerator TimeStop_M1()
    {
        yield return new WaitForSeconds(2f);
        message1.gameObject.SetActive(false);
    }

    IEnumerator TimeStop_M2()
    {
        yield return new WaitForSeconds(2f);
        message2.gameObject.SetActive(false);
    }

    IEnumerator TimeStop_M3()
    {
        yield return new WaitForSeconds(2f);
        message3.gameObject.SetActive(false);
    }

    IEnumerator TimeStop_M4()
    {
        yield return new WaitForSeconds(2f);
        message4.gameObject.SetActive(false);
    }

    IEnumerator missionstart()
    {
        yield return new WaitForSeconds(7f);

        mission.gameObject.SetActive(false);
        Skip.gameObject.SetActive(false);
    }

    void SetCountText()
    {
        scoreSet.text = score.ToString();

        if (score >= 10)
        {
            BigPeach.gameObject.SetActive(true);
            BigPeachsound.gameObject.SetActive(true);
        }
    }
}
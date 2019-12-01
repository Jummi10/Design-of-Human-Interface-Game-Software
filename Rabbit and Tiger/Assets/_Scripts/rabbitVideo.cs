using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

//intro video
public class rabbitVideo : MonoBehaviour
{
    VideoPlayer vp;
    public VideoClip rabbit;

    public Camera camera1;  //인트로 영상 카메라

    public Button videoskip;
    public Button touch;

    // Start is called before the first frame update
    void Awake()
    {
        camera1.gameObject.SetActive(true);
        videoskip.gameObject.SetActive(true);
        touch.gameObject.SetActive(false);

        VideoPlayer vp = gameObject.AddComponent<VideoPlayer>();
        vp.clip = rabbit;
        vp.targetCamera = camera1;
        vp.renderMode = VideoRenderMode.CameraFarPlane;
        vp.Play();

        StartCoroutine(gameStart());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator gameStart()
    {
        yield return new WaitForSeconds(29f);

        //VideoPlayer vp = gameObject.GetComponent<VideoPlayer>();
        //vp.Pause();

        camera1.gameObject.SetActive(true); //false
        videoskip.gameObject.SetActive(false);
        //Title.gameObject.SetActive(true);
        touch.gameObject.SetActive(true);       
    }
}

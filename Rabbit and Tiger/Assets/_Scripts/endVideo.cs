using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class endVideo : MonoBehaviour
{
    VideoPlayer vp;
    public VideoClip end;

    public Camera camera1;
    public Button again;

    // Start is called before the first frame update
    void Start()
    {
        again.gameObject.SetActive(true);

        VideoPlayer vp = gameObject.AddComponent<VideoPlayer>();
        vp.clip = end;
        vp.targetCamera = camera1;
        vp.renderMode = VideoRenderMode.CameraFarPlane;
        vp.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

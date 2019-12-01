using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeachRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 70) * Time.deltaTime);   //곶감 회전
    }
}

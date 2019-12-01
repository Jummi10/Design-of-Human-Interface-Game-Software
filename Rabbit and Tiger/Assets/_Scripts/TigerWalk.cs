using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   //내비 사용

public class TigerWalk : MonoBehaviour
{
    //Tiger Script
    //NavMeshAgent 참조: https://mrbinggrae.tistory.com/122

    private AudioSource source;

    public Animator _animator;  //호랑이 애니메이터
    bool TigerIdle;
    bool TigerHit;

    private Transform rabbitTr;
    private NavMeshAgent nvAgent;   //navigation

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        _animator.SetBool("TigerIdle", false);
        _animator.SetBool("TigerHit", false);

        rabbitTr = GameObject.FindWithTag("rabbit").GetComponent<Transform>();
        nvAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nvAgent.SetDestination(rabbitTr.position);    //호랑이의 목적지==토끼.position
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "rabbit")
        {
            source.Stop();  //게임 끝나면 호랑이 소리 멈춤  
            _animator.SetBool("TigerHit", true);   //호랑이와 토끼가 부딪힐 때 hit
            _animator.SetBool("TigerIdle", true);   //호랑이와 토끼가 부딪히면 호랑이 idle         
        }
    }
}

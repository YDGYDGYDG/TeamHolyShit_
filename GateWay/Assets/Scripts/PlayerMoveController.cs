﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMoveController : MonoBehaviour
{
    Rigidbody2D rigidBody;  // 강체를 참조하기 위한 변수
    public float jumpForce = 1500.0f;   // 점프에 전달할 힘 값
    public float walkForce = 400.0f;    // 달리기 힘
    public float brakeForce = -400f;    // 브레이크 힘
    public float jumpSpeed = 600.0f;    // 이동 점프 스피드
    public float speed = 0.01f; // 이속

    // =============================================
    // 점프 변수
    // 바닥에 닿았는지 판단
    RaycastHit2D LHit;
    RaycastHit2D RHit;
    LayerMask moveLayerMask;
    LayerMask waterLayerMask;
    LayerMask wallLayerMask;
    LayerMask steelwallLayerMask;

    float playerSize;
    // 점프 상태
    public bool jump;
    bool stopJump; // 제자리
    // 버튼 스위치
    public bool LBTrigger;
    public bool RBTrigger;

    HookShotScript player;


    //EventSystem eventSystem;


    SpriteRenderer playerPosition;      // 애니메이션 방향 판단(형준)
    Animator animator;                  // 애니메이터(형준)
    AudioSource audioSource;            // SE 재생관리자(형준)
    PlayerState playerState;            // 캐릭터 상태 스크립트(형준)




    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

        //eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

        moveLayerMask = ~(1 << LayerMask.NameToLayer("Player"));
        waterLayerMask = ~(1 << LayerMask.NameToLayer("Water"));
        playerSize = gameObject.GetComponent<CircleCollider2D>().bounds.extents.magnitude;

        player = GetComponent<HookShotScript>();

        // 스프라이트 렌더러 연결(형준)
        playerPosition = GetComponent<SpriteRenderer>();
        // 애니메이터 연결(형준)
        animator = GetComponent<Animator>();
        // SE 재생관리자 연결(형준)
        audioSource = GetComponent<AudioSource>();
        // 캐릭터 상태 스크립트 연결(형준)
        playerState = GetComponent<PlayerState>();
    }

    void FixedUpdate()
    {
        // 키보드 이동 
        if (LBTrigger)
        {
            LBDown();
            playerPosition.flipX = true;    // 애니메이션 방향 왼쪽(형준)

            // 추가 사항
            if (audioSource.isPlaying == false && !jump)
            {
                if (!jump)
                {
                    audioSource.clip = playerState.plyaerMove;
                    audioSource.Play();
                }

                else if (!stopJump)
                {
                    audioSource.clip = playerState.plyaerMove;
                    audioSource.Play();
                }
            }

        }
        if (RBTrigger)
        {
            RBDown();
            playerPosition.flipX = false;    // 애니메이션 방향 오른쪽(형준)

            // 추가 사항
            if (audioSource.isPlaying == false && !jump)
            {
                if (!jump)
                {
                    audioSource.clip = playerState.plyaerMove;
                    audioSource.Play();
                }

                else if (!stopJump)
                {
                    audioSource.clip = playerState.plyaerMove;
                    audioSource.Play();
                }
            }
        }
    }

    private void Update()
    {
        // 키보드 이동
        if (Input.GetKey(KeyCode.A))
        {
            LBtriggerON();
            playerPosition.flipX = true;    // 애니메이션 방향 왼쪽(형준)
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            LBtriggerOFF();
        }
        if (Input.GetKey(KeyCode.D))
        {
            RBtriggerON();
            playerPosition.flipX = false;    // 애니메이션 방향 오른쪽(형준)  
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            RBtriggerOFF();
        }

        // 점프 검사
        LHit = Physics2D.Raycast(transform.position + new Vector3(playerSize - 0.15f, -0.13f), Vector2.down, Mathf.Infinity, moveLayerMask);
        RHit = Physics2D.Raycast(transform.position + new Vector3(-playerSize + 0.15f, -0.13f), Vector2.down, Mathf.Infinity, moveLayerMask);

        if (LHit.distance > playerSize && RHit.distance > playerSize)
        {
            jump = true;
        }
        else if (LHit.distance <= playerSize || RHit.distance <= playerSize)
        {
                ResetMovement();
        }

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && jump == false)
        {
            JButtonDown();
        }
        // 제자리 점프 상태
        if (rigidBody.velocity.x == 0 && jump == true)
        {
            stopJump = true;
        }


        // 바닥에 충돌했을 때 다시 Idle 애니메이션으로 전환(형준)
        if (rigidBody.velocity.y < 0)
        {
            Debug.DrawRay(transform.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayDownHit = Physics2D.Raycast(transform.position + new Vector3(playerSize - 0.4f, -0.5f), Vector3.down, 0.3f);
            if (rayDownHit.collider != null)
            {
                if (rayDownHit.distance < 1)
                {
                    animator.SetBool("isJump", false);

                    if (LBTrigger == true && jump == false && stopJump == false)
                    {
                        animator.SetBool("isRun", true);
                       // audioSource.clip = playerState.plyaerMove;
                       // audioSource.Play();
                    }
                    else if(RBTrigger == true && jump == false && stopJump == false)
                    {
                        animator.SetBool("isRun", true);
                       // audioSource.clip = playerState.plyaerMove;
                       // audioSource.Play();
                    }

                }
            }
        }

        // 달리는 중에 점프할 시 처리(형준)
        if (jump == true && animator.GetBool("isJump"))
        {
            if (animator.GetBool("isRun") && jump == true && LBTrigger == true && rigidBody.velocity.y > 2)
            {
                animator.SetBool("isRun", false);

                audioSource.Stop();
                audioSource.clip = playerState.plyaerjump;
                audioSource.Play();
            }
            else if (animator.GetBool("isRun") && jump == true && RBTrigger == true && rigidBody.velocity.y > 2)
            {
                animator.SetBool("isRun", false);

                audioSource.Stop();
                audioSource.clip = playerState.plyaerjump;
                audioSource.Play();
            }
        }
    }

    public void LBtriggerON()
    {
        LBTrigger = true;

        // 애니메이션 중복재생 방지(형준)
        if (!animator.GetBool("isJump"))
        {
            animator.SetBool("isRun", true);
        }

        // SE 중복재생 방지(형준)
        if (audioSource.isPlaying == false && rigidBody.velocity.y > -2 && rigidBody.velocity.y < 2)
        {
           if (!jump || !stopJump)
           {
                audioSource.clip = playerState.plyaerMove;
                audioSource.Play();
            }
        }

        // 동시에 눌릴땐 재생하지마(형준)
        if (LBTrigger == true && RBTrigger == true)
        {
            audioSource.Stop();
            animator.SetBool("isRun", false);
        }
    }
    public void LBtriggerOFF()
    {
        if (!jump)
        {
            rigidBody.AddForce(-transform.right * brakeForce);
        }
        LBTrigger = false;
        animator.SetBool("isRun", false);   // Idle 애니메이션 출력(형준)
        audioSource.Stop(); // SE 스탑(형준)
    }
    public void RBtriggerON()
    {
        RBTrigger = true;

        // 애니메이션 중복재생 방지(형준)
        if (!animator.GetBool("isJump"))
        {
            animator.SetBool("isRun", true);
        }

        // SE 중복재생 방지(형준)
        if (audioSource.isPlaying == false && rigidBody.velocity.y > -2 && rigidBody.velocity.y < 2)
        {
            if (!jump || !stopJump)
            {
                audioSource.clip = playerState.plyaerMove;
                audioSource.Play();
            }
        }

        // 동시에 눌릴땐 재생하지마(형준)
        if (LBTrigger == true && RBTrigger == true)
        {
            audioSource.Stop();
            animator.SetBool("isRun", false);
        }

    }
    public void RBtriggerOFF()
    {
        if (!jump)
        {
            rigidBody.AddForce(transform.right * brakeForce);
            
        }
        RBTrigger = false;
        animator.SetBool("isRun", false);   // Idle 애니메이션 출력(형준)
        audioSource.Stop(); // SE 스탑(형준)
    }


    public void LBDown()
    {
        if (player.isAttachWall) 
        {
            ResetMovement();

           animator.SetBool("isRun", false);   // Idle 애니메이션 출력(형준)
        }
        else
        {
            if (jump == false && stopJump == false)
            {
                //transform.Translate(-speed, 0, 0);
                rigidBody.AddForce(new Vector2(-walkForce, 0));
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            }
            else if (jump == true && stopJump == true && (LHit.distance > 2 || RHit.distance > 2))
            {
                stopJump = false;

                rigidBody.AddForce(-transform.right * 100);

            }
        }

    }
    public void RBDown()
    {
        if (player.isAttachWall)
        {
            ResetMovement();

            animator.SetBool("isRun", false);   // Idle 애니메이션 출력(형준)
        }
        else
        {
            if (jump == false && stopJump == false)
            {
                //transform.Translate(speed, 0, 0);
                rigidBody.AddForce(new Vector2(walkForce, 0));
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            }
            else if (jump == true && stopJump == true && (LHit.distance > 2 || RHit.distance > 2))
            {
                stopJump = false;
                rigidBody.AddForce(transform.right * 100);

            }
        }

    }


    public void JButtonDown()  // 점프 버튼이 눌렸을 떄 실행
    {
        

        if (LBTrigger && jump == false)
        {
            jump = true;
            Vector2 LJ = new Vector2(-1, 3f).normalized;
            rigidBody.AddForce(LJ * jumpForce);

            jumpAni();  // 형준
        }
        else if (RBTrigger && jump == false)
        {
            jump = true;
            Vector2 LJ = new Vector2(1, 3f).normalized;
            rigidBody.AddForce(LJ * jumpForce);

            jumpAni();  // 형준
        }
        else if (!jump)
        {
            
            stopJump = true;
            jump = true;
            rigidBody.AddForce(transform.up * jumpForce);

            jumpAni();  // 형준
        }
    }

    void jumpAni()      // 점프 액션(형준)
    {
        animator.SetBool("isJump", true);

        // SE 중복재생 방지
        if (audioSource.isPlaying == false)
        {
            audioSource.Stop();
            audioSource.clip = playerState.plyaerjump;
            audioSource.Play();
        }
    }

    void ResetMovement()
    {
        jump = false;
        stopJump = false;
    }

    public void Dead()
    {
        LBTrigger = false;
        RBTrigger = false;
    }
}

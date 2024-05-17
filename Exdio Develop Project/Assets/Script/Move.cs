using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector2 currPosition;       //플레이어의 현 위치
    private float speed = 1.5f;           //플레이어의 이동 속도
    public Vector2 Pin;
    Animator animator;
    GameObject pin;
    static public bool isClear = false;               //게임 클리어 여부 판별
    bool Open = false;
    static public int OnSwitch = 0;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        pin = GameObject.FindWithTag("Pin").gameObject; //핀 찾기

        currPosition = transform.position;              //현 위치 파악
        speed = 1.5f;
        Vector2 pinpos;
        pinpos = pin.transform.position;                //핀 위치
        
        if (pinpos.y == currPosition.y)
        {
            animator.SetBool("isClimbing", false);
            animator.SetBool("isFalling", false);
            if (pinpos.x < currPosition.x)
            {
                transform.localScale = new Vector2(-1, 1);
                animator.SetBool("isWalking", true);
            }
            else if (pinpos.x > currPosition.x)
            {
                transform.localScale = new Vector2(1, 1);
                animator.SetBool("isWalking", true);
            }
            else
                animator.SetBool("isWalking", false);
        }
        else if (pinpos.y > currPosition.y)
        {
            speed = 1f;
            animator.SetBool("isClimbing", true);
        }
        else if (pinpos.y < currPosition.y)
        {
            speed = 1f;
            animator.SetBool("isFalling", true);
        }
        if (Open)
            speed = 0.8f;
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(currPosition, pinpos, step);   //핀 위치로 이동

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            isClear = true;
        }
        if (other.gameObject.tag == "Door")
        {
            Open = true;
            animator.SetBool("isOpening", true);
            GameObject child = transform.Find("Player_Sprite").gameObject;
            Vector2 childpos;
            childpos = child.transform.position;
            childpos.y -= 0.07f;
            child.transform.position = childpos;
        }
        if (other.gameObject.tag == "sweetch")
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Door_Switch_On");
            animator.SetInteger("switch_On", + 1);
            OnSwitch += 1;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            Open = false;
            animator.SetBool("isOpening", false);
            GameObject child = transform.Find("Player_Sprite").gameObject;
            Vector2 childpos;
            childpos = child.transform.position;
            childpos.y += 0.07f;
            child.transform.position = childpos;
        }
    }
}

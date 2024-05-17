using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Guard_Move : MonoBehaviour
{
    public SpriteRenderer rend;
    private Vector2 currPosition;
    Animator animator;
    GameObject sight;
    private float speed = 1.25f;
    bool iswalking;

    void Start()
    {
        iswalking = false;
        animator = gameObject.GetComponentInChildren<Animator>();
        sight = transform.Find("guard_sight").gameObject;
    }

    void Update()
    {
        currPosition = transform.position;              //현 위치 파악
        float step = speed * Time.deltaTime;

        if (P_Light_toggle.P_turnoff)
        {
            rend.flipX = false;
            iswalking = true;
            animator.SetBool("isWalking", true);
            transform.position = Vector2.MoveTowards(currPosition, new Vector2(-1.31f, 0.79f), step);
            if (currPosition == new Vector2(-1.31f, 0.79f))
            {
                iswalking = false;
                animator.SetBool("isWalking", false);
            }
        }

        if (P_Light_toggle.P_turnoff == false)
        {
            rend.flipX = true;
            iswalking = true;
            animator.SetBool("isWalking", true);
            transform.position = Vector2.MoveTowards(currPosition, new Vector2(1.45f, 0.79f), step);
            if (currPosition == new Vector2(1.45f, 0.79f))
            {
                iswalking = false;
                animator.SetBool("isWalking", false);
            }
        }

        if (iswalking)
        {
            if (rend.flipX)
            {
                sight.transform.localPosition = new Vector3(6.5f, 0f, 0.3f);
                sight.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
            }
            if (rend.flipX == false)
            {
                sight.transform.localPosition = new Vector3(-6.5f, 0f, 0.3f);
                sight.transform.localScale = new Vector3(-0.75f, 0.75f, 1f);
            }
        }
        else
        {
            if (rend.flipX)
            {
                sight.transform.localPosition = new Vector3(6f, 0f, 0.3f);
                sight.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
            }
            if (rend.flipX == false)
            {
                sight.transform.localPosition = new Vector3(-6f, 0f, 0.3f);
                sight.transform.localScale = new Vector3(-0.75f, 0.75f, 1f);
            }
        }
    }
}

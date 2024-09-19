using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("移動する速さ")] float movePower;
    [SerializeField, Range(1.0f, 2.0f), Tooltip("走った時の移動の倍率")] float dashPercentage = 1f;
    [SerializeField, Tooltip("減衰速度")] float deceleration = 5f;

    Rigidbody2D rb;

    /// <summary> 左や右の移動を検知する(左:-1f, 右:1f) </summary>
    float moveInput = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary> プレイヤーの基本移動の処理 </summary>
    private void Move()
    {
        moveInput = 0f; //初期化

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f; //左
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f; //右
        }

        //移動速度の計算処理
        //左Shiftを押すと、速度倍率(通常速度を1としたときの倍率)を掛ける
        float playerVelocity = moveInput * movePower * (Input.GetKey(KeyCode.LeftShift) ? dashPercentage : 1f);

        //減衰を考えて再計算(現在値, 目標値, 変化量)
        float newVelocityX = Mathf.MoveTowards(rb.velocity.x, playerVelocity, movePower * deceleration * Time.deltaTime);

        //結果を代入
        rb.velocity = new Vector2(newVelocityX, rb.velocity.y);
    }
}

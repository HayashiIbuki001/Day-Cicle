using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("�ړ����鑬��")] float movePower;
    [SerializeField, Range(1.0f, 2.0f), Tooltip("���������̈ړ��̔{��")] float dashPercentage = 1f;
    [SerializeField, Tooltip("�������x")] float deceleration = 5f;

    Rigidbody2D rb;

    /// <summary> ����E�̈ړ������m����(��:-1f, �E:1f) </summary>
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

    /// <summary> �v���C���[�̊�{�ړ��̏��� </summary>
    private void Move()
    {
        moveInput = 0f; //������

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f; //��
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f; //�E
        }

        //�ړ����x�̌v�Z����
        //��Shift�������ƁA���x�{��(�ʏ푬�x��1�Ƃ����Ƃ��̔{��)���|����
        float playerVelocity = moveInput * movePower * (Input.GetKey(KeyCode.LeftShift) ? dashPercentage : 1f);

        //�������l���čČv�Z(���ݒl, �ڕW�l, �ω���)
        float newVelocityX = Mathf.MoveTowards(rb.velocity.x, playerVelocity, movePower * deceleration * Time.deltaTime);

        //���ʂ���
        rb.velocity = new Vector2(newVelocityX, rb.velocity.y);
    }
}

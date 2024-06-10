using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;
    private bool isCanJump;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�Փ˂���");
    }

    private void OnCollisionStay(Collision collision)
    {
        // �Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;

        // 0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾
        Vector3 otherNormal = contacts[0].normal;

        // ������������x�N�g���A������1
        Vector3 upVector = new Vector3(0, 1, 0);

        // ������Ɩ@���̓��ρB2�̃x�N�g���͂Ƃ��ɒ�����1�Ȃ̂ŁAcos���̌��ʂ�dotUN�ϐ��ɓ���
        float dotUN = Vector3.Dot(upVector, otherNormal);

        // ���ϒl�ɋt�O�p�`arccos�������Ċp�x���Z�o�B�����x���@�֕ϊ�����
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

        // 2�̃x�N�g�����Ȃ��p�x��45�x��菬������΃W�����v���̑f�Ƃ���
        if (dotDeg <= 45)
        {

            isCanJump = true;

        }

        //Debug.Log("�ڐG��");

        isCanJump = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("���E����");
        isCanJump = false;
    }

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //    rb.velocity = new Vector3(0, 10, 0);

        //}

        if (Input.GetMouseButtonDown(0))
        {

            clickPosition = Input.mousePosition;

        }

        if (isCanJump && Input.GetMouseButtonUp(0))
        {

            // �N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clickPosition - Input.mousePosition;
            // �N���b�N�ƃ����[�X���������W�Ȃ疳��
            if (dist.sqrMagnitude == 0) { return; }
            // ������W�������AjumpPower���������킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;

        }
        
    }
}

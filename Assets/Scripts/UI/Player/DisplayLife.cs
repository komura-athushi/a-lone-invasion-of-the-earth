using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLife : MonoBehaviour
{
    // ScriptableObject�ɂ���\��

    // UI�p��ScriptableObject���ق���
    // �n�[�g�̊Ԋu
    private float heartPaddingRatio = 1.3f;

    // private float playerHP = DataController.GetGameParam().playerHP; 
    private int playerHP = 5;

    void InitializeDrawLife()
    {
        for (int i = 1; i <= playerHP; i++)
        {
            // �n�[�g�̐���
            var heart = Instantiate((GameObject)Resources.Load("UI_Life"));

            // �n�[�g�Ɏ��ʂ��邽�߂̖���
            heart.name = "heart" + i;

            // Canvas��e�Ƀn�[�g��ݒu
            heart.transform.SetParent(this.transform, false);

            // �n�[�g��i�����炷
            heart.transform.position = new Vector3(heart.transform.position.x + i * heartPaddingRatio, heart.transform.position.y, heart.transform.position.z);
        }
    }

    void DrawLife()
    {
        // �e�X�g�p�ŃL�[���͂��g�p���Ă��܂��B
        if (Input.GetKeyDown("u"))
        {
            // �e�X�g�p��
            playerHP++;

            // �n�[�g�̐���
            var heart = Instantiate((GameObject)Resources.Load("UI_Life"));

            // �n�[�g�Ɏ��ʂ��邽�߂̖���
            heart.name = "heart" + playerHP;

            // Canvas��e�Ƀn�[�g��ݒu
            heart.transform.SetParent(this.transform, false);

            // �n�[�g��i�����炷
            heart.transform.position = new Vector3(heart.transform.position.x + playerHP * heartPaddingRatio, heart.transform.position.y, heart.transform.position.z);
        }

        // �e�X�g�p�ŃL�[���͂��g�p���Ă��܂��B
        if (Input.GetKeyDown("j"))
        {
            // �e�X�g�p�_���[�W
            playerHP--;

            // �n�[�g�����炷
            Destroy(GameObject.Find("heart" + (playerHP + 1)));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // �ŏ��̃n�[�g��`��
        InitializeDrawLife();
    }

    // Update is called once per frame
    // �e�X�g�ł́AFixedUpdate��Update�ɂ��Ă��܂����BFixed���ƃ��X�|���X�������Ȃ邽�߂ł��B
    void FixedUpdate()
    {
        // playerLife����Ƀ`�F�b�N���ăn�[�g�̐����X�V
        DrawLife();
    }
}

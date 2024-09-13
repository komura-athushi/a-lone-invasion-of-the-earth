using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLife : MonoBehaviour
{
    float heartPaddingRatio = 1.3f;
    int playerlife = 5;

    void InitializeDrawLife()
    {
        for (int i = 1; i <= playerlife; i++)
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
        if (Input.GetKeyDown("u"))
        {
            // �e�X�g�p��
            playerlife++;

            // �n�[�g�̐���
            var heart = Instantiate((GameObject)Resources.Load("UI_Life"));

            // �n�[�g�Ɏ��ʂ��邽�߂̖���
            heart.name = "heart" + playerlife;

            // Canvas��e�Ƀn�[�g��ݒu
            heart.transform.SetParent(this.transform, false);

            // �n�[�g��i�����炷
            heart.transform.position = new Vector3(heart.transform.position.x + playerlife * heartPaddingRatio, heart.transform.position.y, heart.transform.position.z);
        }

        if (Input.GetKeyDown("j"))
        {
            // �e�X�g�p�_���[�W
            playerlife--;

            // �n�[�g�����炷
            Destroy(GameObject.Find("heart" + (playerlife + 1)));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // �ŏ��̃n�[�g��`��
        InitializeDrawLife();
    }

    // Update is called once per frame
    // �e�X�g�p��FixedUpdate��Update�ɂ��Ă��܂��BFixed���ƃ��X�|���X�������Ȃ邽�߂ł��B
    void Update()
    {
        // playerLife����Ƀ`�F�b�N���ăn�[�g�̐����X�V
        DrawLife();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleSystem PS;
    //�X�P�[���A�b�v�̌o�ߎ���
    private float ElapedScaleupTime = 0.0f;
    //�X�P�[���A�b�v�̎���
    [SerializeField]
    private float ScaleUupTime = 0.3f;
    //�X�P�[���A�b�v�̃p�����[�^
    [SerializeField]
    private float ScaleParam = 0.5f;
    //�p�[�e�B�N���폜�o�ߎ���
    private float ElapsedDeleteTime = 0.0f;
    //�p�[�e�B�N���̃��C�t����
    [SerializeField]
    private float deleteTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        PS = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

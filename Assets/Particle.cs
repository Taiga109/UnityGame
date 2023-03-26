using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleSystem PS;
    //スケールアップの経過時間
    private float ElapedScaleupTime = 0.0f;
    //スケールアップの時間
    [SerializeField]
    private float ScaleUupTime = 0.3f;
    //スケールアップのパラメータ
    [SerializeField]
    private float ScaleParam = 0.5f;
    //パーティクル削除経過時間
    private float ElapsedDeleteTime = 0.0f;
    //パーティクルのライフ時間
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

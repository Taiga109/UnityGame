using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class EnemyStatus : MonoBehaviour
{   //�G��MaxHP
    [SerializeField]
    private int maxHp = 100;
    //�G�̍U����
    [SerializeField]
  //  private int attackPower = 1;
    private int currentHp;
  
    //�@HP�\���p�X���C�_�[
    public Slider slider;
    public enum EnemyState
    {
        Walk,
        Idol,
        Chase,
        Attack
    };

    // Start is called before the first frame update
    void Start()
    {
        slider.value = (float)maxHp;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.rotation = Camera.main.transform.rotation;
    }
    void OnCollisionEnter(Collision collision)
    {
    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("ontrriger");

        if (other.gameObject.tag == "Player_Attack")
        {
            currentHp -= 50;
            slider.value = (float)currentHp / (float)maxHp;
            if (currentHp == 0)
            {
                Destroy(gameObject, 0f);
            }
        }
    }
}

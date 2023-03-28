using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //public void ChangeScene(string nextScene)
    //{
    //    SceneManager.LoadScene(nextScene);
    //}
    [SerializeField] public string NextScene;
    string NowScene;
    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        NowScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (NowScene != "Main")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                ChangeScene(NextScene);
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }
    }
}

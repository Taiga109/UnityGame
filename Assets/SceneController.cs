using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject fadeCanvas;
   
    [SerializeField] public string NextScene;
    string NowScene;

    public async void ChangeScene(string nextScene)
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();
        await Task.Delay(200);
        SceneManager.LoadScene(nextScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!FadeManager.isFadeInstance)
        {
            Instantiate(fadeCanvas);
        }
        Invoke("findFadeObject", 0.02f);
        NowScene = SceneManager.GetActiveScene().name;
    }
    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
        fadeCanvas.GetComponent<FadeManager>().fadeIn();
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

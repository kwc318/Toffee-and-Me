using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class Video : MonoBehaviour
{
    public float stoptime;
    public VideoPlayer videoPlayer;
    public Animator fade;


    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Darn U Intro Exported 2020-04-17 02.26.34.mp4");
        videoPlayer.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        stoptime -= Time.deltaTime;

        if (stoptime <= 1)
        {
            fade.Play("FadeOut");
        }

        if (stoptime <= 0)
        {
            SceneManager.LoadScene("GameplayScene");
        }
    }
}

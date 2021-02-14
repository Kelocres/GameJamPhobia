using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuJuego : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer video;

    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        StartCoroutine("WaitForMovieEnd");
    }


    public IEnumerator WaitForMovieEnd()
    {
        while (!video.isPrepared || video.isPlaying)
        {
            yield return new WaitForEndOfFrame();

        }
        OnMovieEnded();
    }

    void OnMovieEnded()
    {
        SceneManager.LoadScene("Level1");
    }
}

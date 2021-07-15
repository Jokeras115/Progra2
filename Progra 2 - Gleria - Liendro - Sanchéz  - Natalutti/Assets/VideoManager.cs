using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    VideoPlayer vp;
    bool videoStarted;
    private void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }
    void Update()
    {
        if (vp.isPlaying && !videoStarted)
            videoStarted = true;
        else if (!(vp.isPlaying) && videoStarted)
        {
            vp.gameObject.SetActive(false);
        }
    }
}

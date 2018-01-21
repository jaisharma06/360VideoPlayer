using UnityEngine;
using UnityEngine.Video;
[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    private void Start()
    {
        if (!videoPlayer)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
    }

    private void Update()
    {
        ControlVideo();
    }

    private void ControlVideo()
    {
        if (Input.GetButtonUp(Statics.PLAY_BUTTON))
        {
            HandlePlayBack();
        }
        else if (Input.GetButtonUp(Statics.RESTART_BUTTON))
        {
            videoPlayer.Stop();
            videoPlayer.Play();
        }
    }

    public void HandlePlayBack()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }
}

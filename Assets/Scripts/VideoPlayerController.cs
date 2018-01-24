using UnityEngine;
using UnityEngine.Video;
[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private int minTimeChangeButton = 10;
    [SerializeField]
    private int maxTimeChangeButton = 20;
    [SerializeField]
    private GameObject changeButton;
    [SerializeField]
    private VideoClip m_secondVideoClip;

    private VideoClip initVideoClip;

    private void Start()
    {
        if (!videoPlayer)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        initVideoClip = videoPlayer.clip;
    }

    private void Update()
    {
        ControlVideo();

        if (videoPlayer.time > minTimeChangeButton && videoPlayer.time < maxTimeChangeButton)
        {
            changeButton.SetActive(true);
        }
        else
        {
            changeButton.SetActive(false);
        }
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

    public void ChangeVideo()
    {
        var videoClip = m_secondVideoClip;
        videoPlayer.Stop();
        if (videoPlayer.clip != initVideoClip)
        {

            videoClip = initVideoClip;
            
        }
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }
}

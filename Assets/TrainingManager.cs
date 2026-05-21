using UnityEngine;
using UnityEngine.Video;

public class TrainingManager : MonoBehaviour
{
    [Header("Scene References")]
    public VisionPendulum leftPendulum;
    public VisionPendulum rightPendulum;
    public VideoPlayer leftVideo;
    public VideoPlayer rightVideo;

    [Header("Training Parameters (Millimeters)")]
    [Tooltip("Avstånd mellan ögonen (IPD). Standard ca 60-65 mm.")]
    public float ipdMillimeters = 60f; 
    
    [Tooltip("Hur bred rörelsen ska vara totalt (mm). Originalkodens 'pendlumValue'.")]
    public float pendulumRangeMM = 100f; 
    
    [Tooltip("Tid för en hel cykel (in och ut) i sekunder.")]
    public float cycleDuration = 3.0f;

    [Header("Video Settings")]
    public VideoClip videoFile;

    void Start()
    {
        // Starta sessionen automatiskt
        SetupSession();
    }

    public void SetupSession()
    {
        // 1. Videohantering
        if (videoFile != null)
        {
            leftVideo.source = VideoSource.VideoClip;
            rightVideo.source = VideoSource.VideoClip;

            leftVideo.clip = videoFile;
            rightVideo.clip = videoFile;

            leftVideo.playOnAwake = false;
            rightVideo.playOnAwake = false;

            leftVideo.Prepare();
            rightVideo.Prepare();

            leftVideo.Play();
            rightVideo.Play();
        }

        // 2. Konvertera millimeter till Unity-meter
        float offsetMeters = (ipdMillimeters / 1000.0f) / 2.0f; // Dela på 2 för offset från mitten
        float rangeMeters = pendulumRangeMM / 1000.0f;

        // 3. Konfigurera VÄNSTER Öga
        // I din originalkod startar vänster öga på (Offset) och går +/-
        // Här sätter vi baspositionen till -Offset (vänster om mitten)
        leftPendulum.rangeX = rangeMeters;
        leftPendulum.durationX = cycleDuration;
        leftPendulum.offsetX = -offsetMeters; 
        leftPendulum.enableX = true;
        leftPendulum.invertDirection = false; // Normal sinusvåg

        // 4. Konfigurera HÖGER Öga
        // Basposition +Offset (höger om mitten)
        rightPendulum.rangeX = rangeMeters;
        rightPendulum.durationX = cycleDuration;
        rightPendulum.offsetX = offsetMeters;
        rightPendulum.enableX = true;
        
        // VIKTIGT: Inverterad riktning!
        // När vänster går mot mitten (högerut), går höger mot mitten (vänsterut).
        // Detta skapar Konvergens (skelning) och Divergens (avslappning).
        rightPendulum.invertDirection = true; 

        // 5. Starta
        leftPendulum.Play();
        rightPendulum.Play();
    }

    [ContextMenu("Update Config Now")]
    public void ForceUpdateConfig()
    {
        SetupSession();
    }
}
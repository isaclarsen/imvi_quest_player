using UnityEngine;

public class VisionPendulum : MonoBehaviour
{
    [HideInInspector] public bool enableX = false;
    [HideInInspector] public float rangeX = 0.1f;
    [HideInInspector] public float offsetX = 0.0f;
    [HideInInspector] public float durationX = 2.0f;
    [HideInInspector] public bool invertDirection = false; 

    private Vector3 initialLocalPos;
    private float timer;
    private bool isPlaying = false;

    void Awake()
    {
        initialLocalPos = transform.localPosition;
    }

    public void Play()
    {
        timer = 0f;
        isPlaying = true;
    }

    void Update()
    {
        if (!isPlaying) return;

        timer += Time.deltaTime;

        float currentX = initialLocalPos.x;
        
        if (enableX && durationX > 0)
        {
            float frequency = (2 * Mathf.PI) / durationX;
            float rawSine = Mathf.Sin(timer * frequency);

            if (invertDirection) rawSine = -rawSine;

            // Amplituden är hälften av totala rangen
            float swayAmount = rawSine * (rangeX / 2.0f);
            
            currentX = offsetX + swayAmount;
        }

        transform.localPosition = new Vector3(currentX, initialLocalPos.y, initialLocalPos.z);
    }
}
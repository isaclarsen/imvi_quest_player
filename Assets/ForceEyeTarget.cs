using UnityEngine;

public class ForceEyeTarget : MonoBehaviour
{
    // Välj i listan vilket öga kameran ska tillhöra
    public StereoTargetEyeMask targetEye = StereoTargetEyeMask.Both;

    void Start()
    {
        // Tvinga kameran att bara rendera till det valda ögat
        GetComponent<Camera>().stereoTargetEye = targetEye;
    }
}
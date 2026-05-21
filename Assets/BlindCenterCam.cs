using UnityEngine;

public class BlindCenterCam : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // LateUpdate körs EFTER att OVR har gjort sina inställningar för framen
    void LateUpdate()
    {
        if (cam == null) return;

        // 1. Låt kameran vara "Enabled" så OVR blir nöjd.
        if (!cam.enabled) cam.enabled = true;

        // 2. Gör den blind: Sätt masken till "Nothing"
        cam.cullingMask = 0;

        // 3. Säg åt den att inte rensa skärmen (rita inte över det andra kameror gjort)
        cam.clearFlags = CameraClearFlags.Nothing;

        // 4. (Viktigast för Built-in) Koppla bort den från ögonen
        cam.stereoTargetEye = StereoTargetEyeMask.None;
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class TextGenerator : MonoBehaviour
{
    public Vector3 playerStartPosition;
    public Vector3 playerCurrentPosition;
    public Vector3 virtualObjectPosition;

    public TextMeshProUGUI distanceWalkedText;
    public TextMeshProUGUI distanceToVirtualObjectText;
    public TextMeshProUGUI lookRotationText;
    // Use this for initialization
    private void Start()
    {

    }
    private void Update()
    {
        float distance = Vector3.Distance(playerStartPosition, playerCurrentPosition);
        float distanceToVirtualObject = Vector3.Distance(playerCurrentPosition, virtualObjectPosition);

        distanceWalkedText.SetText(string.Format("Distance From Startup: {0}m", distance));
        distanceToVirtualObjectText.SetText(string.Format("Distance to Virtual Object: {0}m", distanceToVirtualObject));
        
        lookRotationText.SetText(string.Format("Rotation Quaternion: \nx: {0}\ny: {1}\nz: {2}\nw: {3}", 
            GoogleARCore.Frame.Pose.rotation.x,
            GoogleARCore.Frame.Pose.rotation.y,
            GoogleARCore.Frame.Pose.rotation.z,
            GoogleARCore.Frame.Pose.rotation.w));
    }

    public void SetPlayerLocation(bool startLocation, Vector3 location)
    {
        if (startLocation)
        {
            playerStartPosition = location;
        }
        else
        {
            playerCurrentPosition = location;
        }
    }
    public void SetVirtualObjectLocation(Vector3 location)
    {
        virtualObjectPosition = location;
    }
}

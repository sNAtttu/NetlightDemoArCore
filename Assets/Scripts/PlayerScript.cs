using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class PlayerScript : MonoBehaviour
{
    public TextGenerator SceneManager;

    // Use this for initialization
    void Start()
    {
        SceneManager.SetPlayerLocation(true, GoogleARCore.Frame.Pose.position);
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.SetPlayerLocation(false, GoogleARCore.Frame.Pose.position);
    }
}

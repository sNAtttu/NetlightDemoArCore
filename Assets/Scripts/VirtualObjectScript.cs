using GoogleARCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualObjectScript : MonoBehaviour
{
    public TextGenerator SceneManager;

    public Anchor objectAnchor;

    private void Start()
    {
        SceneManager = FindObjectOfType<TextGenerator>();
    }

    private void Update()
    {
        SceneManager.SetVirtualObjectLocation(transform.position);
    }

}
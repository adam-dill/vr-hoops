using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private SteamVR_TrackedObject _trackedObject;
    private SteamVR_Controller.Device _device;


    public SteamVR_Controller.Device controller
    {
        get { return SteamVR_Controller.Input((int)GetComponent<SteamVR_TrackedObject>().index); }
    }

    // Use this for initialization
    void Start () {
        _trackedObject = GetComponent<SteamVR_TrackedObject>();
    }


    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Hand : MonoBehaviour
{
    private GameObject heldObject;
    private Controller controller;

    private Rigidbody simulator;

	// Use this for initialization
	void Start () {
        simulator = new GameObject().AddComponent<Rigidbody>();
        simulator.name = "simulator";
        simulator.transform.parent = transform.parent;

        controller = GetComponent<Controller>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (heldObject)
        {
            simulator.velocity = (transform.position - simulator.position) * 50f;
            if (controller.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject.GetComponent<Rigidbody>().velocity = simulator.velocity;
                heldObject.GetComponent<HeldObject>().parent = null;
                heldObject = null;
            }
        }
        else
        {
            if (controller.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
                foreach (Collider collider in colliders)
                {
                    if (heldObject == null && collider.GetComponent<HeldObject>() && collider.GetComponent<HeldObject>().parent == null)
                    {
                        heldObject = collider.gameObject;
                        heldObject.transform.parent = transform;
                        heldObject.transform.localPosition = Vector3.zero;
                        heldObject.transform.localRotation = Quaternion.identity;
                        heldObject.GetComponent<Rigidbody>().isKinematic = true;
                        heldObject.GetComponent<HeldObject>().parent = controller;
                    }
                }
            }
        }
	}
}

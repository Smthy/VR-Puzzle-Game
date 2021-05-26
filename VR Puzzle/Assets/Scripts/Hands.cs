using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hands : MonoBehaviour
{
    public bool showController = false;
    
    public InputDeviceCharacteristics controllerChar;

    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;

    public GameObject handPrefab, inventory;

    public Transform active, deactive;

    private GameObject spawnedHandModel;


    private GameObject spawned;

    private Animator handAnimator;
    void Start()
    {
        Try();
    }

    void Try()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerChar, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawned = Instantiate(prefab, transform);
            }                                                                                                               //Checking which controller the player is user and will spawn that in, unless the hand prefabs are spawned in.
            else
            {
                Debug.LogError("No controller");
                spawned = Instantiate(controllerPrefabs[1], transform);
            }

            spawnedHandModel = Instantiate(handPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }

    void UpdateAnimator()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {                                                                                       //Generic VR attributes to allow for the hand to follow the users hand motions
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondary))
        {
            if (secondary)
            {
                Debug.Log("B Pressed: " + secondary + "\n");
                inventory.transform.position = active.position;
            }
            if (!secondary)                                                                 //spawns the inventory in, which can hold up to 4 items.
            {
                inventory.transform.position = deactive.position;
            }
        }
    }

    void Update()
    {
        if (!targetDevice.isValid)
        {
            Try();
        }
        else
        {
            if (showController)
            {
                spawned.SetActive(true);
                spawnedHandModel.SetActive(false);
            }
            else
            {
                spawned.SetActive(false);
                spawnedHandModel.SetActive(true);
                UpdateAnimator();
            }
        }        
    }
}

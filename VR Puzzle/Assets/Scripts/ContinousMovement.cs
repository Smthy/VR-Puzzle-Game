using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinousMovement : MonoBehaviour
{
    public float speed = 1;
    public float gravity = -9.81f;
    private float fallingSpeed;
    public XRNode inputSource;
    private XRRig rig;                                                          //uses the VR rig to move the player, character controller over rigidbody due to the stablilty of the movement
    private Vector2 inputAxis;
    private CharacterController character;
    public LayerMask groundLayer;

    public float additionHeight = 0.2f;


    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);               //uses the left hand to move the player around using the joystick
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        CapFollowHeadset();

        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);              //follows the head of player
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);

        //Gravity
        bool isGrounded = CheckIfGrounded();            //checks if the player is on the ground
        if (isGrounded)
        {
            fallingSpeed = 0;
        }
        else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
            character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);            //uses the character move to deal with gravity
            if(fallingSpeed >= 240f)
            {
                fallingSpeed = 240f;                //caps the speed of falling to terminal velocity
            }
        }
        
    }

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;

        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hit, rayLength, groundLayer);         //Uses a sphere to check if the player is on the ground, if so the velocity is turned off

        return hasHit;
    }

    void CapFollowHeadset()
    {
        character.height = rig.cameraInRigSpaceHeight + additionHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);               //it follows the headset, incase the player walks around in the area they are.

        capsuleCenter = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);

    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [System.Serializable]
    public class CameraRig
    {
        public Vector3 CameraOffSet = new Vector3(0, 2,-8);
        public float rotationSpeed = 1;
        public float followSpeed = 5;
    }

    [SerializeField] private bool isCursorLocked;

    [SerializeField] private CameraRig movingStandCamera;

    [SerializeField] private Transform cameraLookTarget;
    [SerializeField] private Player localPlayer;
    private CameraRig cameraRig;

    private void Awake()
    {
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void LateUpdate()
    {
        cameraRig = movingStandCamera;


        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraRig.CameraOffSet.z
                                                     + localPlayer.transform.up * cameraRig.CameraOffSet.y
                                                     + localPlayer.transform.right * cameraRig.CameraOffSet.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraRig.followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, cameraRig.rotationSpeed * Time.deltaTime);
    }
}

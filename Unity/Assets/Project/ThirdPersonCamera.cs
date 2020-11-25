using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [System.Serializable]
    public class CameraRig
    {
        public Vector3 CameraOffSet;
        public float Damping;
    }

    [SerializeField] private CameraRig movingStandCamera;

    [SerializeField] private Transform cameraLookTarget;
    [SerializeField] private Player localPlayer;
    private CameraRig cameraRig;

    private void LateUpdate()
    {

        //Debug.Log("movingStandCamera");
        cameraRig = movingStandCamera;


        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraRig.CameraOffSet.z
                                                     + localPlayer.transform.up * cameraRig.CameraOffSet.y
                                                     + localPlayer.transform.right * cameraRig.CameraOffSet.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraRig.Damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, cameraRig.Damping * Time.deltaTime);
    }
}

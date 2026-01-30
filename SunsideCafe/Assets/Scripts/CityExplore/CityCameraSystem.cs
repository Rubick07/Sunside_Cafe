using UnityEngine;
using Unity.Cinemachine;

public class CityCameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cinemachineCamera;

    private CinemachineConfiner3D cameraConfiner;

    private void Awake()
    {
        cameraConfiner = cinemachineCamera.GetComponent<CinemachineConfiner3D>();
    }

    public void ChangeCameraConfiner(Collider confiner)
    {
        cameraConfiner.BoundingVolume = confiner;
    }


}

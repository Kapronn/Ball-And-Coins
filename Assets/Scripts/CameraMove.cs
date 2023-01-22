using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody playerRigidbody;

    List<Vector3> _velocitySpeedList = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            _velocitySpeedList.Add(Vector3.zero);
        }
    }

    private void FixedUpdate()
    {
        _velocitySpeedList.Add(playerRigidbody.velocity);
        _velocitySpeedList.RemoveAt(0);
    }

    private void Update()
    {
        CameraMover();
    }

    private void CameraMover()
    {
        Vector3 summ = Vector3.zero;
        for (int i = 0; i < _velocitySpeedList.Count; i++)
        {
            summ = _velocitySpeedList[i];
        }

        transform.position = player.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ), Time.deltaTime * 10f);
    }
}
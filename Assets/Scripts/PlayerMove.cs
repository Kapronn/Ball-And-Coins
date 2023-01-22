using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  private Rigidbody _rigidbody;
  [SerializeField] private Transform cameraCenter;
  [SerializeField] private float moveSpeed = 2f;
  private void Start()
  {
    _rigidbody = GetComponent<Rigidbody>();
    _rigidbody.maxAngularVelocity = 500f;
  }

  private void FixedUpdate()
  {
    PlayerControl();
  }

  private void PlayerControl()
  {
    _rigidbody.AddTorque(cameraCenter.right * Input.GetAxis("Vertical") * moveSpeed);
    _rigidbody.AddTorque(-cameraCenter.forward * Input.GetAxis("Horizontal") * moveSpeed);
  }
}

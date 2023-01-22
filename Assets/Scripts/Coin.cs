
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Coin : MonoBehaviour
{
    private void Update()
    {
      transform.Rotate(0,180 * Time.deltaTime,0);
    }
}

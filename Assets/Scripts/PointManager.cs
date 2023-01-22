using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
   [SerializeField] CoinManager coinManager;
   [SerializeField] private Transform player;
   public Coin closetCoin;

   private void Update()
   {
      CoinPointer();
   }

   private void CoinPointer()
   {
      closetCoin = coinManager.GetClosestCoin(transform.position);
      Debug.DrawLine(transform.position, closetCoin.transform.position);
      Vector3 toTarget = closetCoin.transform.position - transform.position;
      Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);
      transform.rotation = Quaternion.LookRotation(toTargetXZ);

      transform.position = new Vector3(player.position.x, 1.5f, player.position.z);
   }
}

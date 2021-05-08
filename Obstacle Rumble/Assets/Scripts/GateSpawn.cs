using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawn : MonoBehaviour
{
   [SerializeField] private GameObject gatePref;
   [SerializeField] private Transform spawnPoint;

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.tag == "PlayerBody" || other.gameObject.tag == "EnemyBody")
      {
         Instantiate(gatePref, spawnPoint.position, spawnPoint.rotation);
      }
   }
}

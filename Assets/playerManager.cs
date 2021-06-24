using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
   public static playerManager instance;

   void Awake(){

           instance = this;

   }

   public GameObject player;
}
using System.Collections;
using System.Collections.Generic;
using Scrips;
using UnityEngine;

public class RedCar : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
   
   public void OnCarExit()
   {
       _gameManager.LockCuror(false);
       transform.Translate(transform.forward);
   }

   public void GameManagerCall()
   {
         _gameManager.OnCarExit();
   }
}

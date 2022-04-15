using System;
using System.Collections;
using System.Collections.Generic;
using Scrips;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;


public class RedCar : MonoBehaviour
{
    public UnityEvent OnCarExitEvent;
    
    private int _distaentToTravel = 10;

    
    private GameManager _gameManager;
    

    public void OnCarExit()
   {
       StartCoroutine(MoveCar(transform.position));
       Debug.Log("Car OnExit");
   }
    

   IEnumerator MoveCar(Vector3 pos)
   {
       while (Vector3.Distance(pos,transform.position) < _distaentToTravel)
       {
           transform.Translate(-transform.right * Time.deltaTime * 5f);
           yield return new WaitForEndOfFrame();
       }
       OnCarExitEvent?.Invoke();
       StopAllCoroutines();
   }

   private void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.tag.Contains("Gride"))
       {
           OnCarExit();
       }
   }
}

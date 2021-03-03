using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActiveOnSomeStates : MonoBehaviour
{
   public GameManager.GameState[] activeStates;
   GameManager gm;

   void Start()
   {
       GameManager.changeStateDelegate += UpdateVisibility;
       gm = GameManager.GetInstance();

        UpdateVisibility();
   }

   void UpdateVisibility()
   {
       if (activeStates.Contains(gm.gameState))
       {
           gameObject.SetActive(true);
       }
       else
       {
           gameObject.SetActive(false);
       }
   }
}
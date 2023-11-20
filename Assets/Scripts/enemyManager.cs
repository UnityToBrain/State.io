using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class enemyManager : MonoBehaviour
{
   public int armyNo,initialAmount;
   public SpriteRenderer conquerTerritoryColor;
   public bool underAttack;
   private void Awake()
   {
      NumberOfSolider();
   }

   private void NumberOfSolider()
   {
      armyNo = Random.Range(10, 25);
      initialAmount = armyNo;
   }

   protected void ConquerTerritory( TextMeshPro labelNo)
   {
      armyNo--;

      labelNo.text = armyNo.ToString();
     
      if (armyNo == 0)
      {
         conquerTerritoryColor.color = PlayerManager.playerManagerInstance.playerColor;
      }

      if (PlayerManager.playerManagerInstance.playerArmyNo == 0 && armyNo > 0)
      {
         StartCoroutine(RefectionّForces());
      }

      if (underAttack)
      {
         StopCoroutine(RefectionّForces());
         underAttack = false;
      }
   }

   IEnumerator RefectionّForces() 
   {
      while (armyNo < initialAmount)
      {
         armyNo++;
         yield return new WaitForSecondsRealtime(0.5f);
      }
     
   }

}



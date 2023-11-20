using TMPro;
using UnityEngine;

public class CountryManager : enemyManager
{
   [SerializeField] private TextMeshPro forceLabel;
   private void Start()
   {
      forceLabel = GetComponentInChildren<TextMeshPro>();
      forceLabel.text = armyNo.ToString();
      conquerTerritoryColor = transform.parent.GetComponent<SpriteRenderer>();
   }


   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         ConquerTerritory(forceLabel);
      }
   }
}

// using System;
// using System.Collections;
// using UnityEngine;
//
// public class Enemy : MonoBehaviour
// {
//     Player _target;
//     
//     public Bullet BulletPrefab;
//     public float SideBulletAngle = 30f;
//     public float FireInterval = .2f;
//
//     void Awake()
//     {
//         _target = FindObjectOfType<Player>();     
//     }
//
//     private void OnEnable()
//     {
//         StartCoroutine(Fire());
//     }
//
//     private IEnumerator Fire()
//     {
//         while(enabled)
//         {
//             Fire(-SideBulletAngle);
//             Fire(0);
//             Fire(SideBulletAngle);
//
//             yield return new WaitForSeconds(FireInterval);
//         }
//     }
//
//     void Fire(float angle)
//     {
//         var bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
//         bullet.Initialize(_target.transform.position, angle);
//     }
// }

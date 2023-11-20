using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class ExampleArmy : MonoBehaviour
{
    [SerializeField] private int _unitWidth = 5;
    [SerializeField] private int _unitDepth = 5;
    [SerializeField] private float _nthOffset = 0;
    [SerializeField] private float Spread;
    [SerializeField] Vector3 pos;
    [SerializeField] private GameObject soldier;
    
    public void EvaluatePoints()
    {
        var middleOffset = new Vector3(_unitWidth * 0.5f, 0, _unitDepth * 0.5f);

        for (var x = 0; x < _unitWidth; x++)
        {
            for (var y = 0; y < _unitDepth; y++)
            {
                
                pos = new Vector3(x + (y % 2 == 0 ? 0 : _nthOffset), y, 0f);

                pos -= middleOffset;

                pos *= Spread;
            }

        }
        
    }

    IEnumerator ss()
    {
        for (int j = 0; j < 10; j++)
        {
            Instantiate(soldier, pos, Quaternion.identity);
            //   soldier.transform.DOMove(soldier.transform.position + new Vector3(x - distance, y - distance, 0), 1f).SetEase(Ease.OutQuad);
            
            yield return new WaitForSecondsRealtime(0.2f);
        }
       
    }

    private void Start()
    {
        StartCoroutine(ss());
    }
}
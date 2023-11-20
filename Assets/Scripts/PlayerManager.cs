using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playerManagerInstance;
    public Color playerColor;
    public int playerArmyNo;
    public bool drag;
    private Vector3 _offset;
    private Camera _camera;
    [SerializeField] private TextMeshPro armyNoTextMeshPro;
    [SerializeField] private Transform StartPos;
    private Transform chosenEnemy;
    private IEnumerator gathertheArmyCorutine;
    [SerializeField] private List<GameObject> bulletList;
    [SerializeField] private float[] angles;
    void Start()
    {
        _camera = Camera.main;
        playerManagerInstance = this;
        armyNoTextMeshPro.text = playerArmyNo.ToString();

        gathertheArmyCorutine = GatherTheArmy();

      //  StartCoroutine(gathertheArmyCorutine);

      // for (int i = 1; i <4; i++)
      // {
      //     bulletList.Add(GameObject.Find("force_" +i ));
      //     bulletList[i-1].SetActive(false);
      // }
        
    }

    IEnumerator GatherTheArmy()
    {
        int army = 0;
        while (army < 20)
        {
            army++;
            playerArmyNo = army;
            armyNoTextMeshPro.text = army.ToString();
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    void Update()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,transform.position.z));

        if (Input.GetMouseButtonDown(0))
        {
            _offset = transform.position - mousePosition;
            drag = true;
        }

        if (drag)
            transform.position = mousePosition + _offset;

        if (Input.GetMouseButtonUp(0))
        {
            drag = false;
            transform.localPosition = Vector3.zero;
            
            if (chosenEnemy != null)
            {
                StopCoroutine(gathertheArmyCorutine);
                StartCoroutine(GenerateSoldier()) ;
            }
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.transform.DOScale( 1.3f, 0.3f).SetEase(Ease.OutBack);
            chosenEnemy = other.transform;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.transform.DOScale(1f, 0.3f).SetEase(Ease.InBack);
            
        }
    }

    public Bullet BulletPrefab;
    public float FireInterval = 0.2f;

    IEnumerator GenerateSoldier()
    {
        var soldierNo = 0;
        while(soldierNo < playerArmyNo)
        {
            for (int i = 0; i < 3; i++)
            {
                var bullet = Instantiate(BulletPrefab, StartPos.position, Quaternion.identity);
                bullet.Initialize(chosenEnemy.transform.position, angles[i],chosenEnemy);  
            }
        
            soldierNo++;
            yield return new WaitForSeconds(FireInterval);
        }
        
    }
    

    //  yield return new WaitForSecondsRealtime(0.01f);
        
    
        //}
        
        //   int x = 0;
        //   float xAxis = 0,yAxis = 0;
        //   float delay = 0f;
        //   var row = playerArmyNo >= 3 ? 4 : 3;
        //   
        // //  Instantiate(soldier, transform.position + new Vector3(x - offset,y + offset, 0f), Quaternion.identity);
        // //  x++;
        //
        // GameObject group = new GameObject("group_1");
        // group.transform.position = transform.position;
        //
        // for (int i = 0; i < row; i++)
        // {
        //   GameObject force =  Instantiate(soldier, transform.position + new Vector3(xAxis - offset,yAxis + offset, 0f), Quaternion.identity);
        //
        //   force.transform.parent = group.transform;
        //   
        //   xAxis+= 0.3f;
        //  while (x < playerArmyNo)
        // {
        //  GameObject plr = 
        //    Instantiate(soldier, transform.position + new Vector3(x - offset,y + offset, 0f), Quaternion.identity);
        //   plr.transform.DOMove(plr.transform.position + new Vector3(x - offset,y + offset, 0f), 1f).SetEase(Ease.OutQuad);

        // plr.transform.DOMove(chosenEnemy.position, 1f).SetDelay(delay).SetEase(Ease.OutQuad);
        //
        // delay += 0.2f;
            
        //   x++;

        // if (x == row && playerArmyNo > 1 && row > 0)
        // {
        //     y += 1f;
        //     x = 0;
        //
        //     playerArmyNo -= row;
        // }
        // yield return new WaitForSecondsRealtime(0.5f);
        //}
       
    }
    

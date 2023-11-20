using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class ArrowGenerator : MonoBehaviour
{
    public float stemLength;
    public float stemWidth;
    public float tipLength;
    public float tipWidth;
 
    [System.NonSerialized]
    public List<Vector3> verticesList;
    [System.NonSerialized]
    public List<int> trianglesList;
 
    Mesh mesh;
    private Camera _camera;

    private Renderer meshRendere;

    void Start()
    {
        _camera = Camera.main;
        //make sure Mesh Renderer has a material
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        meshRendere = GetComponent<Renderer>();

        meshRendere.enabled = false;
    }
 
    void Update()
    {
        if (PlayerManager.playerManagerInstance.drag)
        {
            GenerateArrow();
            
            var dire = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dire.y, dire.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);

            var offset = PlayerManager.playerManagerInstance.transform.position - transform.position;

            stemLength = offset.magnitude;
            meshRendere.enabled = true;
        }
        else
        {
            stemLength = 0f;
            meshRendere.enabled = false;
        }
        
    }
 
    //arrow is generated starting at Vector3.zero
    //arrow is generated facing right, towards radian 0.
    void GenerateArrow()
    {
        //setup
        verticesList = new List<Vector3>();
        trianglesList = new List<int>();
 
        //stem setup
        Vector3 stemOrigin = Vector3.zero;
        float stemHalfWidth = stemWidth/2f;
        //Stem points
        verticesList.Add(stemOrigin+stemHalfWidth*Vector3.down);
        verticesList.Add(stemOrigin+stemHalfWidth*Vector3.up);
        verticesList.Add(verticesList[0]+stemLength*Vector3.right);
        verticesList.Add(verticesList[1]+stemLength*Vector3.right);
 
        //Stem triangles
        trianglesList.Add(0);
        trianglesList.Add(1);
        trianglesList.Add(3);
 
        trianglesList.Add(0);
        trianglesList.Add(3);
        trianglesList.Add(2);
        
        //tip setup
        Vector3 tipOrigin = stemLength*Vector3.right;
        float tipHalfWidth = tipWidth/2;
 
        //tip points
        verticesList.Add(tipOrigin+tipHalfWidth*Vector3.up);
        verticesList.Add(tipOrigin+tipHalfWidth*Vector3.down);
        verticesList.Add(tipOrigin+tipLength*Vector3.right);
 
        //tip triangle
        trianglesList.Add(4);
        trianglesList.Add(6);
        trianglesList.Add(5);
 
        //assign lists to mesh.
        mesh.vertices = verticesList.ToArray();
        mesh.triangles = trianglesList.ToArray();
    }
}
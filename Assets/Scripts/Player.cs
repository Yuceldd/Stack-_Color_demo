using System.Collections;
using UnityEditor.AssetImporters;
using UnityEngine;
 
class Player : MonoBehaviour {
    public Material Red;
    public Material Yellow;
    public Material Green;
    public GameObject tank;
    public GameObject player;
    private enum ColorState {
        Red,
        Green,
        Yellow
    };
    private ColorState currentState=ColorState.Red;
    private float moveSpeed = 5f;
    private void Update()
    {
       var hor = Input.GetAxisRaw("Horizontal");
      
        transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
        if (hor > 0)
        {
            transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
        }
        else if (hor < 0)
        {
            transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            var x = collision.gameObject.GetComponent<ObjControl>();

            if (x.ObjInf.type == Objtype.Collectable)
            {
                if (x.ObjInf.color == ObjColor.Red)
                {
                    if (currentState == ColorState.Red)
                    {
                        collision.transform.SetParent(tank.transform);
                        collision.transform.tag = "Collected";
                        
                        
                    }
                    else if(currentState == ColorState.Green||currentState == ColorState.Yellow )
                    {
                
                        var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                        Destroy(collision.gameObject);
                        Destroy(collectedList[collectedList.Length-1]);
                    }
                    
                }
                else if (x.ObjInf.color == ObjColor.Green)
                {
                    if (currentState == ColorState.Green)
                    {
                        collision.transform.SetParent(tank.transform);
                        collision.transform.tag = "Collected";
                        
                       
                    }
                    else if(currentState == ColorState.Red||currentState == ColorState.Yellow )
                    {
                
                        var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                        Destroy(collision.gameObject);
                        Destroy(collectedList[collectedList.Length-1]);
                    }
                    
                }
                else if (x.ObjInf.color == ObjColor.Yellow)
                {
                    if (currentState == ColorState.Yellow)
                    {
                        collision.transform.SetParent(tank.transform);
                        collision.transform.tag = "Collected";
                        
                       
                    }
                    else if(currentState == ColorState.Red||currentState == ColorState.Green )
                    {
                
                        var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                        Destroy(collision.gameObject);
                        Destroy(collectedList[collectedList.Length-1]);
                    }
                    
                }
                var localPos = collision.transform.localPosition;
                localPos.x = 0;
                var collectedList1 = GameObject.FindGameObjectsWithTag("Collected");
                for (int i = 0; i <= collectedList1.Length; i++)
                {
                    if (i % 4 == 1 )
                    {
                        localPos.z = -0.3f;
                    }
                    else if (i % 4 == 2 )
                    {
                        localPos.z = -0.1f;
                    }
                    else if (i % 4 == 3 )
                    {
                        localPos.z = 0.1f;
                    }
                    else if (i % 4 == 0 )
                    {
                        localPos.z = 0.3f;
                    }
                    int a = (i-1)/4;
              
                    localPos.y = a+1f;
                }
                collision.transform.localPosition = localPos;
                
               
            }

           else if (x.ObjInf.type == Objtype.Evolve)
            {
                if (x.ObjInf.color == ObjColor.Red)
                {
                    Destroy(collision.gameObject);
                    tank.GetComponent<MeshRenderer>().material = Red;
                    player.GetComponent<MeshRenderer>().material = Red;
                    var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                    foreach (var VARIABLE in collectedList)
                    { 
                        VARIABLE.GetComponent<MeshRenderer>().material = Red;
                    }
                    currentState = ColorState.Red;
                }
                else if (x.ObjInf.color == ObjColor.Green)
                {
                    Destroy(collision.gameObject);
                    tank.GetComponent<MeshRenderer>().material = Green;
                    player.GetComponent<MeshRenderer>().material = Green;
                    var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                    foreach (var VARIABLE in collectedList)
                    {
                        VARIABLE.GetComponent<MeshRenderer>().material = Green;
                    }
                    currentState = ColorState.Green;
                }
                else if (x.ObjInf.color==ObjColor.Yellow)
                {
                    Destroy(collision.gameObject);
                    tank.GetComponent<MeshRenderer>().material = Yellow;
                    player.GetComponent<MeshRenderer>().material = Yellow;
                    var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                    foreach (var VARIABLE in collectedList)
                    {
                        VARIABLE.GetComponent<MeshRenderer>().material = Yellow;
                    }
                    currentState = ColorState.Yellow;
                }
                
            }
            
            
        }
        
    }
    
    
    

}
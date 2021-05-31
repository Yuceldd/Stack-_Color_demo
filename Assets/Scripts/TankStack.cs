using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class TankStack : MonoBehaviour
{
    public Material RedEvolve;
    public Material YellowEvolve;
    public Material GreenEvolve;
    public GameObject tank;
    public GameObject player;
    
    private enum ColorState {
        Red,
        Green,
        Yellow
    };

    private ColorState currentState=ColorState.Red;
    void OnCollisionEnter(Collision collision)
    {
        if (currentState == ColorState.Red)
        {
            
        }
       else if (currentState == ColorState.Green)
        {
            
        }
        else if (currentState == ColorState.Yellow)
        {
            
        }
        if (collision.gameObject.tag == "CollectableRed")
        {
            if (currentState == ColorState.Red)
            {
                collision.transform.SetParent(tank.transform);
                collision.transform.tag = "Collected";
                var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                var localPos = collision.transform.localPosition;
                localPos.x = 0;

                for (int i = 0; i <= collectedList.Length; i++)
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
                    int x = (i-1)/4;
              
                    localPos.y = x+1f;
                }
                collision.transform.localPosition = localPos;
            }
            else if(currentState == ColorState.Green||currentState == ColorState.Yellow )
            {
                
                            var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                            Destroy(collision.gameObject);
                            Destroy(collectedList[collectedList.Length-1]);
            }
            
           
        }
        if (collision.gameObject.tag == "CollectableGreen")
        {
            if (currentState == ColorState.Green)
            {
                collision.transform.SetParent(tank.transform);
                collision.transform.tag = "Collected";
                var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                var localPos = collision.transform.localPosition;
                localPos.x = 0;

                for (int i = 0; i <= collectedList.Length; i++)
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
                    int x = (i-1)/4;
              
                    localPos.y = x+1f;
                }
                collision.transform.localPosition = localPos;
            }
            else if(currentState == ColorState.Red||currentState == ColorState.Yellow )
            {
                
                var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                Destroy(collision.gameObject);
                Destroy(collectedList[collectedList.Length-1]);
            }
            
           
        }
        if (collision.gameObject.tag == "CollectableYellow")
        {
            if (currentState == ColorState.Yellow)
            {
                collision.transform.SetParent(tank.transform);
                collision.transform.tag = "Collected";
                var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                var localPos = collision.transform.localPosition;
                localPos.x = 0;

                for (int i = 0; i <= collectedList.Length; i++)
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
                    int x = (i-1)/4;
              
                    localPos.y = x+1f;
                }
                collision.transform.localPosition = localPos;
            }
            else if(currentState == ColorState.Green||currentState == ColorState.Red )
            {
                
                var collectedList = GameObject.FindGameObjectsWithTag("Collected");
                Destroy(collision.gameObject);
                Destroy(collectedList[collectedList.Length-1]);
            }
            
           
        }
        
        if (collision.gameObject.tag == "Collectable")
        {
            collision.transform.SetParent(tank.transform);
            collision.transform.tag = "Collected";
            var collectedList = GameObject.FindGameObjectsWithTag("Collected");
            var localPos = collision.transform.localPosition;
            localPos.x = 0;

            for (int i = 0; i <= collectedList.Length; i++)
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
                int x = (i-1)/4;
              
                localPos.y = x+1f;
            }
            collision.transform.localPosition = localPos;

        }
       
        if (collision.gameObject.tag == "EvolveRed")
        {
            Destroy(collision.gameObject);
            tank.GetComponent<MeshRenderer>().material = RedEvolve;
            player.GetComponent<MeshRenderer>().material = RedEvolve;
            var collectedList = GameObject.FindGameObjectsWithTag("Collected");
            foreach (var VARIABLE in collectedList)
            {
                VARIABLE.GetComponent<MeshRenderer>().material = RedEvolve;
            }
            currentState = ColorState.Red;

        }
        if (collision.gameObject.tag == "EvolveGreen")
        {
            Destroy(collision.gameObject);
            tank.GetComponent<MeshRenderer>().material = GreenEvolve;
            player.GetComponent<MeshRenderer>().material = GreenEvolve;
            var collectedList = GameObject.FindGameObjectsWithTag("Collected");
            foreach (var VARIABLE in collectedList)
            {
                VARIABLE.GetComponent<MeshRenderer>().material = GreenEvolve;
            }
            currentState = ColorState.Green;
        }
        if (collision.gameObject.tag == "EvolveYellow")
        {
            Destroy(collision.gameObject);
            tank.GetComponent<MeshRenderer>().material = YellowEvolve;
            player.GetComponent<MeshRenderer>().material = YellowEvolve;
            var collectedList = GameObject.FindGameObjectsWithTag("Collected");
            foreach (var VARIABLE in collectedList)
            {
                VARIABLE.GetComponent<MeshRenderer>().material = YellowEvolve;
            }
            currentState = ColorState.Yellow;
        }
    }
}

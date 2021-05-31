using System.Collections;
using UnityEditor.AssetImporters;
using UnityEngine;
 
class Player : MonoBehaviour {
    private float moveSpeed = 5f;
    private float gridSize = 1f;
    private int numberOfColectable = 0;
    private enum Orientation {
        Horizontal,
        Vertical
    };
    private Orientation gridOrientation = Orientation.Horizontal;
    private bool allowDiagonals = false;
    private bool correctDiagonalSpeed = true;
    private Vector2 input;
    private bool isMoving = false;
    private bool final=true;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 v;
    private float t;
    public GameObject player;
    
    private float factor;
 
    public void Update() {
        if (final)
        {
            v = new Vector3(0, 0, 0);

            transform.position += v * Time.deltaTime;
            transform.rotation = Quaternion.identity;
            if (!isMoving)
            {
                input = new Vector2(Input.GetAxis("Horizontal"), 0);
                if (!allowDiagonals)
                {
                    transform.position += transform.forward * Time.deltaTime*5 ;
                    if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                    {
                        input.y = 0;
                    }
                    else
                    {
                        input.x = 0;
                    }
                }

                if (input != Vector2.zero)
                {
                    StartCoroutine(move(transform));
                }
            }
        }
    }
    public IEnumerator move(Transform transform) {
        isMoving = true;
        startPosition = transform.position;
        t = 0;
 
        if(gridOrientation == Orientation.Horizontal) {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z+0.5f + System.Math.Sign(input.y) * gridSize);
        } else {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
        }
 
        if(allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
            factor = 0.7071f;
        } else {
            factor = 1f;
        }
 
        while (t < 1f) {
            t += Time.deltaTime * (moveSpeed/gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
 
        isMoving = false;
        yield return 0;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Objtype {
       Collectable,
       Evolve
     
    };

    public enum ObjColor
    {
        Red,
        Green,
        Yellow
    }
    [System.Serializable]
    public struct ObjInfo
    {
        public Objtype type;
        public ObjColor color;
    }

public class ObjControl : MonoBehaviour
{
    [SerializeField] private ObjInfo stackedObjInfo;
    public ObjInfo ObjInf
    {
        get => stackedObjInfo;set=>stackedObjInfo = value;
    }
}

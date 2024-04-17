using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    protected void DestroyObject(GameObject go)
    {
        Destroy(go);
    }
}

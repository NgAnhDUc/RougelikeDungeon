using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy",menuName = "EnemyStatusSO")]
public class EnemyStatusSO : ScriptableObject
{
    [SerializeField] public float heath = 10f;
    [SerializeField] public float strength = 10f;
    [SerializeField] public float speed = 10f;
}

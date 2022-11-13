using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "ScriptableObjects/Monster")]
public class MonsterSO : ScriptableObject
{
    [SerializeField] private string monsterName;
    [SerializeField] private GameObject monsterPrefab;

    [SerializeField] private uint baseMaxHP;
    [SerializeField] private uint baseMaxMP;


    [SerializeField] private uint baseAttack;
    [SerializeField] private uint baseDefense;
    [SerializeField] private uint baseMagic;
    [SerializeField] private uint baseResistance;
    [SerializeField] private uint baseSpeed;

    [SerializeField] private Sprite barIcon;
}

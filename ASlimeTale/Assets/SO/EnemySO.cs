using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] private string enemyName;

    [SerializeField] private uint baseMaxHP;
    [SerializeField] private uint baseMaxMP;


    [SerializeField] private uint baseAttack;
    [SerializeField] private uint baseDefense;
    [SerializeField] private uint baseMagic;
    [SerializeField] private uint baseResistance;
    [SerializeField] private uint baseSpeed;

    public enum Weakness
    {
        PHYSICAL,
        FIRE,
        WATER,
        ICE,
        ELECTRIC,
        HOLY,
        DARK,
        GROUND,
        PLANT
    }

    [SerializeField] private Weakness weakness;
}

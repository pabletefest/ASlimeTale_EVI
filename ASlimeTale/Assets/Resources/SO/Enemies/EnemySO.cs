using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public GameObject enemyPrefab;

    public uint baseMaxHP;
    public uint baseMaxMP;


    public uint baseAttack;
    public uint baseDefense;
    public uint baseMagic;
    public uint baseResistance;
    public uint baseSpeed;

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
        WIND,
        PLANT
    }

    public Weakness weakness;
}

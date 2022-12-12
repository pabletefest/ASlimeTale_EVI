using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "ScriptableObjects/Monster")]
public class MonsterSO : ScriptableObject
{
    public string monsterName;
    public GameObject monsterPrefab;

    public uint baseMaxHP;
    public uint baseMaxMP;


    public uint baseAttack;
    public uint baseDefense;
    public uint baseMagic;
    public uint baseResistance;
    public uint baseSpeed;

    public Sprite barIcon;

    public SkillSO baseSkill;
    public List<SkillSO> learnableSkills;
}

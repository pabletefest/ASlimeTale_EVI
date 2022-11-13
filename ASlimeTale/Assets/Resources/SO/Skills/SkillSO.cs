using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill")]
public class SkillSO : ScriptableObject
{
    public string skillName;
    public uint power;
    public uint precision;
    public uint mpCost;
    
    public enum Effect
    {
        NONE,
        BURN,
        FREEZE,
        POISON,
        STUN,
        CRITICAL,
        BLIND,
        DEATH,
        CERTAIN
    }

    public enum Type
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

    public Type type;
    public Effect sideEffect;
    public float effectChance;
}

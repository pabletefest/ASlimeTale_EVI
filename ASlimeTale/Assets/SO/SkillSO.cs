using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill")]
public class SkillSO : ScriptableObject
{
    [SerializeField] private string skillName;

    [SerializeField] private uint power;
    [SerializeField] private uint precision;
    [SerializeField] private uint mpCost;
    
    public enum Effect
    {
        BURN,
        FREEZE,
        POISON,
        STUN,
        CRITICAL,
        BLIND,
        ONESHOT
    }

    [SerializeField] private Effect sideEffect;
    [SerializeField] private float effectChance;
}

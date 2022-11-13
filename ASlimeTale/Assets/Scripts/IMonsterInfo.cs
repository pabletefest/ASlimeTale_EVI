using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMonsterInfo
{
    public uint level { get; set; }
    public uint currentHP { get; set; }
    public uint currentMP { get; set; }
    public uint currentExp { get; set; }

    public Dictionary<string, SkillData> skills { get; set; }

    public abstract uint getMaxHP();
    public abstract uint getMaxMP();


    public abstract uint getAttack();
    public abstract uint getDefense();
    public abstract uint getMagic();
    public abstract uint getResistance();
    public abstract uint getSpeed();
}
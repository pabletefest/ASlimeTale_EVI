using UnityEngine;
using static SkillSO;

public class SkillData
{
    public string skillName;

    public uint power;
    public uint precision;
    public uint mpCost;

    public Type type;
    public Effect sideEffect;
    public float effectChance;
    public GameObject vfx;
    public CastZone castZone;

    public SkillData(SkillSO skillSO)
    {
        skillName = skillSO.skillName;
        power = skillSO.power;
        precision = skillSO.precision;
        mpCost = skillSO.mpCost;
        type = skillSO.type;
        sideEffect = skillSO.sideEffect;
        effectChance = skillSO.effectChance;
        vfx = skillSO.vfx;
        castZone = skillSO.castZone;
    }
}

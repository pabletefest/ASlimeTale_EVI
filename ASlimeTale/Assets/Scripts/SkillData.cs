using static SkillSO;

public struct SkillData
{
    public string skillName;

    public uint power;
    public uint precision;
    public uint mpCost;

    public Type type;
    public Effect sideEffect;
    public float effectChance;

    public SkillData(SkillSO skillSO)
    {
        skillName = skillSO.skillName;
        power = skillSO.power;
        precision = skillSO.precision;
        mpCost = skillSO.mpCost;
        type = skillSO.type;
        sideEffect = skillSO.sideEffect;
        effectChance = skillSO.effectChance;
    }
}

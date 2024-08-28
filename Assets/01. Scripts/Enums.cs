public enum BulletType
{
    Avoid,//피해야 하는 종류
    Stop,//이동을 하지 않는 동안 피해를 입지 않는 종류
    Parry//패리 가능한 종류
}

public enum SpawnType
{
    Once,//한번 스폰하고 끝나는 종류
    Continuous,// 쿨타임마다 지속적으로 스폰하는 종류
}

public enum SpawnParentType
{
    EnemyAsParent,
    WorldPosition
}

public enum ItemType
{
    Gun,
    Sword,
    Shield,
    Boomerang,
    Thunder,
    AttackDamage,
    AttackCoolTime,
    AttackAmount
}
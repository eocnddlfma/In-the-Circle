Enemy 오브젝트 구조
EnemyPrefab
ㄴ pivot - EnemyMove
  ㄴ Enemy - Collider, SpawnAttack, EnemyInfoSO(미구현)
    ㄴ HP(없음)

적 공격 구조
Enemy - SpawnAttack(생성 횟수와 갯수를 담당함)가 Instantiate
->
BulletPrefab - Pattern(이동만 담당함)



구현되어야 할 목록
레벨, 레벨업에 따른 강화

적 info so
적 스크립트

체력 스크립트


Fmod와 레벨에 따른 배경음악 변화

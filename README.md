# SkillSystem - 유니티에서 스킬 효과를 구현한 Sample Project

## 스킬 테이블 설명
스킬 테이블은 스킬의 발동 대상과 대상과위 범위등을 정의 하는 테이블입니다.   

skillNo : 스킬의 No   
skillName : 스킬의 이름   
target : 스킬의 발동을 위한 대상   
attackRange : 스킬의 발동을 위한 대상과의 거리   

![Image](https://github.com/user-attachments/assets/bda8e240-53b5-4dd5-9b89-dc59aaa6a6d4)   

<br/><br/>

## 스킬 효과 테이블 설명
스킬 효과 테이블은 스킬이 발동되었을때 발생하는 효과를 정의 하는 테이블입니다.   
같은 skillNo로 작성하면 작성되어있는 순서대로 효과가 순차적으로 발생합니다.

skillNo : 스킬의 No   
effectType : 스킬의 효과 타입   
target : 스킬 효과의 대상   
value : 스킬 효과를 발동시킬때 사용하는 값   

![Image](https://github.com/user-attachments/assets/387eb6cc-a716-4578-a52f-d0c5c5d432ff)

<br/><br/>
   
## 스킬 동작 플로우
![Image](https://github.com/user-attachments/assets/472a2d74-e673-4ca4-85c6-fe2888985a62)

<br/><br/>

## 스킬 API 구현
SkillAPI를 partial class로 만들어 스킬 효과의 종류에 따라 나누어 관리 하기 편하도록 구현하였습니다.


```c#
public static partial class SkillEffectAPI
{
    public static void Damage(Unit caster, Unit target, int damage)
    {
        if(caster == target)
            target.Damage(damage, false);
        else
            target.Damage(damage);
    }
}
```
```C#
public static partial class SkillEffectAPI
{
    public static void RecoveryHP(Unit caster, Unit target, int damage)
    {
        target.RecoveryHp(damage);
    }
}
```

위의 partial calss로 나누어져 구현되어있는 스킬 API들을 호출 시키는 부분 입니다.
```c#
public static partial class SkillEffectAPI
{
    public static void CallSkillAPI(SkillEffectData skillEffectData, Unit caster, Unit target)
    {
        Unit skillTarget = null;

        switch (skillEffectData.target)
        {
            case SkillEffectTarget.Caster:
                skillTarget = caster;
                break;

            case SkillEffectTarget.Enemy:
                skillTarget = target;
                break;
        }

        switch (skillEffectData.effectType)
        {
            case SkillEffectType.Damage:
                Damage(caster, skillTarget, skillEffectData.value);
                break;

            case SkillEffectType.RecoveryHP:
                RecoveryHP(caster, skillTarget, skillEffectData.value);
                break;
        }
    }
}
```

<br/><br/>

## 스킬 - 일반 공격 - 커맨드 A 
거리 1의 범위에 있는 적에게 데미지 1을 입힙니다.

![Image](https://github.com/user-attachments/assets/e129a603-2174-4c59-8189-5f13d0914ef1)

![Image](https://github.com/user-attachments/assets/5592f588-f2b4-4f62-8208-cb0b6e3eeeb0)

![Image](https://github.com/user-attachments/assets/2a89e09f-dd0b-4318-8b4a-b3a889f8a0fc)

<br/><br/>

## 스킬 - 흡혈의 낫 - 커맨드 S
거리 1의 범위에 있는 적에게 데미지 10을 입히고 스킬 시전자가 체력을 10 회복한다.

![Image](https://github.com/user-attachments/assets/353bb76d-da84-4aaa-89c5-3b1f7f1c0922)

![Image](https://github.com/user-attachments/assets/13b125e7-df5f-40f6-99ab-f90acb03e702)

![Image](https://github.com/user-attachments/assets/e0f6e07f-90da-4bd8-a161-e859ca047613)

<br/><br/>

## 스킬 - 사신의 낫 - 커맨드 D
거리 3의 버위에 있는 적에게 데미지 10을 입히고 스킬 시전자가 5의 피해를 입습니다.

![Image](https://github.com/user-attachments/assets/f89fc5e6-bea2-4559-8040-7389f2d2f783)

![Image](https://github.com/user-attachments/assets/4c7956ab-b42f-42e5-9be3-addd03eed16a)

![Image](https://github.com/user-attachments/assets/0fb9b593-4c0b-4838-ab1d-fdbd24768f80)


using System;
using System.Collections.Generic;

public class MonsterStateMachine : StateMachine
{
    public Monster monster { get; }

    private Dictionary<Type, MonsterBaseState> states;

    public MonsterStateMachine(Monster monster)
    {
        this.monster = monster;

        states = new Dictionary<Type, MonsterBaseState>()
        {
            {typeof(MonsterIdleState), new MonsterIdleState(monster.monsterController)},
            {typeof(MonsterWalkState), new MonsterWalkState(monster.monsterController)},
            {typeof(MonsterDeathState), new MonsterDeathState(monster.monsterController)},
        };
    }

    public MonsterBaseState ChangeState<T>() where T : MonsterBaseState
    {
        if (states.TryGetValue(typeof(T), out var state))
        {
            ChangeState(state);
            return state;
        }

        return null;
    }
}

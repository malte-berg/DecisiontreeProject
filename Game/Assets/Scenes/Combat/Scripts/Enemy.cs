using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : GameCharacter {

    static readonly ConcurrentQueue<Action> _mainThreadActions = new ConcurrentQueue<Action>();

    public override void Init() {

        equipment = gameObject.GetComponent<Equipment>();
        skills[0] = new Punch(this);

        SetSprite("Enemy");
        
    }

    void FixedUpdate(){ // kinda unnecessary updates

        while(_mainThreadActions.TryDequeue(out var action))
            action?.Invoke();
        
    }

    public async Task AI(Combat c, GameCharacter target){

        Thread.Sleep(1000);

        int currentS = 2;
        while(!SelectSkill(currentS-- % 3));

        // run on main thread (needed for component access)
        _mainThreadActions.Enqueue(() => {
            c.UseTurnOn(target);
        });

    }

}

using System.Collections;
using UnityEngine;

public class Intro : SceneScript {

    public override IEnumerable RunAnimation() {

        int frames = 125;

        while(frames-- > 0){
            
            print("Animation frame");
            yield return new WaitForSeconds(1/60);

        }
    }

}
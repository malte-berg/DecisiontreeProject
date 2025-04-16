using System.Collections;
using UnityEngine;

public class Intro : SceneScript {

    public override IEnumerator RunAnimation() {

        int frames = 120; // 2 seconds

        while(frames-- > 0){
            
            yield return new WaitForSeconds(1/60);

        }
    }

}
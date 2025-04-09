using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour
{
    private Transform spriteContainer;
    private Transform abilityContainer;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> spriteList;

    private Dictionary<string, List<Sprite>> animations = new Dictionary<string, List<Sprite>>();
    private Dictionary<string, SpriteRenderer> spriteLayers = new Dictionary<string, SpriteRenderer>();

    /**
    *   Awake sets the 4 different renderers in a dictionary
    *   Also assign trasnformer objects, one for the character and
    *   one for ability animation
    */
    void Awake()
    {
        // add renderer of ability layer to dictionary
        abilityContainer = transform.GetChild(1);
        SpriteRenderer sr = abilityContainer.GetComponent<SpriteRenderer>();
        spriteLayers.Add("Ability", sr);

        // add renderer of character/armor/weapon layer to dictionary
        spriteContainer = transform.GetChild(0);
        if (spriteContainer != null) {
            // get all the child objects in the sprite container
            foreach (Transform child in spriteContainer) {
                sr = child.GetComponent<SpriteRenderer>();
                if (sr != null) {
                    spriteLayers.Add(child.name, sr);
                }
            }
        } else {
            Debug.LogError("SpriteContainer not found!");
        }

        animations["Player"] = new List<Sprite> {spriteList[0], spriteList[1]};
        animations["Enemy"] = new List<Sprite> {spriteList[2], spriteList[3]};
        animations["Punch"] = new List<Sprite> {spriteList[4], spriteList[5], spriteList[6], spriteList[7]};

    }

    public void SetCharacter(string type) {
        if(animations.ContainsKey(type)) {
            SetSprite(animations[type][0], spriteLayers["Character"]) ;
        } else {
            Debug.LogError("Could not find sprite");
        }
    }

    private void SetSprite(Sprite sprite, SpriteRenderer sr) {
        sr.sprite = sprite;
    }

    // invoke a number of SetSprites after delays
    private void RollSprites(List<Sprite> sprites, SpriteRenderer sr, float delay){
        int l = sprites.Count;
        for(int i = 1; i <= l; i++){
            int frameIndex = i;
            DelayedAction(() => SetSprite(sprites[frameIndex % l], sr), delay * frameIndex - delay);
        }
    }

    //new attack animation
    public void AttackAnimation(string type, GameCharacter thisCharacter) {
        string characterType;
        if(thisCharacter is Player){
            characterType = "Player";
        }else if(thisCharacter is Enemy){
            characterType = "Enemy";
        }else{
            characterType = "Player"; // default option
        }
        RollSprites(animations[characterType], spriteLayers["Character"], 0.2f);
    }

    public void PunchAnimation(GameCharacter target) {
        Transform pos = spriteLayers["Ability"].gameObject.transform;
        Vector3 toTarget = target.gameObject.transform.position - pos.position;
        Vector3 x = toTarget * 0.92f;
        pos.position = pos.position + x;

        RollSprites(animations["Punch"], spriteLayers["Ability"], 0.1f);
    }

    // methods for running a certain function after a delay
    // with: "DelayedAction(() => FunctionToRunAfterDelay(Args), 2f);"
    private void DelayedAction(System.Action action, float delay) {
        StartCoroutine(RunAfterDelay(action, delay));
    }
    
    //run action (the passed function) after a delay
    IEnumerator RunAfterDelay(System.Action action, float delay) {
        yield return new WaitForSeconds(delay);
        action();
    }
}
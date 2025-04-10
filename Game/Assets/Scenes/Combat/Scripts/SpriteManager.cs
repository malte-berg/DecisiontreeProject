using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SpriteManager : MonoBehaviour
{
    private Transform spriteContainer;
    private Transform abilityContainer;
    public SpriteRenderer spriteRenderer;
    private Dictionary<string, SpriteRenderer> spriteLayers = new Dictionary<string, SpriteRenderer>();

    /**
    *   Awake sets the different renderers in a dictionary
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
    }

    public void SetCharacter(GameCharacter thisCharacter) {
        SetSprite(thisCharacter.sprites[0], spriteLayers["Character"]) ;
        Equipment equipment = thisCharacter.equipment;
        if(equipment != null) {
            if(equipment.head != null) {
                if(equipment.head.sprite != null)
                    SetSprite(equipment.head.sprite, spriteLayers["Head"]); 
            }
            if(equipment.weaponLeft != null) {
                if(equipment.weaponLeft.sprites != null)
                    SetSprite(equipment.weaponLeft.sprites[0], spriteLayers["Weapon"]); 
            }
        }
        if(!(thisCharacter is Player)){
            Debug.Log("an enemy!");
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // continue this pattern when we have more item sprites
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
        string characterType = thisCharacter.GetType().Name;
        Equipment equipment = thisCharacter.equipment;
        if(equipment.weaponLeft != null) {
            RollSprites(thisCharacter.sprites, spriteLayers["Character"], 0.2f);
            if(equipment.weaponLeft.sprites != null)
                RollSprites(equipment.weaponLeft.sprites, spriteLayers["Weapon"], 0.2f); // use only stick for now
        }
    }

    public void AbilityAnimation(GameCharacter target, GameCharacter sender, int selectedSkill, int frames) {
        
        Transform pos = spriteLayers["Ability"].gameObject.transform;
        pos.position = sender.originalPos + new Vector3(0f, 0f, 1f);
        Vector3 toTarget = target.gameObject.transform.position - pos.position;

        Sprite sprite = sender.skills[selectedSkill].sprites[0];

        if(sprite != null) {
            Debug.Log("An ability animation should happen");
            pos.GetComponent<SpriteRenderer>().enabled = false;
            pos.GetComponent<SpriteRenderer>().sprite = sprite;

            
            SetPosOfAnimation(pos, toTarget, 0.9f); 
            RollScales(pos, frames, 0.25f);
        }
    }

    private void SetPosOfAnimation(Transform tr, Vector3 toTarget, float scalar){
        tr.position = toTarget * scalar;
    }
    private void RollScales(Transform tr, int frames, float delay) {
        float scale = frames;
        for(int i = 0; i <= frames; i++){
            int frameIndex = i;
            float newScale = ((scale-i) / frames) * 3;
            DelayedAction(() => SetScale(tr, newScale), frameIndex * (delay/frames));
        }   
    }

    private void SetScale(Transform tr, float scale) {
        if(scale <= 0) {
            tr.GetComponent<SpriteRenderer>().enabled = false;
        }else {
            if(!tr.GetComponent<SpriteRenderer>().enabled) 
                tr.GetComponent<SpriteRenderer>().enabled = true;
            tr.localScale = new Vector3(scale, scale, scale);
            Debug.Log("changed scale to: " + scale);
        }
    }

    private void LungeTo(GameCharacter thisCharacter, Vector3 toTarget) {
        
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
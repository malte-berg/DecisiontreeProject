using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour
{
    private Transform spriteContainer;
    private Transform abilityContainer;

    public SpriteRenderer spriteRenderer;
    public List<List<Sprite>> allSprites;
    public List<Sprite> characterSprites;
    public List<Sprite> clothingSprites;
    public List<Sprite> weaponSprites;
    public List<Sprite> abilitySprites;

    private Dictionary<string, Dictionary<string, List<Sprite>>> animations = new Dictionary<string, Dictionary<string, List<Sprite>>>();

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

        animations["GameCharacter"] = new Dictionary<string, List<Sprite>>();
        animations["GameCharacter"]["Player"] = new List<Sprite> {characterSprites[0], characterSprites[1]};
        animations["GameCharacter"]["Enemy"] = new List<Sprite> {characterSprites[2], characterSprites[3]};

        animations["Weapon"] = new Dictionary<string, List<Sprite>>();
        animations["Weapon"]["Stick"] = new List<Sprite> {weaponSprites[0], weaponSprites[1]};
    
        animations["Head"] = new Dictionary<string, List<Sprite>>();
        animations["Head"]["Bucket"] = new List<Sprite> {clothingSprites[0]};

        animations["Torso"] = new Dictionary<string, List<Sprite>>();

        animations["Boots"] = new Dictionary<string, List<Sprite>>();

        animations["Ability"] = new Dictionary<string, List<Sprite>>();
        animations["Ability"]["Punch"] = new List<Sprite> {abilitySprites[0], abilitySprites[1], abilitySprites[2], abilitySprites[3]};

    }

    public void SetCharacter(string type, GameCharacter thisCharacter) {
        SetSprite(animations["GameCharacter"][type][0], spriteLayers["Character"]) ;
        Equipment equipment = thisCharacter.equipment;
        if(equipment != null) {
            if(equipment.head != null) {
                SetSprite(animations["Head"]["Bucket"][0], spriteLayers["Head"]);
            }
            if(equipment.weaponLeft != null) {
                SetSprite(animations["Weapon"]["Stick"][0], spriteLayers["Weapon"]);
            }
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
            RollSprites(animations["GameCharacter"][characterType], spriteLayers["Character"], 0.2f);
            RollSprites(animations["Weapon"]["Stick"], spriteLayers["Weapon"], 0.2f); // use only stick for now
        }
    }

    public void PunchAnimation(GameCharacter target, GameCharacter sender) {
        
        Transform pos = spriteLayers["Ability"].gameObject.transform;
        pos.position = sender.originalPos;
        Vector3 toTarget = target.gameObject.transform.position - pos.position;
        Vector3 x = toTarget * 0.92f;
        pos.position = pos.position + x;

        RollSprites(animations["Ability"]["Punch"], spriteLayers["Ability"], 0.1f);
    }

    private void LungeTo(GameCharacter thisCharacter, Vector3 target) {

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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;
using Unity.VisualScripting;

public class SpriteManager : MonoBehaviour
{
    private Transform spriteContainer;
    private Transform abilityContainer;
    public SpriteRenderer spriteRenderer;
    private Dictionary<string, SpriteRenderer> spriteLayers = new Dictionary<string, SpriteRenderer>();

    private readonly float ATTACK_TIME = 0.35f; 
    private readonly float DINSTANCE_TO_LUNGE = 0.7f; 
    private readonly float ABILITY_ANIMATION_TIME = 0.25f; 
    private readonly float CHANGE_SPRITE_TIME = 0.3f; 


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
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // continue this pattern when we have more item sprites
    }

    public void AddShadow() {
        SpriteRenderer shadowRenderer = spriteLayers["ShadowBehind"];
        SpriteRenderer shadowGroundRenderer = spriteLayers["ShadowGround"];

        if(shadowRenderer == null) return;

        shadowRenderer.sprite = spriteLayers["Character"].sprite;
        shadowRenderer.color = new Color(0f, 0f, 0f, 0.8f);
        shadowRenderer.transform.localScale = Vector3.one * 1.02f;
        shadowGroundRenderer.sprite = Resources.Load<Sprite>("Sprites/Characters/ShadowGround");
        shadowGroundRenderer.transform.localPosition = new Vector3(0f, -0.46f, 0f);
        shadowGroundRenderer.transform.localScale = Vector3.one * 0.7f;
        shadowGroundRenderer.color = new Color(0f, 0f, 0f, 0.6f);
    }

    private void SetSprite(Sprite sprite, SpriteRenderer sr) {
        sr.sprite = sprite;
    }

    // invoke a number of SetSprites after delays
    private void RollSprites(List<Sprite> sprites, SpriteRenderer sr, float delay){
        int l = sprites.Count;
        for(int i = 1; i <= l; i++){
            int frameIndex = i;
            DelayedAction(() => SetSprite(sprites[frameIndex % l], sr), delay * frameIndex - delay + ATTACK_TIME/3f);
        }
    }

    //new attack animation
    public void AttackAnimation(string type, GameCharacter thisCharacter) {
        string characterType = thisCharacter.GetType().Name;
        Equipment equipment = thisCharacter.equipment;
        if(equipment.weaponLeft != null) {
            RollSprites(thisCharacter.sprites, spriteLayers["Character"], CHANGE_SPRITE_TIME);
            if(equipment.weaponLeft.sprites != null)
                RollSprites(equipment.weaponLeft.sprites, spriteLayers["Weapon"], CHANGE_SPRITE_TIME);
        }
    }

    public void AbilityAnimation(Vector3 targetPos, GameCharacter sender, int selectedSkill, int frames) {
        
        Transform pos = spriteLayers["Ability"].gameObject.transform;
        pos.position += Vector3.forward;
        Vector3 toTarget = targetPos - pos.position;
        float attackTime = ATTACK_TIME/2f + Mathf.Abs(toTarget.x) / 40f;

        Skill skillToUse = sender.skills[selectedSkill];

        if(!(skillToUse is Heal || skillToUse is Sacrifice)) {
            Vector3 lungeOffset = toTarget * DINSTANCE_TO_LUNGE;
            if(skillToUse is HeatWave) {
                lungeOffset /= 20f;
                attackTime /= 2f;
            }
            LungeTo(sender, lungeOffset, attackTime); 
        }

        if (skillToUse.sprites == null){
            return;
        }
        Sprite sprite = sender.skills[selectedSkill].sprites[0];

        if(sprite != null) {
            pos.GetComponent<SpriteRenderer>().enabled = false;
            pos.GetComponent<SpriteRenderer>().sprite = sprite;

            bool fade = false;
            bool isReverse = false;
            float animationTime = ABILITY_ANIMATION_TIME/2f;
            if(skillToUse is HeatWave) {
                isReverse = true;
                animationTime *= 4f;
                ChangeOpacity(spriteLayers["Ability"], 0.8f);
            }
            if(skillToUse is Heal) {
                toTarget = Vector3.zero;
                fade = true;
                frames *= 2;
                animationTime *= 6f;
                pos.localScale = new Vector3(1.3f,1.3f,1.3f);
                // pos.position += new Vector3(0f,0.2f,0f);
                ChangeOpacity(spriteLayers["Ability"], 1f);
            }
             
            RollScales(pos, toTarget, frames, animationTime, isReverse, fade);
        }
    }

    private void RollScales(Transform tr, Vector3 toTarget, int frames, float delay, bool isReverse, bool fade) {
        float scale = frames;
        Vector3 originalPos = tr.position;
        tr.position += toTarget * 0.9f;
        for(int i = 0; i <= frames; i++){
            float newScale;
            int frameIndex = i;
            if(isReverse){
                newScale = (float)frameIndex * 1.1f;
            }else{
                newScale = (float)(scale-frameIndex) * 0.8f;
            }

            DelayedAction(() => SetScale(tr, newScale, originalPos, frames, frameIndex, fade), frameIndex * (delay/frames) + ATTACK_TIME/1.5f);
        }   
    }

    private void SetScale(Transform tr, float scale, Vector3 originalPos, int frames, int frameIndex, bool fade) {
        SpriteRenderer sr = tr.GetComponent<SpriteRenderer>();
        if(frameIndex >= frames) {
            sr.enabled = false;
            tr.position = originalPos;
        }else {
            if(!sr.enabled) 
                sr.enabled = true;
            if(fade) {
                // tr.Rotate(0f, 0f, 90f);
                tr.position += new Vector3(0f, 0.015f, 0f);
                ChangeOpacity(sr, 1f/(float)frameIndex);
                tr.localScale *= 0.98f;
            }else {
                tr.localScale = new Vector3(scale, scale, scale);
            }
        }
    }

    // make a character lugne smoothly to the target and back
    private void LungeTo(GameCharacter thisCharacter, Vector3 offset, float duration) {
        StartCoroutine(LungeCoroutine(thisCharacter.transform.GetChild(0).transform, offset, duration));
    }
    private IEnumerator LungeCoroutine(Transform t, Vector3 offset, float duration) {
        Vector3 start = t.position;
        Vector3 end = start + offset;

        float halfDuration = duration/2f;
        float time = 0f;

        while(time < halfDuration){
            t.position = Vector3.Lerp(start, end, time / halfDuration);
            time += Time.deltaTime;
            yield return null;
        }
        t.position = end;
        time = 0f;

        while(time < halfDuration){
            t.position = Vector3.Lerp(end, start, time / halfDuration);
            time += Time.deltaTime;
            yield return null;
        }
        t.position = start;
    }

    private void ChangeOpacity(SpriteRenderer sr, float opacity) {
        Color color = sr.color;
        color.a = 0.6f;
        sr.color = color;
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
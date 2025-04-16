using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour
{
    public Transform spriteContainer;
    public Transform abilityContainer;
    public SpriteRenderer spriteRenderer;
    public Dictionary<string, SpriteRenderer> spriteLayers = new Dictionary<string, SpriteRenderer>();

    private readonly float ATTACK_TIME = 0.35f; 
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
            if(equipment.torso != null) {
                if(equipment.torso.sprites != null)
                    SetSprite(equipment.torso.sprites[0], spriteLayers["Torso"]); 
            }
            if(equipment.boots != null) {
                if(equipment.boots.sprite != null)
                    SetSprite(equipment.boots.sprite, spriteLayers["Boots"]); 
            }
            if(equipment.weaponLeft != null) {
                if(equipment.weaponLeft.sprites != null)
                    SetSprite(equipment.weaponLeft.sprites[0], spriteLayers["Weapon"]); 
            }
        }
        if(!(thisCharacter is Player)){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        AddShadow();
    }

    public void SetSprite(Sprite sprite, SpriteRenderer sr) {
        sr.sprite = sprite;
    }

    public void HideSprite(SpriteRenderer sr) {
        sr.enabled = false;
    }

    public void SetScale(Transform tr, float newScale) {
        tr.localScale = Vector3.one * newScale;
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

    // invoke a number of SetSprites after delays
    public void RollSprites(List<Sprite> sprites, SpriteRenderer sr, float delay){
        int l = sprites.Count;
        for(int i = 1; i <= l; i++){
            int frameIndex = i;
            DelayedAction(() => SetSprite(sprites[frameIndex % l], sr), delay * frameIndex - delay + ATTACK_TIME/3f);
        }
    }

    public void AttackAnimation(GameCharacter thisCharacter) {
        Equipment equipment = thisCharacter.equipment;
        if(equipment.weaponLeft != null && !(equipment.weaponLeft is BrassKnuckles)) {
            RollSprites(thisCharacter.sprites, spriteLayers["Character"], CHANGE_SPRITE_TIME);
            if(equipment.weaponLeft.sprites != null) {
                RollSprites(equipment.weaponLeft.sprites, spriteLayers["Weapon"], CHANGE_SPRITE_TIME);
                if(equipment.torso != null && equipment.torso.sprites != null)
                    RollSprites(equipment.torso.sprites, spriteLayers["Torso"], CHANGE_SPRITE_TIME);
            }
        }
    }

    public void RollScales(Transform tr, Vector3 toTarget, int frames, float delay, float scale, bool fade, bool fadeUp, bool slice, int stopAt) {
        Vector3 originalPos = tr.position;
        tr.position += toTarget * 0.9f;

        for(int i = 0; i <= frames; i++){
            int frameIndex = i;
            DelayedAction(() => SetScale(tr, originalPos, frameIndex, frames, scale, fade, fadeUp, slice, stopAt), frameIndex * (delay/frames) + ATTACK_TIME/1.5f);
        }   
    }

    private void SetScale(Transform tr, Vector3 originalPos, int frameIndex, int frames, float scale, bool fade, bool fadeUp, bool slice, int stopAt) {
        SpriteRenderer sr = tr.GetComponent<SpriteRenderer>();
        if(frameIndex >= frames) {
            sr.enabled = false;
            tr.position = originalPos;
        }else {
            if(!sr.enabled) 
                sr.enabled = true;

            if(frameIndex <= stopAt) {
                tr.localScale *= scale;
                if(slice) {
                    if(frameIndex == 0) tr.position += new Vector3(-0.2f, 0.5f, 0f);
                    tr.position += new Vector3(0.07f, -0.15f, 0f);
                }
            }

            if(fade) {
                ChangeOpacity(sr, 1f/(float)frameIndex);
                if(fadeUp) {
                    tr.position += new Vector3(0f, 0.015f, 0f);
                }
            }
        }
    }

    public void ChangeOpacity(SpriteRenderer sr, float opacity) {
        Color color = sr.color;
        color.a = opacity;
        sr.color = color;
    }


    // make a character lugne smoothly to the target and back
    public void LungeTo(GameCharacter thisCharacter, Vector3 offset, float duration) {
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
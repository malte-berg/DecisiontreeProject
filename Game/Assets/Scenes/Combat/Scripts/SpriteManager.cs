using UnityEngine;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour
{
    private Transform spriteContainer;
    private Transform abilityContainer;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> spriteList;

    private Dictionary<string, List<Sprite>> animations = new Dictionary<string, List<Sprite>>();
    private Dictionary<string, SpriteRenderer> spriteLayers = new Dictionary<string, SpriteRenderer>();

    void Awake()
    {
        abilityContainer = transform.Find("Ability");
        SpriteRenderer sr = abilityContainer.GetComponent<SpriteRenderer>();
        spriteLayers.Add("Ability", sr);

        spriteContainer = transform.Find("CharacterContainer");
        
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
        animations["Punch"] = new List<Sprite> {spriteList[4], spriteList[5], spriteList[6]};

    }

    public void SetCharacter(string type) {
        if(animations.ContainsKey(type)) {
            spriteLayers["Character"].sprite = animations[type][0];
        } else {
            Debug.Log("Could not find sprite");
        }
    }

    //new attack animation
    public void Animation(string type, float delay) {
        if(type.Contains("Player")) {
            spriteLayers["Character"].sprite = animations["Player"][1];
            Invoke("PlayerChangeBack", delay);
        }else if(type.Contains("Enemy")) {
            spriteLayers["Character"].sprite = animations["Enemy"][1];
            Invoke("EnemyChangeBack", delay);  
        }else {
            Debug.Log("unknown attacker");
        }
    }

    public void PlayerChangeBack() {
        spriteLayers["Character"].sprite = animations["Player"][0];
    }
    public void EnemyChangeBack() {
        spriteLayers["Character"].sprite = animations["Enemy"][0];
    }

    public void PunchAnimation(GameCharacter target) {
        Transform pos = spriteLayers["Ability"].gameObject.transform;
        Vector3 toTarget = target.gameObject.transform.position - pos.position;
        Vector3 x = toTarget * 0.92f;
        pos.position = pos.position + x;

        spriteLayers["Ability"].sprite = animations["Punch"][0];
        Invoke("PunchInvoked1", 0.1f);
        
    }

    public void PunchInvoked1() {
        spriteLayers["Ability"].sprite = animations["Punch"][1];
        Invoke("PunchInvoked2", 0.1f);
    }
    public void PunchInvoked2() {
        spriteLayers["Ability"].sprite = animations["Punch"][2];
        Invoke("PunchInvoked3", 0.1f);
    }
    public void PunchInvoked3() {
        spriteLayers["Ability"].sprite = null;
        spriteLayers["Ability"].gameObject.transform.position = spriteLayers["Character"].gameObject.transform.position;
    }
    
}

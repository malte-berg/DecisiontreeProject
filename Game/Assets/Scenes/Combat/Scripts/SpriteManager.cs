using UnityEngine;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour
{
    private Transform spriteContainer;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> spriteList;

    private Dictionary<string, Sprite> characterSprites = new Dictionary<string, Sprite>(); //temp
    private Dictionary<string, List<Sprite>> animations = new Dictionary<string, List<Sprite>>();
    private Dictionary<string, SpriteRenderer> spriteLayers = new Dictionary<string, SpriteRenderer>();

    private string typeForCoroutine;
    private int indexForCoroutine;
    void Awake()
    {
        spriteContainer = transform.Find("Capsule");

        if (spriteContainer != null) {
            // get all the child objects in the sprite container
            foreach (Transform child in spriteContainer) {
                SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
                if (sr != null) {
                    spriteLayers.Add(child.name, sr);
                }
            }
        } else {
            Debug.LogError("SpriteContainer not found!");
        }

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        characterSprites.Add("Player", spriteList[0]);
        characterSprites.Add("PlayerAttack", spriteList[1]);
        characterSprites.Add("Enemy", spriteList[2]);
        characterSprites.Add("EnemyAttack", spriteList[3]);

        animations["Player"] = new List<Sprite> {spriteList[0], spriteList[1]};
        animations["Enemy"] = new List<Sprite> {spriteList[2], spriteList[3]};
        // animations["Punch"] = new List<Sprite> {spriteList[4], spriteList[5], spriteList[6]};

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

    // public void SetItem(Sprite itemSprite) {
    //     itemRenderer.sprite = itemSprite;
    // }

    //temporary bad code
    
}

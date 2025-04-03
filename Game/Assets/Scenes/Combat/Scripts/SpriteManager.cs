using UnityEngine;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public List<Sprite> spriteList;

    private Dictionary<string, Sprite> characterSprites = new Dictionary<string, Sprite>();

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        characterSprites.Add("Player", spriteList[0]);
        characterSprites.Add("PlayerAttack", spriteList[1]);
        characterSprites.Add("Enemy", spriteList[2]);
        characterSprites.Add("EnemyAttack", spriteList[3]);

    }

    public void SetCharacter(string type) {
        if(characterSprites.ContainsKey(type)) {
            spriteRenderer.sprite = characterSprites[type];
            Debug.Log("set sprite to: " + type);
        }
    }

    //temporary bad code
    public void AttackAnimation() {
        if(spriteRenderer.sprite == characterSprites["Player"]) {
            spriteRenderer.sprite = characterSprites["PlayerAttack"];
            Invoke("PlayerChangeBack", 0.3f);
        } else if(spriteRenderer.sprite == characterSprites["Enemy"]) {
            spriteRenderer.sprite = characterSprites["EnemyAttack"];
            Invoke("EnemyChangeBack", 0.3f);
        }
    }

    public void PlayerChangeBack() {
        spriteRenderer.sprite = characterSprites["Player"];
    }
    public void EnemyChangeBack() {
        spriteRenderer.sprite = characterSprites["Enemy"];
    }
    
}

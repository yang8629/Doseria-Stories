using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour {
    public CharacterData[] all_character;
    public GameObject Angier;
    public GameObject Boromi;

    void Awake(){
        for (int i = 0; i < all_character.Length; i++)
        {
            BattleInfo.SetCharacterInbattle(all_character[i].name, all_character[i].characterObj, all_character[i].Hp, all_character[i].Ag, all_character[i].At);
        }
        Angier = Instantiate(BattleInfo.characterInbattle[0].CharacterPrefab, new Vector3(2.5f, 0.5f, 0), Quaternion.identity);
        BattleInfo.characterInbattle[0].SetCharacterObj(Angier);
        Boromi = Instantiate(BattleInfo.characterInbattle[1].CharacterPrefab, new Vector3(-2.5f, 0.75f, 0), Quaternion.identity);
        BattleInfo.characterInbattle[1].SetCharacterObj(Boromi);
    }
}

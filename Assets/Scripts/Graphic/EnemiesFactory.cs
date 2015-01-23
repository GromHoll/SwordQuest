using System.Xml;
using UnityEngine;

public class EnemiesFactory : MonoBehaviour {

    public HeroCamera heroCamera;

    public GameObject ZombiePrefab;
    public GameObject SkeletonPrefab;
    public GameObject CultistPrefab;
    public GameObject WitchPrefab;

    private Vector3 slot1Shift = new Vector3(3.6f, 0.75f, -0.90f);
    private Vector3 slot2Shift = new Vector3(4.0f, 0.80f, -1.50f);
    private Vector3 slot3Shift = new Vector3(4.6f, 0.75f, -1.25f);

    public void CreateMonsters(MonsterPack monsters) {
        if (monsters.Slot1 != null) {
            CreateMonster(monsters.Slot1, slot1Shift);
        }
        if (monsters.Slot2 != null) {
            CreateMonster(monsters.Slot2, slot2Shift);
        }
        if (monsters.Slot3 != null) {
            CreateMonster(monsters.Slot3, slot3Shift);
        }
    }

    private GameObject GetPrefab(Monster monster) {
        if (monster is Zombie) {
            return ZombiePrefab;
        }
        if (monster is Skeleton) {
            return SkeletonPrefab;
        }
        if (monster is Cultist) {
            return CultistPrefab;
        }
        if (monster is Witch) {
            return WitchPrefab;
        }
        return null;
    }

    public void CreateMonster(Monster monster, Vector3 shift) {
        var prefab = GetPrefab(monster);

        var spawnPosition = heroCamera.transform.forward * shift.x;
        spawnPosition    += heroCamera.transform.up * shift.y;
        spawnPosition    += heroCamera.transform.right * shift.z;
        
        var monsterObj = (GameObject) Instantiate(prefab, spawnPosition, Quaternion.identity);

        var eulerAngles = monsterObj.transform.eulerAngles;
        eulerAngles.y = heroCamera.transform.eulerAngles.y - 90;
        monsterObj.transform.eulerAngles = eulerAngles;
    }

}

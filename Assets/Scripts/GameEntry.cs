using UnityEngine;

public class GameEntry : MonoBehaviour {

    public HeroCamera heroCamera;
    public EnemiesFactory enemiesFactory;

    private Dungeon dungeon = new Dungeon();
    private MonsterPack currentMonsterPack = null;

	void Start () {
	
	}
	
	void Update () {
        if (currentMonsterPack == null || currentMonsterPack.IsDefeated()) {
            if (dungeon.IsFinished()) {
                // TODO Win
            } else {
                currentMonsterPack = dungeon.GetNextMonsters();
                enemiesFactory.CreateMonsters(currentMonsterPack);
                heroCamera.MoveToNextPoint();
            }
	    }

	    if (heroCamera.IsStop()) {
	        // TODO atack
	    }
	}
}

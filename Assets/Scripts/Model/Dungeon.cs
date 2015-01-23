using System.Collections.Generic;

public class Dungeon {

    private int level;

    readonly IList<MonsterPack> monsterPacks = new List<MonsterPack> {
        new MonsterPack { Slot2 = new Zombie()},
        new MonsterPack { Slot1 = new Zombie(), Slot2 = new Zombie(), Slot3 = new Zombie()},
        new MonsterPack { Slot1 = new Zombie(), Slot2 = new Skeleton(), Slot3 = new Zombie()},
        new MonsterPack { Slot1 = new Skeleton(), Slot3 = new Skeleton()},
        new MonsterPack { Slot1 = new Skeleton(), Slot2 = new Skeleton(), Slot3 = new Skeleton()},
        new MonsterPack { Slot1 = new Skeleton(), Slot2 = new Cultist(), Slot3 = new Skeleton()},
        new MonsterPack { Slot1 = new Cultist(), Slot2 = new Cultist(), Slot3 = new Cultist()},
        new MonsterPack { Slot2 = new Witch()}
    };

    public Dungeon() {
        level = 0;
    }

    public bool IsFinished() {
        return level >= 8;
    }

    public MonsterPack GetNextMonsters() {
        return monsterPacks[level++];
    }

}

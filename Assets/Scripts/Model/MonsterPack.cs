public class MonsterPack {

    public Monster Slot1 { get; set; }
    public Monster Slot2 { get; set; }
    public Monster Slot3 { get; set; }

    public bool IsDefeated() {
        if (Slot1 != null && !Slot1.IsDead()) {
            return false;
        }
        if (Slot2 != null && !Slot2.IsDead()) {
            return false;
        }
        if (Slot3 != null && !Slot3.IsDead()) {
            return false;
        }
        return true;
    }

}

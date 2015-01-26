using System;

public abstract class Monster {

    private int health;
    public int Health {
        get { return Math.Max(0, health); }
        private set { health = value; }
    }

    public int MaxHealth { get; private set; }

    protected Monster(int monsterHealth) {
        Health = monsterHealth;
        MaxHealth = monsterHealth;
        Health = 1;
    }

    public bool IsDead() {
        return Health <= 0;
    }
}


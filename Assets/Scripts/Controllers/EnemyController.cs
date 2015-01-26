using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public Slider slider;
    public Text textField;

	public Monster Monster { get; set; }
	
	// Update is called once per frame
	void Update () {
	    if (Monster.IsDead()) {
	        Destroy(gameObject);
	    } else {
            slider.normalizedValue = (float) Monster.Health / Monster.MaxHealth;
	    }

	}
}

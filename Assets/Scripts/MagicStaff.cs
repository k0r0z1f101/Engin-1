[System.Serializable]
public struct Weapon
{
  [UnityEngine.SerializeField]
  private string name;

  [UnityEngine.SerializeField]
  private int damage;

  public Weapon(string name, int damage)
  {
    this.name = name;
    this.damage = damage;
  }

  public void PrintWeaponStats()
  {
    UnityEngine.Debug.LogFormat("Weapon: {0} - {1} Damage", name, damage);
  }
}

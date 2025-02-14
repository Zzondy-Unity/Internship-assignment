public interface IAttackStrategy
{
    public void Init(PlayerAttackController attackController);
    public void Attack(int damage);
}
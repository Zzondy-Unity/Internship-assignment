public class MonsterIndicator : UIPopup
{
    public override void OnShow(object args)
    {
        base.OnShow(args);
        if (args is Monster monster)
        {
            SetIndicator(monster);
        }
    }

    private void SetIndicator(Monster monster)
    {
        // 몬스터 정보 올리기
    }
}

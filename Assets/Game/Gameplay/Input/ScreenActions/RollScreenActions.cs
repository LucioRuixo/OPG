namespace OPG.Input
{
    public class RollScreenActions : ScreenActions
    {
        public void Roll() => inputContext.DoAction(MainInputContext.Actions.Roll);

        public void LogEpisodes() => inputContext.DoAction(MainInputContext.Actions.LogEpisodes);
    }
}
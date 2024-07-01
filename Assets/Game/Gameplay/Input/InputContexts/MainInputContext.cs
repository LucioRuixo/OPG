namespace OPG.Input
{
    public class MainInputContext : InputContext<MainInputContext.Actions>
    {
		public enum Actions
        {
            Roll,
            LogEpisodes,
        }
    }
}
namespace OPG.UI
{
    using Input;

    public class RollScreen : Screen
    {
        public void Roll() => inputContext.DoAction(MainInputContext.Actions.Roll);
    }
}
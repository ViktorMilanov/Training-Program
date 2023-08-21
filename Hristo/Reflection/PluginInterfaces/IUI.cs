namespace Reflection.DataContracts
{
    public interface IUI
    {
        IFrame GetMainFrame();
        IFrame GetLeftFrame();
        IFrame GetRightFrame();
        IFrame GetTopFrame();
        IFrame GetBottomFrame();
    }
}

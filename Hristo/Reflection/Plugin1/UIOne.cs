using Reflection.DataContracts;

namespace Plugin1
{
    public class UIOne : IUI
    {
        public IFrame GetMainFrame()
        {
            return new FrameOne();
        }

        public IFrame GetLeftFrame()
        {
            return new FrameOne();
        }

        public IFrame GetRightFrame()
        {
            return new FrameOne();
        }

        public IFrame GetTopFrame()
        {
            return new FrameOne();
        }

        public IFrame GetBottomFrame()
        {
            return new FrameOne();
        }
    }
}

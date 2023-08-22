using Reflection.DataContracts;

namespace Plugin2
{
    public class UITwo : IUI
    {
        public IFrame GetMainFrame()
        {
            return new FrameTwo();
        }

        public IFrame GetLeftFrame()
        {
            return new FrameTwo();
        }

        public IFrame GetRightFrame()
        {
            return new FrameTwo();
        }

        public IFrame GetTopFrame()
        {
            return new FrameTwo();
        }

        public IFrame GetBottomFrame()
        {
            return new FrameTwo();
        }
    }
}

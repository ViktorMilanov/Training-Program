using Reflection.DataContracts;

namespace FeatureEnrichmentPlugin.Implementations
{
    public class UI : IUI
    {
        private IFrame mainFrame;
        private IFrame leftFrame;
        private IFrame rightFrame;
        private IFrame topFrame;
        private IFrame bottomFrame;

        public UI()
        {
            mainFrame = new Frame();
            leftFrame = new Frame();
            rightFrame = new Frame();
            topFrame = new Frame();
            bottomFrame = new Frame();
        }

        public IFrame GetMainFrame()
        {
            return mainFrame;
        }

        public IFrame GetLeftFrame()
        {
            return leftFrame;
        }

        public IFrame GetRightFrame()
        {
            return rightFrame;
        }

        public IFrame GetTopFrame()
        {
            return topFrame;
        }

        public IFrame GetBottomFrame()
        {
            return bottomFrame;
        }
    }
}

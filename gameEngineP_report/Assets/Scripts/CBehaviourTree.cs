using System.Collections.Generic;
using UnityEngine.XR;

public class CBehaviourTree
{
    public enum EStatus
    {
        SUCCEEDED,
        FAILED,
        RUNNING
    }

    public abstract class Node
    {
        public delegate EStatus NodeReturn();

        protected EStatus mStaus;

        public EStatus Status
        {
            get { return mStaus; }
        }

        public abstract EStatus Execute();
    }

    public class Sequence : Node
    {
        private List<Node> mNodes = new List<Node>();

        public Sequence(List<Node> tNodes)
        {
            mNodes = tNodes;
        }

        public override EStatus Execute()
        {
            bool tAnyChildRunning = false;

            foreach (Node node in mNodes)
            {
                switch (node.Execute())
                {
                    case EStatus.FAILED:
                        mStaus = EStatus.FAILED;
                        return mStaus;
                    case EStatus.SUCCEEDED:
                        continue;
                    case EStatus.RUNNING:
                        tAnyChildRunning = true;
                        continue;
                    default:
                        mStaus = EStatus.SUCCEEDED;
                        return mStaus;
                }
            }
            mStaus = tAnyChildRunning ? EStatus.RUNNING : EStatus.SUCCEEDED;
            return mStaus;
        }
    }

    public class ActionNode : Node
    {
        public delegate EStatus ActionNodeDelegate();

        private ActionNodeDelegate mAction;

        public ActionNode(ActionNodeDelegate action)
        {
            mAction = action;
        }

        public override EStatus Execute()
        {
            switch (mAction())
            {
                case EStatus.SUCCEEDED:
                    mStaus = EStatus.SUCCEEDED;
                    return mStaus;
                case EStatus.FAILED:
                    mStaus = EStatus.FAILED;
                    return mStaus;
                case EStatus.RUNNING:
                    mStaus = EStatus.RUNNING;
                    return mStaus;
                default:
                    mStaus = EStatus.FAILED;
                    return mStaus;
            }
        }
    }

    
}

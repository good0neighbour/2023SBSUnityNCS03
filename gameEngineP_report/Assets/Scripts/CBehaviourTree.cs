using System.Collections.Generic;

public class CBehaviourTree
{
    #region 행동트리 구조
    public enum EStatus
    {
        SUCCEEDED,
        FAILED,
        RUNNING
    }

    public delegate EStatus NodeDelegate();

    public abstract class Node
    {
        public delegate EStatus NodeReturn();

        protected EStatus mStaus;

        public EStatus Status
        {
            get { return mStaus; }
        }

        public abstract EStatus Execute();

        public abstract void Addchild(Node tChild);
    }

    public class SelectorNode : Node
    {
        private List<Node> mNodes = new List<Node>();

        public override EStatus Execute()
        {
            foreach (Node node in mNodes)
            {
                switch (node.Execute())
                {
                    case EStatus.FAILED:
                        continue;
                    case EStatus.SUCCEEDED:
                        mStaus = EStatus.SUCCEEDED;
                        return mStaus;
                    case EStatus.RUNNING:
                        mStaus = EStatus.RUNNING;
                        return mStaus;
                    default:
                        continue;
                }
            }
            mStaus = EStatus.FAILED;
            return mStaus;
        }

        public override void Addchild(Node tChild)
        {
            mNodes.Add(tChild);
        }
    }

    public class SequenceNode : Node
    {
        private List<Node> mNodes = new List<Node>();

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

        public override void Addchild(Node tChild)
        {
            mNodes.Add(tChild);
        }
    }

    public class ActionNode : Node
    {
        private NodeDelegate mAction;

        public ActionNode(NodeDelegate tFunction)
        {
            mAction = tFunction;
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

        public override void Addchild(Node tChild)
        {
            
        }
    }
    #endregion

    #region 행동트리
    private Node mRootNode = null;
    private Stack<Node> mLastNodes = new Stack<Node>();

    /// <summary>
    /// 행동트리 작동
    /// </summary>
    public void Execute()
    {
        mRootNode.Execute();
    }

    /// <summary>
    /// 행동트리에 Selector 추가
    /// </summary>
    public CBehaviourTree Selector()
    {
        // 노드 생성
        SelectorNode tSelector = new SelectorNode();

        // 이것이 루트 노드가 될 때
        if (null == mRootNode)
        {
            mRootNode = tSelector;
        }
        // 이것이 자식 노드일 때
        else
        {
            mLastNodes.Peek().Addchild(tSelector);
        }

        mLastNodes.Push(tSelector);

        return this;
    }

    /// <summary>
    /// 행동트리에 Sequence 추가
    /// </summary>
    public CBehaviourTree Sequence()
    {
        // 노드 생성
        SequenceNode tSequence = new SequenceNode();

        // 이것이 루트 노드가 될 때
        if (null == mRootNode)
        {
            mRootNode = tSequence;
        }
        // 이것이 자식 노드일 때
        else
        {
            mLastNodes.Peek().Addchild(tSequence);
        }

        mLastNodes.Push(tSequence);

        return this;
    }

    /// <summary>
    /// 행동트리에 Action 추가
    /// </summary>
    /// <param name="tFunction">Action으로 등록할 함수</param>
    public CBehaviourTree Action(NodeDelegate tFunction)
    {
        // 노드 생성
        ActionNode tAction = new ActionNode(tFunction);

        // 이것이 루트 노드가 될 때
        if (null == mRootNode)
        {
            mRootNode = tAction;
        }
        // 이것이 자식 노드일 때
        else
        {
            mLastNodes.Peek().Addchild(tAction);
        }

        return this;
    }

    /// <summary>
    /// 현재 노드의 자식 노드 생성이 끝났으면 그 이전 노드로 빠져나오기
    /// </summary>
    public CBehaviourTree Escape()
    {
        mLastNodes.Pop();

        if (1 > mLastNodes.Count)
        {
            mLastNodes = null;
            return null;
        }
        else
        {
            return this;
        }
    }
    #endregion
}

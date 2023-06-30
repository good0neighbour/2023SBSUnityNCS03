using System.Collections.Generic;

public class CBehaviourTree
{
    #region �ൿƮ�� ����
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

    #region �ൿƮ��
    private Node mRootNode = null;
    private Stack<Node> mLastNodes = new Stack<Node>();

    /// <summary>
    /// �ൿƮ�� �۵�
    /// </summary>
    public void Execute()
    {
        mRootNode.Execute();
    }

    /// <summary>
    /// �ൿƮ���� Selector �߰�
    /// </summary>
    public CBehaviourTree Selector()
    {
        // ��� ����
        SelectorNode tSelector = new SelectorNode();

        // �̰��� ��Ʈ ��尡 �� ��
        if (null == mRootNode)
        {
            mRootNode = tSelector;
        }
        // �̰��� �ڽ� ����� ��
        else
        {
            mLastNodes.Peek().Addchild(tSelector);
        }

        mLastNodes.Push(tSelector);

        return this;
    }

    /// <summary>
    /// �ൿƮ���� Sequence �߰�
    /// </summary>
    public CBehaviourTree Sequence()
    {
        // ��� ����
        SequenceNode tSequence = new SequenceNode();

        // �̰��� ��Ʈ ��尡 �� ��
        if (null == mRootNode)
        {
            mRootNode = tSequence;
        }
        // �̰��� �ڽ� ����� ��
        else
        {
            mLastNodes.Peek().Addchild(tSequence);
        }

        mLastNodes.Push(tSequence);

        return this;
    }

    /// <summary>
    /// �ൿƮ���� Action �߰�
    /// </summary>
    /// <param name="tFunction">Action���� ����� �Լ�</param>
    public CBehaviourTree Action(NodeDelegate tFunction)
    {
        // ��� ����
        ActionNode tAction = new ActionNode(tFunction);

        // �̰��� ��Ʈ ��尡 �� ��
        if (null == mRootNode)
        {
            mRootNode = tAction;
        }
        // �̰��� �ڽ� ����� ��
        else
        {
            mLastNodes.Peek().Addchild(tAction);
        }

        return this;
    }

    /// <summary>
    /// ���� ����� �ڽ� ��� ������ �������� �� ���� ���� ����������
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

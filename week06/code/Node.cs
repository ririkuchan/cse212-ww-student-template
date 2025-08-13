public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Insert Unique Values Only（重複は無視）
        if (value == Data) return;

        if (value < Data)
        {
            if (Left is null) Left = new Node(value);
            else Left.Insert(value);
        }
        else // value > Data
        {
            if (Right is null) Right = new Node(value);
            else Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2
        if (value == Data) return true;
        if (value < Data)  return Left is not null && Left.Contains(value);
        /* value > Data */ return Right is not null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // Problem 4（自分を1として、左右の最大+1）
        int leftH  = Left?.GetHeight()  ?? 0;
        int rightH = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftH, rightH);
    }

}
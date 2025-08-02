public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    private bool[] CurrCell()
    {
        return _mazeMap[( _currX, _currY )]; // 配列: [left, right, up, down]
    }

    private static void ThrowBlocked() =>
        throw new InvalidOperationException("Can't go that way!");

    public void MoveLeft()
    {
        var dirs = CurrCell();
        if (!dirs[0]) ThrowBlocked();
        _currX -= 1;
    }

    public void MoveRight()
    {
        var dirs = CurrCell();
        if (!dirs[1]) ThrowBlocked();
        _currX += 1;
    }

    public void MoveUp()
    {
        var dirs = CurrCell();
        if (!dirs[2]) ThrowBlocked();
        _currY += 1;
    }

    public void MoveDown()
    {
        var dirs = CurrCell();
        if (!dirs[3]) ThrowBlocked();
        _currY -= 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}

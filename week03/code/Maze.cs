using System;
using System.Collections.Generic;

public class Maze
{
    private Dictionary<(int x, int y), bool[]> mazeMap;
    private (int x, int y) location;

    public Maze(Dictionary<(int x, int y), bool[]> map)
    {
        mazeMap = map;
        location = (1, 1);
    }

    public string GetStatus()
    {
        return $"Current location (x={location.x}, y={location.y})";
    }

    public (int, int) GetLocation() => location;

    private void Move(int dx, int dy, int dirIndex)
    {
        if (!mazeMap.ContainsKey(location) || !mazeMap[location][dirIndex])
            throw new InvalidOperationException("Can't go that way!");

        location = (location.x + dx, location.y + dy);
    }

    public void MoveUp() => Move(0, -1, 2);
    public void MoveDown() => Move(0, 1, 3);
    public void MoveLeft() => Move(-1, 0, 0);
    public void MoveRight() => Move(1, 0, 1);

    public void SetLocation(int x, int y) => location = (x, y);
}

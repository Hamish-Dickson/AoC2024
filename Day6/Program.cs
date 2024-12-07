namespace Day6
{
    internal static class Program
    {
        public static void Main()
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            (int x, int y) up = (-1, 0);
            (int x, int y) down = (1, 0);
            (int x, int y) left = (0, -1);
            (int x, int y) right = (0, 1);
            (int x, int y) pos = (0, 0);
            bool offEdge = false;

            HashSet<(int x, int y)> visited = [];

            string[] lines = File.ReadAllLines("input.txt");
            char[][] level = lines.Select(x => x.ToCharArray()).ToArray();

            int height = lines.Length;
            int width = lines[0].Length;

            FindStart();

            while (!offEdge)
            {
                offEdge = WouldLeaveMap();
                if (!offEdge && CanMove())
                {
                    Console.WriteLine("Can Move!");
                    DoMove();

                    void DoMove()
                    {
                        switch (level[pos.x][pos.y])
                        {
                            case '^':
                                level[pos.x + up.x][pos.y + up.y] = '^';
                                level[pos.x][pos.y] = '.';
                                Console.WriteLine("Moving Up!");
                                pos = (pos.x + up.x, pos.y + up.y);
                                break;
                            case '>':
                                level[pos.x + right.x][pos.y + right.y] = '>';
                                level[pos.x][pos.y] = '.';
                                Console.WriteLine("Moving Right!");
                                pos = (pos.x + right.x, pos.y + right.y);
                                break;
                            case 'v':
                                level[pos.x + down.x][pos.y + down.y] = 'v';
                                level[pos.x][pos.y] = '.';
                                Console.WriteLine("Moving Down!");
                                pos = (pos.x + down.x, pos.y + down.y);
                                break;
                            case '<':
                                level[pos.x + left.x][pos.y + left.y] = '<';
                                level[pos.x][pos.y] = '.';
                                Console.WriteLine("Moving left!");
                                pos = (pos.x + left.x, pos.y + left.y);
                                break;
                        }

                        visited.Add(pos);
                    }
                }
                else
                {
                    Rotate90();
                    Console.WriteLine("Rotated 90 degrees!");

                    void Rotate90()
                    {
                        level[pos.x][pos.y] = level[pos.x][pos.y] switch
                        {
                            '^' => '>',
                            '>' => 'v',
                            'v' => '<',
                            '<' => '^',
                            _ => level[pos.x][pos.y]
                        };
                    }
                }
            }

            Console.WriteLine("Puzzle part 1: " + visited.Count);
            return;

            bool CanMove()
            {
                if (level[pos.x][pos.y] == '^' && level[pos.x + up.x][pos.y + up.y] == '#')
                {
                    Console.WriteLine("Blocked!");
                    return false;
                }

                if (level[pos.x][pos.y] == '>' && level[pos.x + right.x][pos.y + right.y] == '#')
                {
                    Console.WriteLine("Blocked!");
                    return false;
                }

                if (level[pos.x][pos.y] == 'v' && level[pos.x + down.x][pos.y + down.y] == '#')
                {
                    Console.WriteLine("Blocked!");
                    return false;
                }

                if (level[pos.x][pos.y] == '<' && level[pos.x + left.x][pos.y + left.y] == '#')
                {
                    Console.WriteLine("Blocked!");
                    return false;
                }

                return true;
            }

            bool WouldLeaveMap()
            {
                switch (level[pos.x][pos.y])
                {
                    case '^':
                        if (pos.x == 0)
                        {
                            return true;
                        }

                        break;
                    case '<':
                        if (pos.y == 0)
                        {
                            return true;
                        }

                        break;
                    case '>':
                        if (pos.y == width - 1)
                        {
                            return true;
                        }

                        break;
                    case 'v':
                        if (pos.x == height - 1)
                        {
                            return true;
                        }

                        break;
                    default:
                        return false;
                }

                return false;
            }

            void FindStart()
            {
                for (int i = 0; i < height; i++)
                {
                    for (int y = 0; y < width; y++)
                    {
                        if (level[i][y] == '^')
                        {
                            pos = (i, y);
                            visited.Add(pos);
                        }
                    }
                }
            }
        }

        private static void Part2()
        {
            string[] lines = File.ReadAllLines("input.txt");

            int result = 0;
            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                Span<char> temp = new char[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != '.')
                    {
                        continue;
                    }

                    line.CopyTo(temp);
                    temp[i] = '#';
                    lines[y] = temp.ToString();
                    if (CausesInfinite(lines)) // thank god this isn't python.
                    {
                        result++;
                    }

                    lines[y] = line;
                }
            }

            Console.WriteLine("Puzzle part 2: " + result);
            return;

            bool CausesInfinite(string[] lines)
            {
                (int x, int y) up = (-1, 0);
                (int x, int y) down = (1, 0);
                (int x, int y) left = (0, -1);
                (int x, int y) right = (0, 1);
                (int x, int y) pos = (0, 0);
                bool offEdge = false;

                HashSet<((int x, int y), char i)> visited = [];

                char[][] level = lines.Select(x => x.ToCharArray()).ToArray();

                int height = lines.Length;
                int width = lines[0].Length;

                FindStart();

                while (!offEdge)
                {
                    offEdge = WouldLeaveMap();
                    if (!offEdge && CanMove())
                    {
                        DoMove();

                        void DoMove()
                        {
                            switch (level[pos.x][pos.y])
                            {
                                case '^':
                                    level[pos.x + up.x][pos.y + up.y] = '^';
                                    level[pos.x][pos.y] = '.';
                                    pos = (pos.x + up.x, pos.y + up.y);
                                    break;
                                case '>':
                                    level[pos.x + right.x][pos.y + right.y] = '>';
                                    level[pos.x][pos.y] = '.';
                                    pos = (pos.x + right.x, pos.y + right.y);
                                    break;
                                case 'v':
                                    level[pos.x + down.x][pos.y + down.y] = 'v';
                                    level[pos.x][pos.y] = '.';
                                    pos = (pos.x + down.x, pos.y + down.y);
                                    break;
                                case '<':
                                    level[pos.x + left.x][pos.y + left.y] = '<';
                                    level[pos.x][pos.y] = '.';
                                    pos = (pos.x + left.x, pos.y + left.y);
                                    break;
                            }
                        }

                        if (!visited.Add((pos, level[pos.x][pos.y])))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        Rotate90();

                        void Rotate90()
                        {
                            level[pos.x][pos.y] = level[pos.x][pos.y] switch
                            {
                                '^' => '>',
                                '>' => 'v',
                                'v' => '<',
                                '<' => '^',
                                _ => level[pos.x][pos.y]
                            };
                        }
                    }
                }

                return false;

                bool CanMove()
                {
                    if (level[pos.x][pos.y] == '^' && level[pos.x + up.x][pos.y + up.y] == '#')
                    {
                        return false;
                    }

                    if (level[pos.x][pos.y] == '>' && level[pos.x + right.x][pos.y + right.y] == '#')
                    {
                        return false;
                    }

                    if (level[pos.x][pos.y] == 'v' && level[pos.x + down.x][pos.y + down.y] == '#')
                    {
                        return false;
                    }

                    if (level[pos.x][pos.y] == '<' && level[pos.x + left.x][pos.y + left.y] == '#')
                    {
                        return false;
                    }

                    return true;
                }

                bool WouldLeaveMap()
                {
                    switch (level[pos.x][pos.y])
                    {
                        case '^':
                            if (pos.x == 0)
                            {
                                return true;
                            }

                            break;
                        case '<':
                            if (pos.y == 0)
                            {
                                return true;
                            }

                            break;
                        case '>':
                            if (pos.y == width - 1)
                            {
                                return true;
                            }

                            break;
                        case 'v':
                            if (pos.x == height - 1)
                            {
                                return true;
                            }

                            break;
                        default:
                            return false;
                    }

                    return false;
                }

                void FindStart()
                {
                    for (int i = 0; i < height; i++)
                    {
                        for (int y = 0; y < width; y++)
                        {
                            if (level[i][y] == '^')
                            {
                                pos = (i, y);
                                visited.Add((pos, '^'));
                            }
                        }
                    }
                }
            }
        }
    }
}
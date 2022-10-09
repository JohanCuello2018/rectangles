namespace RectangleProcessor.Core
{
    public class Rectangle
    {
        public Rectangle(int x, int y, int width, int height)
        {
            Height = height;
            Width = width;
            X = x;
            Y = y;
        }

        #region properties
        /// <summary>
        /// Gets the initial X coordinate (horizontal) of the rectangle
        /// </summary>
        public int X { get; init; }

        /// <summary>
        /// Gets the initial Y coordinate (vertical) of the rectangle
        /// </summary>
        public int Y { get; init; }

        /// <summary>
        /// Gets the height of the rectangle
        /// </summary>
        public int Height { get; init; }

        /// <summary>
        /// Gets the width of the rectangle
        /// </summary>
        public int Width { get; init; }
        #endregion

        #region internal properties
        private Coordinate _corner1 = default!;
        internal Coordinate Corner1 
        { 
            get 
            {
                if (_corner1 == null)
                {
                    _corner1 = new Coordinate(X, Y);
                }
                return _corner1; 
            }
        }

        //Optional
        private Coordinate _corner2 = default!;
        internal Coordinate Corner2
        {
            get
            {
                if (_corner2 == null)
                {
                    _corner2 = new Coordinate(X + Width, Y);
                }
                return _corner2;
            }
        }

        private Coordinate _corner3 = default!;
        internal Coordinate Corner3
        {
            get
            {
                if (_corner3 == null)
                {
                    _corner3 = new Coordinate(X + Width, Y + Height);
                }
                return _corner3;
            }
        }

        //Optionals
        private Coordinate _corner4 = default!;
        internal Coordinate Corner4
        {
            get
            {
                if (_corner4 == null)
                {
                    _corner4 = new Coordinate(X, Y + Height);
                }
                return _corner4;
            }
        }
        #endregion

        public bool Contains(Rectangle rect)
        {
            return Contains(rect.Corner1) && Contains(rect.Corner3);
        }

        public bool Contains(Coordinate coordinate)
        {
            return Contains(coordinate.X, coordinate.Y);
        }

        public bool Contains(int x, int y)
        {
            (int x1, int x2) = GetSortedRange(Corner1.X, Corner3.X);
            (int y1, int y2) = GetSortedRange(Corner1.Y, Corner3.Y);

            bool isXContained = x > x1 && x < x2;
            bool isYContained = y > y1 && y < y2;

            return isXContained && isYContained;
        }

        public bool Intersects(Rectangle rect)
        {
            bool isXIntersected = IsInRangeX(rect);
            bool isYIntersected = IsInRangeY(rect);

            return isXIntersected && isYIntersected;
        }

        public bool Adjacent(Rectangle rect)
        {
            return 
                (IsInRangeX(rect) &&
                    (Corner1.Y == rect.Corner1.Y ||
                    Corner1.Y == rect.Corner3.Y ||
                    Corner3.Y == rect.Corner1.Y ||
                    Corner3.Y == rect.Corner3.Y)) ||
                (IsInRangeY(rect) &&
                    (Corner1.X == rect.Corner1.X ||
                    Corner1.X == rect.Corner3.X ||
                    Corner3.X == rect.Corner1.X ||
                    Corner3.X == rect.Corner3.X));
        }

        public IEnumerable<Coordinate> GetIntersectionPoints(Rectangle rect)
        {
            List<Coordinate> intersectionPoints = new();
            if (Intersects(rect))
            {
                foreach (var horizontalLine in GetHorizontalLines())
                {
                    foreach (var verticalLine in rect.GetVerticalLines())
                    {
                        var coordinate = GetIntersectionPoint(horizontalLine, verticalLine);
                        if (coordinate != null)
                        {
                            intersectionPoints.Add(coordinate);
                        }
                    }
                }
                foreach (var verticalLine in GetVerticalLines())
                {
                    foreach (var horizontalLine in rect.GetHorizontalLines())
                    {
                        var coordinate = GetIntersectionPoint(horizontalLine, verticalLine);
                        if (coordinate != null)
                        {
                            intersectionPoints.Add(coordinate);
                        }
                    }
                }
            }

            return intersectionPoints.Distinct();
        }

        internal Line[] GetLines()
        {
            return new Line[]
            {
                new Line(Corner1, Corner2, PositionType.Horizontal),
                new Line(Corner3, Corner4, PositionType.Horizontal),
                new Line(Corner1, Corner4, PositionType.Vertical),
                new Line(Corner2, Corner3, PositionType.Vertical)
            };
        }

        internal Line[] GetHorizontalLines()
        {
            return GetLines().Where(l=> l.Position == PositionType.Horizontal).ToArray();
        }

        internal Line[] GetVerticalLines()
        {
            return GetLines().Where(l => l.Position == PositionType.Vertical).ToArray();
        }

        private (int x1, int x2) GetSortedRange(int value1, int value2)
        {
            if (value1 <= value2)
            {
                return (value1, value2);
            }
            else
            {
                return (value2, value1);
            }
        }

        private bool IsInRange(int value1, int value2, int innerValue1, int innerValue2)
        {
            return
                (value1 >= innerValue1 && value1 <= innerValue2) ||
                (value2 >= innerValue1 && value2 <= innerValue2) ||
                (innerValue1 >= value1 && innerValue1 <= value2) ||
                (innerValue2 >= value1 && innerValue2 <= value2);
        }

        private bool IsInRangeY(Rectangle rect)
        {
            (int y1, int y2) = GetSortedRange(rect.Corner1.Y, rect.Corner3.Y);
            (int innerY1, int innerY2) = GetSortedRange(Corner1.Y, Corner3.Y);

            return IsInRange(y1, y2, innerY1, innerY2);
        }

        private bool IsInRangeX(Rectangle rect)
        {
            (int innerX1, int innerX2) = GetSortedRange(Corner1.X, Corner3.X);
            (int x1, int x2) = GetSortedRange(rect.Corner1.X, rect.Corner3.X);

            return IsInRange(x1, x2, innerX1, innerX2);
        }

        private Coordinate? GetIntersectionPoint(Line horizontalLine, Line verticalLine)
        {
            (int x1, int x2) = GetSortedRange(horizontalLine.Point1.X, horizontalLine.Point2.X);
            (int y1, int y2) = GetSortedRange(verticalLine.Point1.Y, verticalLine.Point2.Y);

            int? x = (verticalLine.Point1.X >= x1 && verticalLine.Point1.X <= x2) ?
                verticalLine.Point1.X : null;

            int? y = (horizontalLine.Point1.Y >= y1 && horizontalLine.Point1.X <= y2) ?
                horizontalLine.Point1.Y : null;
            return (x.HasValue && y.HasValue) ? new Coordinate(x.Value, y.Value) : default;
        }
    }
}

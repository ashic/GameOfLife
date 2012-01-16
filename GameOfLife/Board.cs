using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GameOfLife
{
    public class Board : ViewModelBase
    {
        readonly BoardPoint[][] _points;

        public IEnumerable<BoardPoint> Points
        {
            get { return _points.SelectMany(x => x); }
        }

        int _width;
        public int Width
        {
            get { return _width; }
            set { _width = value; NotifyPropertyChanged(()=> Width); }
        }

        public int PixelSize
        {
            get { return (Width/(_points[0].Length + 1)); }
        }

        public Board():this(40, 35, 800)
        {
        }

        public Board(int width, int height, int boardPixelWidth)
        {
            _width = boardPixelWidth;

            _points = new BoardPoint[height][];
            for (int i = 0; i < height; i++)
            {
                _points[i] = new BoardPoint[width];
                for(int j=0; j<width; j++)
                    _points[i][j] = new BoardPoint();
            }
        }
    }
}
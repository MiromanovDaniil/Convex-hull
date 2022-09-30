using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace CG_6
{
    public partial class Form : System.Windows.Forms.Form
    {
        List<Point> points = new List<Point> {};
        List<Point> Convex_points = new List<Point> {};
        public Form()
        {
            InitializeComponent();
            set_settings();
            set_visible_coordinates();
        }
        string zedGraph_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            // Получим точку, около которой находимся
            PointPair point = curve[iPt];

            // Сформируем строку
            string result = string.Format("X: {0:F3}\nY: {1:F3}", point.X, point.Y);

            return result;
        }
        private void set_visible_coordinates()
        {
            // Включим показ всплывающих подсказок при наведении курсора на график
            zedGraph.IsShowPointValues = true;

            // Будем обрабатывать событие PointValueEvent, чтобы изменить формат представления координат
            zedGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraph_PointValueEvent);
        }
        private void set_settings()
        {
            GraphPane pane = zedGraph.GraphPane;

            zedGraph.PanButtons = MouseButtons.Left;
            zedGraph.PanModifierKeys = Keys.None;

            // Ось X будет пересекаться с осью Y на уровне Y = 0
            pane.XAxis.Cross = 0.0;

            // Ось Y будет пересекаться с осью X на уровне X = 0
            pane.YAxis.Cross = 0.0;

            // Отключим отображение первых и последних меток по осям
            pane.XAxis.Scale.IsSkipFirstLabel = true;
            pane.XAxis.Scale.IsSkipLastLabel = true;

            // Отключим отображение меток в точке пересечения с другой осью
            pane.XAxis.Scale.IsSkipCrossLabel = true;


            // Отключим отображение первых и последних меток по осям
            pane.YAxis.Scale.IsSkipFirstLabel = true;

            // Отключим отображение меток в точке пересечения с другой осью
            pane.YAxis.Scale.IsSkipLastLabel = true;
            pane.YAxis.Scale.IsSkipCrossLabel = true;

            // Спрячем заголовки осей
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;

            pane.Title.Text = "Computer Graphics convex hull";

            // Добавляю линии сетки на график и делаю их серыми
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.Color = Color.Gray;
            pane.YAxis.MajorGrid.Color = Color.Gray;

            double xmin_limit = -15;
            double xmax_limit = 15;

            double ymin_limit = -15;
            double ymax_limit = 15;

            // Устанавливаем интервал по оси X
            pane.XAxis.Scale.Min = xmin_limit;
            pane.XAxis.Scale.Max = xmax_limit;

            // !!!
            // Устанавливаем интервал по оси Y
            pane.YAxis.Scale.Min = ymin_limit;
            pane.YAxis.Scale.Max = ymax_limit;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }
        private void start_scale_Click(object sender, EventArgs e)
        {
            GraphPane pane = zedGraph.GraphPane;

            // Set the default scale for the x-axis
            pane.XAxis.Scale.Min = -15;
            pane.XAxis.Scale.Max = 15;

            // Set the default scale for the y-axis
            pane.YAxis.Scale.Min = -15;
            pane.YAxis.Scale.Max = 15;

            // Updating Axes Data
            zedGraph.AxisChange();

            // Update graph
            zedGraph.Invalidate();
        }
        private void draw()
        {
            GraphPane myPane = zedGraph.GraphPane;

            // cleaning graph
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            // output dots
            PointPairList pointsList = new PointPairList();
            for (int i = 0; i < points.Count; i++)
            {
                pointsList.Add(points[i].x, points[i].y);
            }
            LineItem myCurve = myPane.AddCurve("Scatter", pointsList, Color.Blue, SymbolType.Circle);
            // line hidden
            myCurve.Line.IsVisible = false;
            // color - blue
            myCurve.Symbol.Fill.Color = Color.Blue;
            // Fill type - solid fill
            myCurve.Symbol.Fill.Type = FillType.Solid;
            // Hide graph legend
            myPane.Legend.IsVisible = false;
            // Update graph
            zedGraph.Invalidate();
        }
        private int Find_Side(Point p1, Point p2, Point p)
        {
            double f = (p.y - p1.y) * (p2.x - p1.x) - (p2.y - p1.y) * (p.x - p1.x);

            if (f > 0)
            {
                return 1;
            }
            if (f < 0)
            {
                return -1;
            }
            return 0;
        }
        private double Line_Dist(Point p1, Point p2, Point p)
        {
            return Math.Abs((p.y - p1.y) * (p2.x - p1.x) - (p2.y - p1.y) * (p.x - p1.x));
        }
        private void quick_Hull(List<Point> a, int n, Point p1, Point p2, int side)
        {
            int ind = -1;
            double max_dist = 0;

            for (int i = 0; i < n; i++)
            {
                double temp = Line_Dist(p1, p2, a[i]);
                if (Find_Side(p1, p2, a[i]) == side && temp > max_dist)
                {
                    ind = i;
                    max_dist = temp;
                }
            }

           GraphPane myPane = zedGraph.GraphPane;

            if (ind != -1)
            {
                MessageBox.Show("Step");
                zedGraph.Invalidate();
                myPane.GraphObjList.Add(new LineObj(Color.Red, p1.x, p1.y, p2.x, p2.y));
            }

            // If no point is found, add the end points to the convex hull
            if (ind == -1)
            {
                MessageBox.Show("Step");
                zedGraph.Invalidate();

                myPane.GraphObjList.Add(new LineObj(Color.Red, p1.x, p1.y, p2.x, p2.y));

                Convex_points.Add(p1);
                Convex_points.Add(p2);

                return;
            }
            
            quick_Hull(a, n, a[ind], p1, -Find_Side(a[ind], p1, p2)); //
            quick_Hull(a, n, a[ind], p2, -Find_Side(a[ind], p2, p1)); //
        }
        private void Divide_and_Conquer_Click(object sender, EventArgs e)
        {
            if (points.Count() < 2)
            {
                Convex_points.Add(points[0]);
                return;
            }

            int min_x = 0;
            int max_x = 0;
            for (int i = 0; i < points.Count(); i++)
            {
                if (points[i].x < points[min_x].x)
                {
                    min_x = i;
                }
                if (points[i].x > points[max_x].x)
                {
                    max_x = i;
                }
            }
            //points.Sort((a, b) => a.x.CompareTo(b.x));

            ////add x_max and x_min dots to the convex hull
            //Convex_points.Add(points[0]);
            //Convex_points.Add(points[points.Count() - 1]);

            //points.RemoveAt(0);
            //points.RemoveAt(points.Count() - 1);

            quick_Hull(points, points.Count(), points[min_x], points[max_x], 1);
            quick_Hull(points, points.Count(), points[min_x], points[max_x], -1);

            GraphPane myPane = zedGraph.GraphPane;
            myPane.GraphObjList.Clear();
            //draw convex hull
            for (int i = 0; i < Convex_points.Count - 1; i+=2)
            {
                LineObj line = new LineObj(Color.Red, Convex_points[i].x, Convex_points[i].y, Convex_points[i + 1].x, Convex_points[i + 1].y);
                myPane.GraphObjList.Add(line);
            }
            Convex_points.Clear();
            // Update graph
            zedGraph.Invalidate();
        }
        private void Cleaning_Click(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraph.GraphPane;

            points.Clear();
            Convex_points.Clear();
            // cleaning graph

            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            // Updating Axes Data
            zedGraph.AxisChange();

            // Update graph
            zedGraph.Invalidate();
        }
        private void zedGraph_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double x, y;
            // Use the current mouse locations to get the corresponding 
            zedGraph.GraphPane.ReverseTransform(e.Location, out x, out y);
            DialogResult result = MessageBox.Show($"x = {x}, y = {y}", "You choise:", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                points.Add(new Point(x, y));
                draw();
            }
        }
    }
}

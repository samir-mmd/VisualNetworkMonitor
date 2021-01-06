using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using VNM2020.Messaging;
using VNM2020.Models;

namespace VNM2020.Services
{
    class DragEngine
    {
        public readonly TranslateTransform Transform = new TranslateTransform();        
        private Point _hostStartPosition;
        private Point _mouseStartPosition;
        private static DragEngine _instance = new DragEngine();

        private static bool MovingHost = false;

        private static bool MovingMap = false;

        public static DragEngine Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public static bool GetDrag(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragProperty);
        }

        public static void SetDrag(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragProperty, value);
        }

        public static readonly DependencyProperty IsDragProperty =
          DependencyProperty.RegisterAttached("Drag",
          typeof(bool), typeof(DragEngine),
          new PropertyMetadata(false, OnDragChanged));

        private static void OnDragChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var element = (UIElement)sender;
            var isDrag = (bool)(e.NewValue);

            Instance = new DragEngine();
            ((UIElement)sender).RenderTransform = Instance.Transform;

            if (isDrag)
            {
                element.MouseLeftButtonDown += Instance.ElementOnMouseLeftButtonDown;
                element.MouseLeftButtonUp += Instance.ElementOnMouseLeftButtonUp;
                element.MouseMove += Instance.ElementOnMouseMove;
                element.MouseWheel += Instance.MapScrollUp;
            }
            else
            {
                element.MouseLeftButtonDown -= Instance.ElementOnMouseLeftButtonDown;
                element.MouseLeftButtonUp -= Instance.ElementOnMouseLeftButtonUp;
                element.MouseMove -= Instance.ElementOnMouseMove;
                element.MouseWheel -= Instance.MapScrollUp;
            }
        }

        private void ElementOnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (((Canvas)sender).Name == "HostCanvas")
            {
                MovingHost = true;
            }
            else if (((Canvas)sender).Name == "MapCanvas" && !MovingHost)
            {
                MovingMap = true;
                diffPoint = new Point(((ScrollContentPresenter)((UIElement)sender).GetParentObject()).HorizontalOffset, ((ScrollContentPresenter)((UIElement)sender).GetParentObject()).VerticalOffset);
            }
            var parent = Application.Current.Windows[1];
            _mouseStartPosition = mouseButtonEventArgs.GetPosition(parent);

            ((Canvas)sender).CaptureMouse();
        }

        private void ElementOnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            ((UIElement)sender).ReleaseMouseCapture();

            lastX = 0;
            lastY = 0;
            difY = 0;
            difX = 0;
            if (!MovingMap)
            {
                _hostStartPosition.X = 0;
                _hostStartPosition.Y = 0;
            }           
            MovingHost = false;
            MovingMap = false;
            if (hostmoved)
            {
            Core.Instance.UpdateHost(Core.Instance.selected);
            }
            hostmoved = false;
        }

        bool hostmoved = false;
        double lastX = 0;
        double difX = 0;
        double lastY = 0;
        double difY = 0;
        Point diffPoint = new Point();

        private void ElementOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {

            if (!((UIElement)sender).IsMouseCaptured) return;
            var parent = Application.Current.Windows[1];
            var mousePos = mouseEventArgs.GetPosition(parent);
            var diff = (mousePos - _mouseStartPosition);
            if (MovingHost)
            {
                
                difX = _hostStartPosition.X + (diff.X / GlobalSettings.Instance.mapzoom) - lastX;
                lastX = _hostStartPosition.X + (diff.X / GlobalSettings.Instance.mapzoom);

                difY = _hostStartPosition.Y + (diff.Y / GlobalSettings.Instance.mapzoom) - lastY;
                lastY = _hostStartPosition.Y + (diff.Y / GlobalSettings.Instance.mapzoom);

                if (difX + difY != 0)
                {
                    hostmoved = true;
                }

                MoveMessage move = new MoveMessage();
                move.Col = difX;
                move.Row = difY;
                Messenger.Default.Send(move);
            }
            else if (MovingMap)
            {                
                var scrollViewer = Application.Current.Windows[1].FindChild<ScrollViewer>("MapViewer");
                scrollViewer.ScrollToHorizontalOffset(-diff.X + diffPoint.X);
                scrollViewer.ScrollToVerticalOffset(-diff.Y + diffPoint.Y);
            }
        }

        public void MapScrollUp(object sender, MouseWheelEventArgs mouseEventArgs)
        {            
            MoveMessage move = new MoveMessage();
            move.Zoom = mouseEventArgs.Delta;
            Messenger.Default.Send(move);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppLessonWPF17_Color
{
    /// <summary>
    /// Логика взаимодействия для ColorRGBSlider.xaml
    /// </summary>
    public partial class ColorRGBSlider : UserControl
    {
        public static readonly DependencyProperty ColorColorRGBSliderProperty;
        public static readonly DependencyProperty RColorRGBSliderProperty;
        public static readonly DependencyProperty GColorRGBSliderProperty;
        public static readonly DependencyProperty BColorRGBSliderProperty;

        private static readonly RoutedEvent ColorChangedColorRGBSliderEvent;

        static ColorRGBSlider()
        {
            ColorColorRGBSliderProperty = DependencyProperty.Register(
                nameof(ColorColorRGBSlider),
                typeof(Color),
                typeof(ColorRGBSlider),
                new FrameworkPropertyMetadata(Colors.Black,
                    new PropertyChangedCallback (OnColorChanged))
                );
            RColorRGBSliderProperty = DependencyProperty.Register(
                nameof(RColorRGBSlider),
                typeof(byte),
                typeof(ColorRGBSlider),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBChanged)
                    ));
            GColorRGBSliderProperty = DependencyProperty.Register(
                nameof(GColorRGBSlider),
                typeof(byte),
                typeof(ColorRGBSlider),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBChanged)
                    ));
            BColorRGBSliderProperty = DependencyProperty.Register(
                nameof(BColorRGBSlider),
                typeof(byte),
                typeof(ColorRGBSlider),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBChanged)
                    ));

            ColorChangedColorRGBSliderEvent = EventManager.RegisterRoutedEvent(
                nameof(ColorChangedColorRGBSlider),
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>),
                typeof(ColorRGBSlider)
                );
        }

        public event RoutedPropertyChangedEventHandler<Color> ColorChangedColorRGBSlider
        {
            add { AddHandler(ColorChangedColorRGBSliderEvent, value); }
            remove { RemoveHandler(ColorChangedColorRGBSliderEvent, value); }
        }

        public Color ColorColorRGBSlider
        {
            get { return (Color)GetValue(ColorColorRGBSliderProperty); }
            set { SetValue(ColorColorRGBSliderProperty, value); }
        }
        public byte RColorRGBSlider
        {
            get { return (byte)GetValue(RColorRGBSliderProperty); }
            set { SetValue(RColorRGBSliderProperty, value); }
        }
        public byte GColorRGBSlider
        {
            get { return (byte)GetValue(GColorRGBSliderProperty); }
            set { SetValue(GColorRGBSliderProperty, value); }
        }
        public byte BColorRGBSlider
        {
            get { return (byte)GetValue(BColorRGBSliderProperty); }
            set { SetValue(BColorRGBSliderProperty, value); }
        }


        private static void OnColorChanged(DependencyObject sender, 
            DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            ColorRGBSlider colorRGBSlider = (ColorRGBSlider)sender;
            colorRGBSlider.RColorRGBSlider = newColor.R;
            colorRGBSlider.GColorRGBSlider = newColor.G;
            colorRGBSlider.BColorRGBSlider = newColor.B;
            RoutedPropertyChangedEventArgs<Color> args =
                new RoutedPropertyChangedEventArgs<Color>(
                    colorRGBSlider.ColorColorRGBSlider, newColor);
            args.RoutedEvent = ColorChangedColorRGBSliderEvent;
            colorRGBSlider.RaiseEvent(args);
        }


        private static void OnColorRGBChanged(DependencyObject sender, 
            DependencyPropertyChangedEventArgs e)
        {
            ColorRGBSlider colorRGBSlider = (ColorRGBSlider)sender;
            Color color = colorRGBSlider.ColorColorRGBSlider;
            if (e.Property == RColorRGBSliderProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GColorRGBSliderProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BColorRGBSliderProperty)
                color.B = (byte)e.NewValue;
            colorRGBSlider.ColorColorRGBSlider = color;
        }


        public ColorRGBSlider()
        {
            InitializeComponent();
        }
    }
}

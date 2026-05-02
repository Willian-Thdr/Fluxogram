using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Fluxogram.Core.Services;

public class MenuButtonFunc
{
    public MenuButtonFunc(Button button, Canvas canvas, List<Canvas>? canva2, bool checker, string txt, ColumnDefinition column, double from, double to, int durationMs = 300)
    {
        int fps = 60;
        int interval = 1000 / fps;
        int elapsed = 0;

        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(interval)
        };

        DoubleAnimation animation = new DoubleAnimation
        {
            From = from,
            To = to,
            Duration = TimeSpan.FromMilliseconds(durationMs),
            EasingFunction = new CubicEase
            {
                EasingMode = EasingMode.EaseInOut
            }
        };

        timer.Tick += (s, e) =>
        {
            elapsed += interval;

            double progress = Math.Min((double)elapsed / durationMs, 1);

            double value = from + (to - from) * progress;

            column.Width = new GridLength(value);

            button.Content = txt;

            if (progress >= 1)
            {
                timer.Stop();
                column.Width = new GridLength(to);
                AbrirMenu AM = new AbrirMenu();
                AM.Function(canvas, checker);

                if (canva2 != null)
                {
                    foreach (Canvas canva in canva2)
                    {
                        AbrirMenuSubTabs AMST = new AbrirMenuSubTabs();
                        AMST.Function(canva, checker);
                    }
                }
            }
        };

        timer.Start();
    }
}
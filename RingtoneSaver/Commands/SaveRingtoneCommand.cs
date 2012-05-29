using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using RingtoneSaver.Infrastructure.Media;

namespace RingtoneSaver.Commands
{
    public class SaveRingtoneCommand : CommandBase<string>
    {
        public override void Execute(string url)
        {
            MediaService.SaveRingtone(new Uri(url));
        }
    }
}

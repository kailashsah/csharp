using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BehaviorScrollBar
{
    public class TextChangeBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            TextBox txtBox = AssociatedObject as TextBox;
            txtBox.TextChanged += txt_TextChanged;
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                txtBox.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                txtBox.Background = new SolidColorBrush(Colors.Red);
            }

        }
        void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = AssociatedObject as TextBox;
            txtBox.TextChanged += txt_TextChanged;
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                txtBox.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                txtBox.Background = new SolidColorBrush(Colors.Red);
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            TextBox txtBox = AssociatedObject as TextBox;
            txtBox.TextChanged -= txt_TextChanged;

        }
    }
}

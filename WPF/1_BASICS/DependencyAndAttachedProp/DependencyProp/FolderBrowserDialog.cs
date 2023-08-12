using System;

namespace usercontrol_text
{
    internal class FolderBrowserDialog
    {
        public FolderBrowserDialog()
        {
        }

        public string SelectedPath { get; internal set; }

        internal object ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}
using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfMemo
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // 保存した内容をファイルに保存
        private string saveFileName = @"memo.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // ファイルがあれば起動時に開く
            if (!File.Exists(saveFileName))
            {
                return;
            }
            StreamReader sr = new StreamReader(saveFileName, Encoding.GetEncoding("Shift_JIS"));
            textboxMemo.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // 保存用ダイアログを開く
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.FileName = saveFileName;
            if (saveFileDialog1.ShowDialog() == true)
            {
                System.IO.Stream stream;
                stream = saveFileDialog1.OpenFile();
                if (stream != null)
                {
                    // ファイルに書き込む
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(stream);
                    sw.Write(textboxMemo.Text);
                    sw.Close();
                    stream.Close();

                }
            }
        }

        private void checkboxLock_Click(object sender, RoutedEventArgs e)
        {
            textboxMemo.IsReadOnly = checkboxLock.IsChecked.Value;
        }

        
    }
}

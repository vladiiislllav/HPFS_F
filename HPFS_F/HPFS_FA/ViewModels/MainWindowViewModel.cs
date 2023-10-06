using System;
using Avalonia.Interactivity;
using HPFS_FA.Views;
using ReactiveUI;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Avalonia.Controls.Templates;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;

namespace HPFS_FA.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        //GGGGG
        [Reactive] public string login { get; set; }
        [Reactive] public string surname { get; set; }
        [Reactive] public string group { get; set; }

        public void Reg_window()
        {
            var windowReg = new Registration();
            var windowMain = new MainWindow();

            windowReg.Show();
            windowMain.Hide();
            //Не скрывается окно windowMain
        }


        public void Reg_user()
        {
            
            string path = @"C:\Users\Vladislav\source\repos\HPFS_F\HPFS_FA\Users\" + login + " " + surname + " " + group;
            DirectoryInfo dirinfo = new DirectoryInfo(path);

            if (!dirinfo.Exists)
            { 
                dirinfo.Create();  
            }

            Pathname();

            var windowReg = new Registration();
            windowReg.Hide();

        }

        //public void PathUser(){}

        [Reactive] public string PathBox { get; set; }

        public ObservableCollection<string> Resultpath = new ObservableCollection<string>();

        public void Pathname()
        {
            ObservableCollection<string> folderss = new ObservableCollection<string>(Directory.GetDirectories(@"C:\Users\Vladislav\source\repos\HPFS_F\HPFS_FA\Users"));

            //Resultpath.Clear();

            foreach (string folder in folderss)
            {
                Resultpath.Add(Path.GetFileName(folder));
                PathBox += Resultpath;
            }

        }

        public void Mywatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\Vladislav\source\repos\HPFS_F\HPFS_FA\Users");
            watcher.EnableRaisingEvents = true;

            watcher.Created += new FileSystemEventHandler(WatcherCreated);
            watcher.Deleted += new FileSystemEventHandler(WatcherDeleted);

            void WatcherCreated(object s, FileSystemEventArgs e) => Pathname();
            void WatcherDeleted(object s, FileSystemEventArgs e) => Pathname();
        }





    }
}
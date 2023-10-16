using System;
using System.Collections.Generic;
using Avalonia.Interactivity;
using HPFS_FA.Views;
using ReactiveUI;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Avalonia.Controls.Templates;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using HPFS_FA.Models;

namespace HPFS_FA.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        [Reactive] public string login { get; set; }   //Это регистрация
        [Reactive] public string surname { get; set; } //Это регистрация
        [Reactive] public string group { get; set; }   //Это регистрация
        [Reactive] public string ResultTextPath { get; set; } //Строка - результат в окне Program
        [Reactive] public ObservableCollection<string> PathBox { get; set; } //Содержимое листбокса

        public ObservableCollection<string> Resultpath = new ObservableCollection<string>();

        //  public List<string> PathBox = new List<string>();

      //  private MainWindow _windowMain = new MainWindow(); //тест

        private Registration _windowReg; //тест


        //  [Reactive] public string PathBox { get; set; }

        public MainWindowViewModel()
        {
            //  MainWindow windowMain = new MainWindow();
            // Registration windowReg = new Registration();
            // ProgT windowProg = new ProgT();

            

            Pathname();
           
           //Resultpath = new ObservableCollection<string>();

        }


        /*
        private MainWindow windowMain = new MainWindow();

        private Registration windowReg = new Registration();

        private ProgT windowProg = new ProgT();*/

        public void Reg_window()
        {
            _windowReg = new Registration();
            _windowReg.DataContext = this;
            _windowReg.Show();
            
        }

        public void Reg_user()
        {
            
            string path = @"Test\" + login + " " + surname + " " + group;
            DirectoryInfo dirinfo = new DirectoryInfo(path);

            if (!dirinfo.Exists)
            { 
                dirinfo.Create();  
            }

            Pathname();

           _windowReg.Close();

        }

        //public void PathUser(){}

        

         

        public void Pathname()
        {
            ////ObservableCollection<string> folderss = new ObservableCollection<string>(Directory.GetDirectories(@"C:\Users\Vladislav\Documents\GitHub\HPFS_F\HPFS_F\HPFS_FA\Users"));

            ////Resultpath.Clear();

            //foreach (string folder in folderss)
            //{
            //    Resultpath.Add(Path.GetFileName(folder)); 
                
            //}

            //PathBox = Resultpath; //Не заполняется PathBox папками

            
        }

        public void Mywatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\Vladislav\Documents\GitHub\HPFS_F\HPFS_F\HPFS_FA\Users\");
            watcher.EnableRaisingEvents = true;

            watcher.Created += new FileSystemEventHandler(WatcherCreated);
            watcher.Deleted += new FileSystemEventHandler(WatcherDeleted);

            void WatcherCreated(object s, FileSystemEventArgs e) => Pathname();
            void WatcherDeleted(object s, FileSystemEventArgs e) => Pathname();
        }

        [Reactive] public string login_prog { get; set; }

        public void access_prog()
        {
            foreach (string fullNameUserPath in Resultpath)
            {
                if (fullNameUserPath.Contains(login_prog))
                {
                    DataText.Datatextpth += fullNameUserPath; //Как передать данные в переменную?
                }
            }

        //  windowProg.Show();

        }

        //Program

        //Каким образом прописать загрузку окна?

        [Reactive] public string path_str { get; set; }

        public void Button_Test()
        {



        }



    }
}
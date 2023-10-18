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
using Avalonia.Controls;
using HPFS_FA.Models;

namespace HPFS_FA.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string PathLink = @"C:\\Users\\Vladislav\\Documents\\GitHub\\HPFS_F\\HPFS_F\\HPFS_FA\\Users\\"; //Ссылка на папку (путь до папки)!

        [Reactive] public string Login { get; set; }   //Это регистрация
        [Reactive] public string Surname { get; set; } //Это регистрация
        [Reactive] public string Group { get; set; }   //Это регистрация
        [Reactive] public string ResultTextPath { get; set; } //Строка - результат в окне Program
        [Reactive] public ObservableCollection<string> PathBox { get; set; } //Содержимое листбокса
        [Reactive] public string path_str { get; set; }
        [Reactive] public string test { get; set; }


        public ObservableCollection<string> Resultpath = new ObservableCollection<string>();

        //  public List<string> PathBox = new List<string>();
        //  private MainWindow _windowMain = new MainWindow(); //тест

        private Registration _windowReg; //тест

        private WorkWindow _windowProgram;


        //  [Reactive] public string PathBox { get; set; }

        public MainWindowViewModel()
        {
            //  MainWindow windowMain = new MainWindow();
            // Registration windowReg = new Registration();
            // ProgT windowProg = new ProgT();

            Pathname();
           

        }

        public void Reg_window()
        {
            _windowReg = new Registration();
            _windowReg.DataContext = this;
            _windowReg.Show();
            
        }

        public void Reg_user()
        {
            
            string path = PathLink + Login + " " + Surname + " " + Group;
            DirectoryInfo dirinfo = new DirectoryInfo(path);

            if (!dirinfo.Exists)
            { 
                dirinfo.Create();  
            }

            Pathname();
            
            Login = string.Empty;
            Surname = string.Empty;
            Group = string.Empty;
            
           _windowReg.Close();

        }

        //public void PathUser(){}

        

         

        public void Pathname()
        {
            ObservableCollection<string> folderss = new ObservableCollection<string>(Directory.GetDirectories(PathLink));

            Resultpath.Clear();

            foreach (string folder in folderss)
            {
                Resultpath.Add(Path.GetFileName(folder)); 
                
            }

            PathBox = Resultpath;
        }



        /*public void Mywatcher()
        {
           FileSystemWatcher watcher = new FileSystemWatcher(@"");
           watcher.EnableRaisingEvents = true;

           watcher.Created += new FileSystemEventHandler(WatcherCreated);
           watcher.Deleted += new FileSystemEventHandler(WatcherDeleted);
           void WatcherCreated(object s, FileSystemEventArgs e) => Pathname();
           void WatcherDeleted(object s, FileSystemEventArgs e) => Pathname();
        }*/



        [Reactive] public string login_prog { get; set; }

        public void access_prog()
        {
            

            _windowProgram = new WorkWindow();
            _windowProgram.DataContext = this;

            foreach (string fullNameUserPath in PathBox)
            {
                if (fullNameUserPath.Contains(login_prog))
                {
                    path_str = fullNameUserPath; //Как передать данные в переменную?
                    
                }
            }

            login_prog = string.Empty;
            _windowProgram.Show();

        }


        

        public void Button_Test()
        {


        }

        public void Button_Exit()
        {
            //path_str = string.Empty;
            //login_prog = string.Empty;
            _windowProgram.Close();
        }


    }
}
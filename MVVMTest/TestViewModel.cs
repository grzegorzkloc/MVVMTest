using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;

namespace MVVMTest
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private int _counter;
        private string _myText;
        private string _changer;

        public int Counter
        {
            get { return _counter; }
            set
            {
                if (value != _counter)
                {
                    _counter = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MyText
        {
            get { return _myText; }
            set
            {
                if (value != _myText)
                {
                    _myText = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Changer
        {
            get { return _changer; }
            set
            {
                if (value == _changer) return;
                _changer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Photo> Kolekcja;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MyCommand Command { get; set; }

        AutoResetEvent event0 = new AutoResetEvent(false);
        AutoResetEvent event1 = new AutoResetEvent(false);
        AutoResetEvent event2 = new AutoResetEvent(false);
        AutoResetEvent event3 = new AutoResetEvent(false);
        AutoResetEvent event4 = new AutoResetEvent(false);

        public TestViewModel()
        {
            Command = new MyCommand(this);
            Counter = 0;
            Changer = "start ";
            Kolekcja = new ObservableCollection<Photo>();
            InitPhotoArray();
            var KolekcjaPozmianach = Kolekcja.Select(n => n).Where(n => n.id > 5)
            .Where(n => n.title.Contains(" ")).OrderByDescending(n => n.id).Select(n => n.title)
            .ToList();
        }

        public void Increment()
        {
            if (Counter == 4) Counter = 0;
            else Counter++;
        }

        public void SetText(string tekst)
        {
            MyText = tekst;
        }

        public void InitPhotoArray()
        {
            Kolekcja.Add(new Photo(1, "krajobraz"));
            Kolekcja.Add(new Photo(2, "akt"));
            Kolekcja.Add(new Photo(3, "fotka osoby"));
            Kolekcja.Add(new Photo(4, "selfik"));
            Kolekcja.Add(new Photo(5, "satelitarne"));
            Kolekcja.Add(new Photo(6, "selfik kamila"));
            Kolekcja.Add(new Photo(7, "selfik bartka"));
            Kolekcja.Add(new Photo(8, "selfik karoli"));
            Kolekcja.Add(new Photo(9, "selfik rafała"));
            Kolekcja.Add(new Photo(10, "krajobraz"));
            Kolekcja.Add(new Photo(11, "widok z okna"));
            Kolekcja.Add(new Photo(12, "zdjecie dupy"));
        }

        public async void ChangeChanger()
        {
            Task t1 = new Task(this.Work1);
            Task t2 = new Task(this.Work2);
            Task t3 = new Task(this.Work3);
            Task t4 = new Task(this.Work4);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            /*Thread thread1 = new Thread(new ThreadStart(this.Work1));
            Thread thread2 = new Thread(new ThreadStart(this.Work2));
            Thread thread3 = new Thread(new ThreadStart(this.Work3));
            Thread thread4 = new Thread(new ThreadStart(this.Work4));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();*/
        }

        public void Work1()
        {
            Changer = "1 ";
            Thread.Sleep(1000);
            event1.Set();
        }
        public void Work2()
        {
            WaitHandle.WaitAll(new WaitHandle[] { event1 });
            Changer = "2 ";
            Thread.Sleep(1000);

            event2.Set();
        }
        public void Work3()
        {
            WaitHandle.WaitAll(new WaitHandle[] { event2 });
            Changer = "3 ";
            Thread.Sleep(1000);

            event3.Set();
        }
        public void Work4()
        {
            WaitHandle.WaitAll(new WaitHandle[] { event3 });
            Changer = "4 ";
            Thread.Sleep(1000);

            event4.Set();
        }


    }
}

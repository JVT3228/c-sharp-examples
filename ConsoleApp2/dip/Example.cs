using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.dip
{
    internal class Example
    {
        public class SamsungTV
        {
            public string Model { get; set; }
            public int CurrentChannel { get; set; }
            public int Volume { get; set; }

            public SamsungTV(string model)
            {
                Model = model;
                CurrentChannel = 1;
                Volume = 10;
            }

            public void TurnOn()
            {
                Console.WriteLine("SamsungTV " + Model + " включен");
            }

            public void TurnOff()
            {
                Console.WriteLine("SamsungTV " + Model + " выключен");
            }

            public void ChangeChannel(int channel)
            {
                CurrentChannel = channel;
                Console.WriteLine("SamsungTV " + Model + " переключен на канал " + channel);
            }

            public void AdjustVolume(int newVolume)
            {
                Volume = newVolume;
                Console.WriteLine("SamsungTV " + Model + " громкость установлена на " + newVolume);
            }

            public void GetStatus()
            {
                Console.WriteLine("Статус: Модель=" + Model + ", Канал=" + CurrentChannel + ", Громкость=" + Volume);
            }
        }

        public class SamsungTVRemote
        {
            private SamsungTV _tv;

            public SamsungTVRemote(SamsungTV tv)
            {
                _tv = tv;
            }

            public void RemoteTurnOn()
            {
                _tv.TurnOn();
            }

            public void RemoteTurnOff()
            {
                _tv.TurnOff();
            }

            public void RemoteSetChannel(int channel)
            {
                _tv.ChangeChannel(channel);
            }

            public void RemoteVolumeUp() 
            {
                _tv.AdjustVolume(_tv.Volume + 1);
            }

            public void RemoteVolumeDown()
            {
                _tv.AdjustVolume(_tv.Volume - 1);
            }
        }

        public class PhilipsTV
        {
            public string Model { get; set; }
            public int CurrentChannel { get; set; }
            private int _volume;
            public int Volume
            {
                get { return _volume; }
                set
                {
                    if (value < 0)
                    {
                        _volume = 0;
                    }
                    if (value > 100)
                    {
                        _volume = 100;
                    }
                    _volume = value;
                 }
            }

            public PhilipsTV(string model)
            {
                Model = model;
                CurrentChannel = 0;
                Volume = 50;
            }

            public void On()
            {
                Console.WriteLine("PhilipsTV " + Model + " включен");
            }

            public void Off()
            {
                Console.WriteLine("PhilipsTV " + Model + " выключен");
            }

            public void ChangeChannel(int channel)
            {
                CurrentChannel = channel;
                Console.WriteLine("PhilipsTV " + Model + " переключен на канал " + channel);
            }

            public void AdjustVolume(int newVolume)
            {
                Volume = newVolume;
                Console.WriteLine("PhilipsTV " + Model + " громкость установлена на " + newVolume);
            }

            public void GetData()
            {
                Console.WriteLine("Интернал инфо: Модель=" + Model + ", Канал=" + CurrentChannel + ", Громкость=" + Volume);
            }
        }
    }

    internal class CoolerExample
    {
        public interface ITv
        {
            void TurningOn();
            void TurningOff();
            void PutChannel(int channel);
            void IncreaseVolume(int newVolume);
            void GetInfo();
        }

        public class SamsungTV
        {
            public string Model { get; set; } // ERROR: Имя свойства могло быть более специфичным
            public int CurrentChannel { get; set; }
            public int Volume { get; set; }

            public SamsungTV(string model)
            {
                Model = model; // ERROR: Нет проверки на null или пустую строку
                CurrentChannel = 1;
                Volume = 10;
            }

            public void TurnOn()
            {
                System.Console.WriteLine($"SamsungTV {Model} включен"); // ERROR: Могло быть использовано форматирование строки для улучшения читаемости
            }

            public void TurnOff()
            {
                System.Console.WriteLine($"SamsungTV {Model} выключен");
            }

            public void ChangeChannel(int channel)
            {
                CurrentChannel = channel;
                System.Console.WriteLine($"SamsungTV {Model} переключен на канал {channel}");
            }

            public void AdjustVolume(int newVolume)
            {
                Volume = newVolume; // ERROR: Нет проверки на допустимый диапазон громкости
                System.Console.WriteLine($"SamsungTV {Model} громкость установлена на {newVolume}");
            }

            public void GetStatus()
            {
                System.Console.WriteLine($"Статус: Модель={Model}, Канал={CurrentChannel}, Громкость={Volume}");
            }
        }

        public class SamsungTVAdapter : ITv
        {
            public SamsungTV TV { get; set; }

            public SamsungTVAdapter(SamsungTV tv)
            {
                TV = tv;
            }

            public void GetInfo()
            {
                TV.GetStatus();
            }

            public void IncreaseVolume(int newVolume)
            {
                TV.AdjustVolume(TV.Volume + newVolume);
            }

            public void PutChannel(int channel)
            {
                TV.ChangeChannel(channel);
            }

            public void TurningOff()
            {
                TV.TurnOff();
            }

            public void TurningOn()
            {
                TV.TurnOn();
            }
        }

        public class UniversalRemote
        {
            private ITv _tv; // Зависимость от абстракции ITv – соблюдение DIP

            public UniversalRemote(ITv tv)
            {
                _tv = tv; // ERROR: Нет проверки на null
            }

            public void TurnOnTv()
            {
                _tv.TurningOn();
            }

            public void TurnOffTv()
            {
                _tv.TurningOff();
            }

            public void SetChannel(int channel)
            {
                _tv.PutChannel(channel);
            }

            public void IncreaseVolume()
            {
                _tv.IncreaseVolume(1);
            }

            public void DecreaseVolume()
            {
                _tv.IncreaseVolume(-1);
            }
        }

    }
}

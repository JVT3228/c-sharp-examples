using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case1
    {
        public class Channel
        {
            private string _host;
            public Channel(string host)
            {
                this._host = host;
            }

            public void SendMessage(string source, string dest, string message)
            {
                Console.WriteLine($"[SEND {_host}] {source} - {dest}: {message};");
            }
        }

        public class Client
        {
            private Guid _id;
            private string _fullName;
            private Channel _channel;

            public string Name
            {
                get { return _fullName; }
            }

            public Client(Guid id, string fullName, Channel channel)
            {
                _id = id;
                _fullName = fullName;
                _channel = channel;
            }

            public string GetCurrentRenderedState()
            {
                return $"<id>{_id}</id>\n<fullname>{_fullName}</fullname>";
            }

            public void SendMessageToClient(Client dest, string message)
            {
                _channel.SendMessage(Name, dest.Name, message);
            }
        }


        #region Котов + Веденский + Супрун
        //using System.Dynamic;
        //using System.Threading.Channels;
        //using System.Xml.Linq;

        //public class Channel
        //{
        //    private string _host;
        //    public Channel(string host)
        //    {
        //        _host = host;
        //    }

        //    public void SendMessage(string source, string dest, string message)
        //    {
        //        Console.WriteLine($"[SEND {_host}] {source} - {dest}: {message};");
        //    }
        //}

        //public class Client
        //{
        //    private Guid _id;
        //    private string _fullName;
        //    private Channel _channel;

        //    public string Name
        //    {
        //        get { return _fullName; }
        //    }

        //    public Client(Guid id, string fullName, Channel channel)
        //    {
        //        _id = id;
        //        _fullName = fullName;
        //        _channel = channel;
        //    }

        //    public string GetCurrentRenderedState()
        //    {
        //        return $"<id>{_id}</id>\n<fullname>{_fullName}</fullname>";
        //    }
        //}


        //public class Dialogue
        //{
        //    Client sender;
        //    Client reciever;
        //    Channel channel;

        //    public Dialogue()
        //    {
        //        //
        //    }
        //    public void SendMessage(string message)
        //    {
        //        channel.SendMessage(sender.Name, reciever.Name, message);
        //    }
        //}
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2.isp
{
    internal class Example
    {
        private interface IUser
        {
            void BanUser();
            void PrintComment(int postId, string comment);
            void ReadComments(int postId);
            void PostPost(string content);
            void EditPost(int postId, string content);
            void ReadPost(int postId);
        }

        private class Client : IUser
        {
            public string UserName { get; set; }
            public Client(string name)
            {
                UserName = name;
            }
            public void BanUser()
            { }

            public void EditPost(int postId, string content)
            {
                if (postId == 0)
                {
                    Console.WriteLine($"изменен пост 0 с контентом {content}");
                }
            }

            public void PostPost(string content)
            {
                throw new NotImplementedException();
            }

            public void PrintComment(int postId, string comment)
            {
                Console.WriteLine($"ок, пост: {postId}, комм: {comment}");
            }

            public void ReadComments(int postId)
            {
                Console.WriteLine("тут нет ничего, кроме обсуждения крутых кракозябр");
            }

            public void ReadPost(int postId)
            {
                Console.WriteLine("Пост " + postId);
            }
        }

        private class Admin : IUser
        {
            public void BanUser()
            {
                Console.WriteLine("BAN");
            }

            public void EditPost(int postId, string content)
            {
                Console.WriteLine($"изменен пост 0 с контентом {content}");
            }

            public void PostPost(string content)
            {
                Console.WriteLine($"ок, пост: {new Random().Next(10)}, контент: {content}");
            }

            public void PrintComment(int postId, string comment)
            {
                Console.WriteLine($"тебе нельзя");
                throw new Exception("ОШИБКА С ПРАВАМИ АДМИНА");
            }

            public void ReadComments(int postId)
            {
                Console.WriteLine("тут нет ничего, кроме обсуждения крутых кракозябр");
            }

            public void ReadPost(int postId)
            {
                Console.WriteLine("Пост " + postId);
            }
        }
    }

    internal class CoolerExample
    {
        private interface IUser
        {
            void ReadComments(int postId);
            void ReadPost(int postId);
        }
        private interface ICommenter
        {
            void PrintComment(int postId, string comment);
        }
        private interface ImPoster
        {
            void PostPost(string content);
        }
        private interface IPostEditor
        {
            void EditPost(int postId, string content);
        }
        private interface IAdmin
        {
            void BanUser();
        }

        private class Client : IUser, IPostEditor, ICommenter
        {
            public string UserName { get; set; }
            public Client(string name)
            {
                UserName = name;
            }
            public void EditPost(int postId, string content)
            {
                if (postId == 0)
                {
                    Console.WriteLine($"изменен пост 0 с контентом {content}");
                }
            }
            public void PrintComment(int postId, string comment)
            {
                Console.WriteLine($"ок, пост: {postId}, комм: {comment}");
            }
            public void ReadComments(int postId)
            {
                Console.WriteLine("тут нет ничего, кроме обсуждения крутых кракозябр");
            }
            public void ReadPost(int postId)
            {
                Console.WriteLine("Пост " + postId);
            }
        }

        private class Admin : IUser, IAdmin, ImPoster, IPostEditor
        {
            public void BanUser()
            {
                Console.WriteLine("BAN");
            }
            public void EditPost(int postId, string content)
            {
                Console.WriteLine($"изменен пост 0 с контентом {content}");
            }
            public void PostPost(string content)
            {
                Console.WriteLine($"ок, пост: {new Random().Next(10)}, контент: {content}");
            }
            public void ReadComments(int postId)
            {
                Console.WriteLine("тут нет ничего, кроме обсуждения крутых кракозябр");
            }
            public void ReadPost(int postId)
            {
                Console.WriteLine("Пост " + postId);
            }
        }
    }
}

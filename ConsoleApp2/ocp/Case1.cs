//Здесь класс User совмещал логику хранения данных и отрисовки, что нарушает принцип OCP "закрытости для модификаций", поэтому я вынес логику отрисовки в отдельные классы-декораторы, чтобы можно было добавлять новые виды отрисовки без изменения существующего кода. + удалил не используемые в коде using ы.
using System;
using System.Collections.Generic;

namespace ConsoleApp2.ocp
{
    interface IUserDecorator
    {
        void Decorate(User user);
    }

    class SelectedUserDecorator : IUserDecorator
    {
        public void Decorate(User user) 
        {
            Console.WriteLine("Drawing ellipse around user");
        }
    }

    class ImageUserDecorator : IUserDecorator
    {
        public void Decorate(User user)
        {
            Console.WriteLine("Drawing user image");
        }
    }

    class CoolGuyDecorator : IUserDecorator
    {
        public void Decorate(User user)
        {
            Console.WriteLine("Drawing cool glasses");
        }
    }

    class User
    {
        public bool IsSelected { get; }
        public string Image { get; }

        public User(bool isSelected, string image)
        {
            IsSelected = isSelected;
            Image = image;
        }
    }

    class UserRenderer
    {
        private readonly List<IUserDecorator> _decorators;

        public UserRenderer(IEnumerable<IUserDecorator> decorators)
        {
            _decorators = new List<IUserDecorator>(decorators);
        }

        public void DrawUser(User user)
        {
            foreach (var decorator in _decorators)
            {
                decorator.Decorate(user);
            }
        }
    }

    public class App
    {
        static void Main()
        {
            var user = new User(isSelected: true, image: "profile.jpg");
            var decorators = new List<IUserDecorator>
            {
                new SelectedUserDecorator(),
                new ImageUserDecorator(),
                new CoolGuyDecorator()
            };

            var renderer = new UserRenderer(decorators);
            renderer.DrawUser(user);
        }
    }
}

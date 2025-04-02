using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ocp
{
    class Case1
    {
        // 1. Интерфейс для стратегий отрисовки
        public interface IDrawStrategy
        {
            void Draw(User user);
        }

        // 2. Базовый класс пользователя (закрыт для модификаций)
        public class User
        {
            public bool IsSelected { get; }
            public string Image { get; }
            private readonly List<IDrawStrategy> _drawStrategies;

            public User(bool isSelected, string image, List<IDrawStrategy> strategies)
            {
                IsSelected = isSelected;
                Image = image;
                _drawStrategies = strategies; // 3. Внедрение стратегий через конструктор
            }

            public void DrawUser()
            {
                foreach (var strategy in _drawStrategies)
                {
                    strategy.Draw(this); // 4. Делегируем отрисовку стратегиям
                }
            }
        }

        // 5. Конкретные стратегии (открыты для расширения)
        public class SelectionDecorator : IDrawStrategy
        {
            public void Draw(User user)
            {
                if (user.IsSelected) DrawEllipseAroundUser(user);
            }

            private void DrawEllipseAroundUser(User user)
                => Console.WriteLine("Drawing ellipse for selected user");
        }

        public class ImageRenderer : IDrawStrategy
        {
            public void Draw(User user)
            {
                if (!string.IsNullOrEmpty(user.Image))
                    DrawImageOfUser(user);
            }

            private void DrawImageOfUser(User user)
                => Console.WriteLine($"Rendering image: {user.Image}");
        }

        // 6. Стратегия для "крутых" пользователей (отдельный интерфейс)
        public interface ICoolGuyDecorator : IDrawStrategy { }

        public class CoolGuyGlassesDecorator : ICoolGuyDecorator
        {
            public void Draw(User user)
            {
                if (user is ICoolGuy) DrawCoolGuyGlasses(user); // Проверка интерфейса здесь
            }

            private void DrawCoolGuyGlasses(User user)
                => Console.WriteLine("Adding cool glasses for ICoolGuy");
        }

        // 7. Пример интерфейса для "крутых" пользователей
        public interface ICoolGuy { }

        // 8. Пример использования
        public class CoolUser : User, ICoolGuy
        {
            public CoolUser(bool isSelected, string image, List<IDrawStrategy> strategies)
                : base(isSelected, image, strategies) { }
        }
    }
}

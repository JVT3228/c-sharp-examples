using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.lsp
{
    internal class Case2
    {
        public class BankAccount
        {
            public string AccountNumber { get; } = Guid.NewGuid().ToString();
            public double Balance { get; protected set; } // 1. Защищённый сеттер для наследников
            public bool IsFrozen { get; protected set; } // 2. Состояние заморозки в базовом классе

            public virtual void Deposit(double amount)
            {
                if (IsFrozen)
                    throw new InvalidOperationException($"Account {AccountNumber} is frozen");
                
                Balance += amount;
                Console.WriteLine($"Deposited {amount} into account {AccountNumber}");
            }

            public virtual void Withdraw(double amount)
            {
                if (IsFrozen)
                    throw new InvalidOperationException($"Account {AccountNumber} is frozen");
                
                if (Balance < amount)
                    throw new InvalidOperationException("Insufficient funds");
                
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount} from account {AccountNumber}");
            }

            public virtual void Transfer(BankAccount targetAccount, double amount)
            {
                if (targetAccount.IsFrozen)
                    throw new InvalidOperationException($"Target account {targetAccount.AccountNumber} is frozen");
                
                Withdraw(amount); // 3. Использует общую логику с проверкой заморозки
                targetAccount.Deposit(amount);
                Console.WriteLine($"Transferred {amount} from account {AccountNumber} to {targetAccount.AccountNumber}");
            }

            public virtual void Freeze() => IsFrozen = true;
            public virtual void Unfreeze() => IsFrozen = false;

            public virtual string GetAccountInfo() => $"Account: {AccountNumber}, Balance: {Balance}, Frozen: {IsFrozen}";
        }

        // 4. FrozenAccount удалён — логика заморозки теперь в базовом классе
    }
}

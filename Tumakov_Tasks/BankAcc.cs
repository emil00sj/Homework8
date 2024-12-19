using System;
using System.Collections.Generic;
using System.IO;

namespace Tumakov_Tasks
{
    public class BankAccount : IDisposable
    {
        private static int _accountNumberCounter = 1000;
        private readonly int _accountNumber;
        private decimal _balance;
        private AccountType _accountType;
        private Queue<BankTransaction> _transactionQueue;
        public int AccountNumber => _accountNumber;
        public decimal Balance => _balance;
        public AccountType AccountType => _accountType;
        public BankAccount() : this(0, AccountType.Checking) { }
        public BankAccount(decimal initialBalance) : this(initialBalance, AccountType.Checking) { }
        public BankAccount(AccountType type) : this(0, type) { }
        public BankAccount(decimal initialBalance, AccountType type)
        {
            _accountNumber = GetNextAccountNumber();
            _balance = initialBalance;
            _accountType = type;
            _transactionQueue = new Queue<BankTransaction>();
        }
        private static int GetNextAccountNumber() => ++_accountNumberCounter;
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма депозита должна быть положительной.", nameof(amount));
            }
            _balance += amount;
            _transactionQueue.Enqueue(new BankTransaction(amount));
        }
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма снятия должна быть положительной.", nameof(amount));
            }
            if (_balance >= amount)
            {
                _balance -= amount;
                _transactionQueue.Enqueue(new BankTransaction(-amount));
                return true;
            }
            Console.WriteLine("Недостаточно средств!");
            return false;
        }
        public void Dispose()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("transactions.txt", true))
                {
                    while (_transactionQueue.Count > 0)
                    {
                        BankTransaction transaction = _transactionQueue.Dequeue();
                        writer.WriteLine($"{_accountNumber},{transaction.TransactionDate},{transaction.Amount}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
            finally
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}

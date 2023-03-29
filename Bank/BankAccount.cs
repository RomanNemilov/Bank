using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountEqualsZeroMessage = "Credit amount is zero";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // intentionally correct code
        }

        public void Credit(double amount)
        {
            if (amount == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, CreditAmountEqualsZeroMessage);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, CreditAmountLessThanZeroMessage);
            }
            m_balance += amount;
        }
    }
}

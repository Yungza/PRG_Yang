using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    /*2) Vytvoř třídu BankAccount, kterou budeme reprezentovat bankovní účet
 * Přidej třídě BankAccount čtyři proměnné - accountNumber jako číslo účtu
 *                                            - holderName jako jméno osoby, které účet patří
 *                                            - currency jako měna, ve které je účet vedený
 *                                            - balance jako zůstatek na účtu
 * Přidej třídě BankAccount čtyři funkce - Deposit, která jako vstupní parametr přijme množství peněz a vloží je na účet
 *                                          - Withdraw, která jako vstupní parametr přijme množství peněz a z účtu "vybere" peníze, tedy sníží zůstatek a navrátí požadované množství
 * Pokud na účtu není dostatek peněz, uživatele upozorní a vrátí nulu.
 *                                          - Transfer, která jako vstupní parametry přijme množství peněz a číslo účtu, na které se budou peníze posílat, a převede peníze
 * z jednoho účtu na druhý(opět pouze pokud je na účtu, ze kterého převod jde, dostatek peněz)
 * Přidej třídě BankAccount konstruktor, který bude přijímat dva parametry - jméno majitele účtu a měnu, ve které bude účet vedený
 *                                                                            - Při jeho zavolání nastav jméno a měnu podle vstupních parametrů, accountNumber nastav jako náhodně
 * vygenerované číslo velké alespoň 100 000 000 a menší, než 10 000 000 000 a balance nastav na nulu
 */
    internal class BankAccount
    {
        public int accountNumber;
        public string holderName; 
        public string currency; 
        public int balance; 
        public BankAccount name;
        public BankAccount(int accountNumber, string holderName, string currency, int balance)
        {
            this.accountNumber = accountNumber;
            this.holderName = holderName;
            this.currency = currency;
            this.balance = balance;

        }
        public BankAccount(string holderName, string currency)
        {
            this.holderName = holderName;
            this.currency = currency;
            Random rnd = new Random();
            this.accountNumber = rnd.Next(100000000,1000000000);
            this.balance = 0;
        }
        public int Deposit(int amount)
        {
            balance = balance + amount;
            return balance;
        }
        public int Witdhdraw(int amount)
        {
            if (balance < amount)
            {
                Console.WriteLine($"tolik peněz nemáš wole, vybral jsi {balance} peněz");
                return 0;
            }
            balance = balance - amount;
            return balance;
        }
        public int Transfer(int amount, BankAccount human2)
        {
            balance -= amount;
            human2.balance += amount;
            return balance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;

namespace ClassPlayground
{/* 3) Vytvoř třídu Student, kterou budeme reprezentovat studenta
 * Přidej třídě Student proměnné - year pro aktuální ročník studenta
 *                                  - id pro identifikační číslo studenta
 *                                  - subjects pro seznam předmětů studenta(bude to slovník (https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/), který bude mít jako klíč string a jako hodnotu List (https://www.geeksforgeeks.org/c-sharp-list-class/) známek)
 *                                  - name pro jméno studenta
 *    Přidej třídě Student čtyři funkce - AddSubject, která jako vstupní parametr přijme název předmětu a přidá nový klíč do subjects
 *                                      - AddGrade, která jako vstupní parametr přijme název předmětu a známku a přidá podle názvu předmětu další známku danému předmětu
 *                                      - CalculateSubjectGrade, která jako stupní parametr přijme název předmětu a spočítá průměrnou známku na vysvědčení z daného předmětu
 *                                      - CaculateTotalGrade, která spočítá studijní průměr (průměr všech známek)
 * Přidej třídě Student konstruktor, který bude přijímat dva parametry - jméno a ročník studenta
 *                                                                        - Při jeho zavolání nastav jméno a ročník podle vstupních parametrů, id vygeneruj podobně, jako accountNumber
 * ve tříde BankAccount, a subjects nastav na nový prázdný List
 *
 * 3) BONUS - Až vytvoříš Student, přidej možnost mít u známek váhy.Způsob nechám na tobě, možností je víc.Můžeš celou třídu překopat na známky pouze s váhou, a nebo můžeš zachovat
 *            možnost přidávat známky bez váhy s tím, že ty budou mít nějakou výchozí váhu automaticky, a přidáš varianty funkcí na přidávání známek s váhou
 *
 * V mainu využívej tebou naprogramované třídy a funkce, vypisuj výsledky do konzole, hraj si s tím a sleduj, co se kdy děje a co kdy jaká třída dělá.
 * Když si s něčím nebudeš vědět rady, zvedni ruku nebo na mě zavolej, já přijdu a poradím :)
 * Uděláš, co stihneš.Budeme na tom pracovat i nadále, takže se nestresuj časem a v klidu si všechno postupně rozmýšlej a piš takovým tempem, jaké je ti příjemné.
 */
    internal class Student
    {

    }
}

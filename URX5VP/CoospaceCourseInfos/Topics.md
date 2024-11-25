# Topics

1. A .NET keretrendszer

Felépítés: CLR, BCL, CIL
Fejlesztő eszközök: Visual Studio, VS Code, Rider
Alternatív implementációk: Mono, Nano Framework, Unity
kompatibilitás a platformok között: .NET Standard
Az IL Kód és visszafejtésének lehetőségei

2. Generikus programozás, kollekciók

Variancia és kontravariancia
Tömb, Több dimenziós tömb
List<T>, Stack<T>, Que<T>, IEnumerable<T>
Span<T>, Memory<T>

3. Referencia és érték típusok, Immutable osztályok és problémáik

Mi az Immutable típus?
Immutable típusok előnyei és hátrányai, kapcsoódó tervezési minták: Builder és Factory
Property vs Field és lehetőségeik
IEquitable<T> vs IComparable<T> vs IEqualityComparer<T> intefészek: Mikor melyiket
Recod type és a with, mint nyelvbe integrált Builder

4. Szerializációs lehetőségek

Bináris vagy miért ne?
XML
JSON: Newtonsoft vs .NET Core JSON
YAML

5. Natív kód vs Managed interakció

Natív kód hívása
Dispose és IDisposable interfész
Miért és mikor kell Dispose?
GC belső lelki világa, objektumok generációi: Gen0, Gen1 és Gen2

6. Extension methods, Lambda kifejezések, LINQ

A bővíthetetlen bővítése: Extension metódusok
A LINQ mint egy Builder
A LINQ belső lelki világa: Expression trees
Query és Lamba szintaxis: Mikor melyiket

7. Attribútumok és reflection

Kód annotálása
Dinamikus assembly betöltés és típus példányosítás
Moduláris alkalmazáskészítés alapjai
Mire jó? Gyakorlati példa: Nunit, Asp.NET attribútum mappelése

8. Párhuzamos programozás

Thead létrehozása, menedzselése
ThreadPool
Task<T> és ValueTask<T>
Aszinkron programozás (async, await)

9. Párhuzamos programozás II.

Atomi műveletek és az Interlocked osztály,
Szálak és objektumok életciklusának mendedzselése, Singleton problémák
Párhuzamos LINQ
Párhuzamos kollekciók és zárolások

10. Moduláris alkalmazáskészítés a gyakorlatban:

Dependency Injection ketrendszerek: SimpeIOC és Microsoft.Extensions.DependencyInjection
Managed Extensibility framework (MEF)
Dinamikus futtatókörnyezet (DLR) és nyelvei

11. Kód tesztelése C# esetén

Tesztelés szintjei, teszt piramis
Unit teszt keretrendszerek: Nunit, XUnit, MsTest
Unit tesztek létrehozása Nunit segítségével
Mock és stub osztályok
Kód metrikák: Line coverage, branch coverage, ciklomatikus komplexitás, CRAP index

12. teljesítmény mérése és problémái

Egyszerű sebességmérési módszerek – DateTime diff és Performance counter
Mérés Benchmark.NET segítségével
Profiling Visual Studio segítségével és teljesítmény hotspotok keresése
Élet a spectre és meltdown után: apróságok, amik hatalmas hatással vannak a sebességre

13. Modern fejlesztési elvek és megvalósításuk C#-ban

                * S.O.L.I.D.

                * K.I.S.S

                * Y.A.G.N.I

                * Domain driven design

                * Test driven development

Git tutorial és alapismeretek: Quickstart - GitHub Docs
Ingyenes C# könyv: A Könyv | C# Tutorial.hu (csharptutorial.hu)
.NET blog: .NET Blog (microsoft.com)
S.O.L.I.D elvek illusztrálva: The S.O.L.I.D Principles in Pictures | by Ugonna Thelma | Backticks & Tildes | Medium
Design patternek: Refactoring and Design Patterns
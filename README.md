https://github.com/Fabbernat/LetterGenerator/
# Automatikus körlevél generáló alkalmazás sablon  és adatbázis alapján, biztonságos felhasználói adat kezeléssel.
Ez az issue egy olyan C# alkalmazás fejlesztésére vonatkozik, amely képes körlevelek generálására és biztonságos felhasználói adatkezelésre, megfelelve a modern fejlesztési irányelveknek.

### Főbb feladatok:
- **Adat szerializáció és deszerializáció** JSON/XML formátumban
- **LINQ műveletek alkalmazása** (szűrés, rendezés, csoportosítás stb.)
- **Generikus kollekciók használata** az adatok tárolására és feldolgozására
- **Kivételkezelés megvalósítása és hibaüzenetek kezelése** könnyen értelmezhető módon

Például az alábbi NAV adótartozás CSV adatbázisban tárolt adatokat egy sablon TeX, markdown, vagy másmilyen formázható sztringbe behelyettesítve egy személyre szóló e-mailt gyárthatunk.
Példa csv adatok:
```csv
nev,cim,osszeg,hatarido,kozlemeny
Tóth Béla,"1011 Budapest, Fő utca 10.",245 130,2024. október 31.,ADÓ123456
Kovács János,"1234 Budapest, Fő utca 1.",113 021,2024. november 05.,ADÓ243511
Szabó Anna,"5678 Debrecen, Kossuth tér 3.",278 974,2024. december 19.,ADÓ879866
Nagy Péter,"9012 Győr, Baross út 5.",229 005,2024. november 29.,TÖRL846592
Tóth Katalin,"3456 Szeged, Dóm tér 7.",181 092,2025. január 02.,ADÓ548053
Varga László,"6789 Pécs, Zsolnay út 9.",222 370,2024. november 21.,TART485595
Farkas Zoltán,"7890 Miskolc, Petőfi Sándor utca 11.",177 837,2024. december 14.,ADÓ665962
```
Példa LaTeX sablon:
```tex
\begin{document}

\pagestyle{fancy}
\fancyhf{}
\fancyhead[L]{Nemzeti Adó- és Vámhivatal}
\fancyhead[R]{\today}
\fancyfoot[C]{\thepage}

\begin{flushleft}
    \textbf{Tárgy:} Fizetési felszólítás - Adótartozás \\ [1em] 
    \textbf{Címzett:} \nev \\ [1em] 
    \textbf{Cím:} \cim
\end{flushleft}

\vspace{1.5em}

Tisztelt \nev!

Ezúton értesítjük Önt, hogy a NAV nyilvántartásában szereplő adatok alapján Önnek fizetési hátraléka van, amelynek összege \osszeg HUF. Kérjük, hogy a tartozást legkésőbb \hatarido dátumig rendezze.

Felhívjuk figyelmét, hogy amennyiben a megadott határidőig nem történik meg a fizetés, úgy jogi lépéseket teszünk a tartozás behajtása érdekében.

Az utaláshoz szükséges adatok:
\begin{itemize}
    \item Számlaszám: 12345678-00000000-00000000
    \item Közlemény: \kozlemeny
\end{itemize}

Amennyiben a tartozás rendezése megtörtént, kérdése merül fel, vagy részletfizetési kérelmet szeretne benyújtani, kérjük, vegye fel a kapcsolatot ügyfélszolgálatunkkal a következő telefonszámon: \\
+36 1 123 4567

Köszönettel,\\
Nemzeti Adó- és Vámhivatal Pénzügyi Osztály \\
\signature{Nemzeti Adó- és Vámhivatal Pénzügyi Osztály}
\date{\today}

\vspace{1.5em}
\textit{Kérjük, hogy az utalás során minden adatot pontosan adjon meg, különben nem tudjuk azonosítani a befizetést.}

\end{document}
```

FIGYELEM!!! A működő projektem a https://github.com/Fabbernat/egyetemikurzus-2024-osz repo `main` branch-ében található, de nem tudtam pull requestelni a konfliktusok miatt! Elnézést az okozott kellemetlenségekért!
https://github.com/CsharptutorialHungary/egyetemikurzus-2024-osz/issues/7#issue-2632545054
# Funkciók:
## Implementáltam az alábbi 5 funkciót (1-5. menüpont):
```
- "1. - Fizetési felszólítás": Ez a funkció lehetővé teszi a felhasználó számára, hogy fizetési felszólítást generáljon az adózóknak. A felszólítás tartalmazza az adózó adatait, a fizetendő összeget, a határidőt és a közleményt. Az adózó adatai a csv/database.csv fájlból töltődnek be.
- "2. - Tájékoztató az új szabályokról": Ez a funkció megjeleníti az új adószabályokról szóló tájékoztatót.
- "3. - Ellenőrzési értesítés": Ez a funkció lehetővé teszi a felhasználó számára, hogy ellenőrzési értesítést küldjön az adózóknak.
- "4. - Adóbevallási emlékeztető": Ez a funkció lehetővé teszi a felhasználó számára, hogy adóbevallási emlékeztetőt küldjön az adózóknak.
- "5. - Egyéni lekérdezés válasz, megadott id alapján": Ez a funkció lehetővé teszi a felhasználó számára, hogy egyéni lekérdezésekre válaszoljon. A felhasználó megadhatja az adózó azonosítóját, és a program megjeleníti az adózó adatait a csv/database.csv fájlból.
```
A QueryService a csv/database.csv fájlból tölti be az adózók adatait. A fájl formátuma a következő: nev,cim,osszeg,hatarido,kozlemeny. A QueryService ezeket az adatokat használja fel az egyéni lekérdezések megválaszolásához.

Az alkalmazás jó felhasználói élményt biztosít a menü megjelenítésével, tájékoztató szövegekkel és a felhasználói interakciókkal.
A program minden művelet után világos utasításokat ad a felhasználónak.
Egységteszteket adtam hozzá a Program.cs és az Address.cs osztályokhoz.
Integrációs teszteket adtam hozzá a ReminderService és ReminderView osztályokhoz.
Rendszerteszteket adtam hozzá az alkalmazás egészének teszteléséhez.

# Tesztelés:
```
dotnet test --logger "console;verbosity=normal"
```

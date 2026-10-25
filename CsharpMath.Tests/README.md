# Funktsioonide uurimise rakenduse ühiktestid

Vastastikuse testimise töö raames kirjutatud xUnit ühiktestid Nikita funktsioonide uurimise veebirakendusele.

- **Testija:** Oleksandra Ryshniak, TARpv24
- **Testitav töö:** [https://github.com/nikita-lit/csharp-math](https://github.com/nikita-lit/csharp-math)
- **Testitava repositooriumi commit:** fbae048

## Tehnoloogiad

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- xUnit
- Visual Studio

## Testide käivitamine

Repositooriumi juurkaustast:

```bash
dotnet test
```

Visual Studios: ava projekti lahendus → **Test** → **Test Explorer** → **Run All**.

## Testklassid

| Fail                       | Mida kontrollib                                                                                | Teste |
| -------------------------- | ---------------------------------------------------------------------------------------------- | ----- |
| `FunctionAnalyzerTests.cs` | Lineaar-, ruut-, kuup- ja konstantfunktsioonide tuletiste arvutamine ning nullkohtade leidmine | 30    |

Testprojektis on kokku 16 testimeetodit: 11 `[Fact]` ja 5 `[Theory]` meetodit. `[InlineData]` andmekomplektidega käivitatakse kokku 30 testjuhtumit.

## Kontrollväärtused

Oodatavad väärtused põhinevad matemaatilistel kontrollarvutustel.

| Funktsioon  | Tuletis | Nullkohad                   |
| ----------- | ------- | --------------------------- |
| x² − 4x + 3 | 2x − 4  | x = 1; x = 3                |
| x³          | 3x²     | x = 0                       |
| 3x + 2      | 3       | x = −2/3                    |
| x² + 1      | 2x      | Reaalsed nullkohad puuduvad |
| x²          | 2x      | x = 0 (kahekordne nullkoht) |
| 5           | 0       | Nullkohad puuduvad          |
| 2x − 6      | 2       | x = 3                       |
| x³ − 8      | 3x²     | x = 2                       |

Lisaks kontrolliti tuletiste väärtusi erinevates punktides ning negatiivse kordajaga funktsioone.

## Tulemus

**30 testist 30 läbivad, 0 kukub läbi.**

Kõik xUnit ühiktestid läbisid kontrolli edukalt. Tuletiste arvutamise ja nullkohtade leidmise tulemused vastasid oodatud matemaatilistele väärtustele.

Automaatse testimise käigus ei tuvastatud vigu.

## Märkus

Testid asuvad eraldi projektis `CsharpMath.Tests` ja kasutavad rakenduse matemaatiliste arvutuste teenust `FunctionAnalyzer`.

Ühiktestid võimaldavad kontrollida matemaatilisi arvutusi ilma veebibrauseri ja andmebaasita. Testimise eesmärk oli kontrollida olemasoleva rakenduse korrektsust, mitte muuta selle põhifunktsionaalsust.

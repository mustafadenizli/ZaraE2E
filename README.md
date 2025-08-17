# ZaraE2E

Bu proje, Zara web sitesinin E2E (End-to-End) otomasyon testlerini içerir. 
Testler Selenium WebDriver ve NUnit framework kullanılarak yazılmıştır.

## 🛠 Teknolojiler
- .NET 7
- C#
- Selenium WebDriver
- NUnit
- ExcelDataReader (Test verileri için)
- ChromeDriver

## 📂 Proje Yapısı
- `ZaraE2E.Core` → Sayfalar ve yardımcı sınıflar
- `ZaraE2E.Tests` → Test senaryoları
- `TestData` → Excel ve txt test verileri

## ⚙️ Kurulum
1. Repo’yu klonla:
   ```bash
   git clone https://github.com/<kullanıcı-adın>/ZaraE2E.git
2. Projeyi Visual Studio’da aç
3. NuGet paketlerini yükle:
   Selenium.WebDriver
   Selenium.Support
   NUnit
   ExcelDataReader
4. Visual Studio Test Explorer’dan ya da terminalden:
   "dotnet test" ile çalıştırılır.

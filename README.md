# KAPSALON X (eindevaluatie-1819-b03-max)

In deze repository wordt een applicatietool geïntegreerd voor het maken van een online afspraak bij een kapper. De klant kan zelf zijn afspraak inplannen en deze wordt vervolgens automatisch ingepland in de kalender van de kapper. Deze kalendar is raad te plegen op de administrator pagina, waar verdere aanpassingen kunnen uitgevoerd worden (zowel voor afspraken als accountsettings).

## Aan de slag
Dit ASP.NET Core project kan eenvoudigweg opgestart worden na het leggen van een databaseconnectie (terug te vinden in appsettings.json).

### Vereisten
Er wordt gebruik gemaakt van een database, wat noodzakelijk is voor de opstart van de webapplicatie. Deze database heeft de naam 'KapsalonX'.

### Inloggen als administrator
De admin pagina kan geraadpleegd worden door te surfen naar '/wiezoektdievindt'. De inloggegevens betreffen de volgende:
```
Gebruikersnaam: admin@kapsalonx.knip
Wachtwoord: Admin!
```
Na het correct inloggen, verschijnt de optie 'Dashboard' in de navigatiebalk. Dashboard geeft een overzicht van de ingeplande afspraken (lijst of kalender) en verschaft de mogelijkheid accountsettings bij te werken.

## Ontworpen met
* [ASP.NET CORE](https://www.asp.net/core/overview/aspnet-vnext) - framework

## Versie 
06/01/2019

## Auteurs
* **Axelle Hillewaere** - [GitHub](https://github.com/axellehillewaere)
* **Magali Cantaert** - [GitHub](https://github.com/magalicantaert)


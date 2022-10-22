# test jürgen
# Hauptfarbe 
orange: #F1903C

# push an existing repository from the command line
git remote add origin https://github.com/PITapp/SinDarEla_WebApp.git
git branch -M main
git push -u origin main

# Projekt aus GIT klonen
git clone https://github.com/PITapp/SinDarEla-Blazor-Verwaltung

# Berichte erzeugen:
https://forum.radzen.com/t/creating-reports/5844
https://github.com/FastReports/FastReport
https://www.stimulsoft.com/de

# Löschen node_modules und neu installieren
> cd cliend 
> rm -r node_modules
> npm install

# Interesante Links
> Theme: https://www.primefaces.org/verona-ng/#/
> Theme: https://www.primefaces.org/olympia/

# Folgende Tabellen werden für "Security" automatisch erstellt
> Bei einer Übernahme des Projektes aus Angular nach Blazor müssen diese Tabellen gelöscht und dann neu (automatisch beim Ausführen) erstellt werden 
__EFMigrationsHistory
AspNetRoleClaims
AspNetRoles
AspNetUserClaims
AspNetUserLogins
AspNetUserRoles
AspNetUsers
AspNetUserTokens
DeviceCodes
Keys
PersistedGrants

# Select a theme
default

# Code generation ignore list
client\wwwroot\index.html
client\wwwroot\assets\css\standard.css
client\wwwroot\assets\css\styles-generated.css

# Save your plants API

## Project
Dit is een API die ik volledig zelf gemaakt heb.
De API dient gebruikt te worden in de toekomst voor een app die ik nu nog ben aan het ontwikkelen.
Het zal een app zijn die je remind om je plantjes water te geven (omdat ik dat altijd vergeet te doen).

Hierbij geef ik jullie mijn API die ik gemaakt heb in .net.


## Extra info
# Hoe kun je het gebruiken en testen?
Ik heb voor jullie seeding data toegevoegd en swagger (een tool om de api te testen) toegevoegd.

Eerst dien je migrations uit te voeren zodat je de data lokaal hebt op je computer.
Dit kan uiteraard op meerdere manieren maar hier heb je een voorbeeld:

1. open de "src" folder
1. shift rechter-muisklik en kies powershell.
1. typ de volgende commandline: 
"dotnet ef database update -s .\Imi.Project.Api\ -p .\Imi.Project.Api.Infrastructure\"

Eens je dit gedaan hebt zult de data lokaal opgeslaan worden.

## Hoe de API gebruiken?
De API opstarten.
1. open het project in visual studio
1. rechter-muisklik "Imi.Project.Api"
1. Set as startup project.

Nu kun je het project debuggen en opstarten.
Het zou er zo moeten uitzien:
![afbeelding](https://github.com/TonyPNT/Save-your-plants-API/assets/71766376/11983801-3e82-4f5e-b958-c5565c87e8ec)

Voor bepaalde calls te kunnen maken moet je rechten hebben in mijn API. (Ik heb identity toegevoegd)
Om rechten te krijgen moet je uiteraard inloggen.
Ik heb voor jullie een admin account gemaakt, ga naar de API call voor de login.
En gebruik deze gegevens:
username: "imiadmin"
password: "Test123?"
![afbeelding](https://github.com/TonyPNT/Save-your-plants-API/assets/71766376/b5aece61-3475-435f-8dca-a8c47f416d20)
Eens je dit hebt uitgevoerd krijg je een token terug als response.
![afbeelding](https://github.com/TonyPNT/Save-your-plants-API/assets/71766376/e3630749-6667-4e40-9a89-17d7f4d639b4)
Nu kun je de ontvangen token copy pasten in de Authorize box rechts bovenaan de pagina.
Eens je dat gedaan hebt kun je alle calls gebruiken als admin.

##Notes
Als je zelf een gebruiker wilt registeren en aanmaken dan moet het wachtwoord opzenminst een grote letter hebben, 1 speciale teken, en 1 cijfer.
Een gewone gebruiker kan uiteraard minder dan een admin.

Dit is zo gemaakt geweest voor veiligheidsredenen :)

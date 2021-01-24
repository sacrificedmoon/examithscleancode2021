# Sofia Lindgren
- Vad du valt att testa och varför?
Jag valde att testa en metod utan sidoeffekter, därför blev det metoden för att hämta individuella filmer. Sidoeffekter innebär att man modifierar datan på något sätt. Med en metod utan sidoeffekter får man samma resultat varje gång beroende på indata och är därför mer tillförlitlig att testa eftersom man kan anta resultatet. De flesta av mina metoder i programmet har sidoeffekter (de sorterar listor i annan ordning, gör om objekt och exkluderar objekt från listan) och datan som skickas ut kan variera beroende på i vilken ordning man anropar dem. Med GetMovieById-metoden skickar man in ett id och får ett filmobjekt tillbaka, filmobjektet varierar bara utifrån vilket id som passas in. http://www.cse.chalmers.se/edu/year/2010/course/TDA550/Lectures/F6.pdf

- Vilket/vilka designmönster har du valt, varför? Hade det gått att göra på ett annat sätt?
Jag använde mig av ett Adapter-pattern. Detta då objekten i de två olika listorna var för olika för att tillhöra samma klass och för att sätta ihop dem och sortera på ett attribut behövde den ena klassen "översättas" till den andra klassen och matcha upp attributen till samma typ. https://www.c-sharpcorner.com/UploadFile/efa3cf/adapter-design-pattern-in-C-Sharp/

- Hur mycket valde du att optimera koden, varför är det en rimlig nivå för vårt program?
Jag försökte förhålla mig till Singe Responsibility principen och delade upp metoderna i lämpliga klasser. En för att hämta listorna med filmer, en för att översätta den ena klassen till en annan och en sista för att sortera på listorna. Utöver det försökte jag dela upp metoderna i så små beståndsdelar som möjligt för att se till att de bara gjorde en grej (hade en nivå av abstraktion). Enligt Clean Code s.35 och s.138.

# Tentamen i Clean code och testbar kod

- Datum: 2021-01-21
- Program: C#-utvecklare
- Lärare: David Sundelius

## Introduktion
Vi har ett system som idag läser en lista på filmer från en json-fil på internet (https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json). Den innehåller titel, id och IMDB-ranking på filerna. Tjänsten som vi utvecklar har två stycken endpoints:
En som returnerar en lista på alla filmers titlar, ordnad efter ranking (stigande eller fallande)
En som returnerar all information vi har om en specifik film utifrån dess id.

## Uppgift
Din uppgift är nu att refaktorera programmet enligt de principer vi gått igenom i kursen. När uppgiften är färdig så ska programmet uppfylla följande egenskaper:
Koden är läsbar och tydlig i enlighet med Clean code-principer.
- Logiken i programmet, såsom sorteringen, är enhetstestad.
- Programmet ska innehålla en rimlig nivå av felhantering, användaren ska få rimliga meddelanden om något är fel.
- Programmet ska innehålla ett motiverat designmönster.
- Koden ska inte innehålla buggen (något som avviker från beskrivningen ovan) som finns i programmet från början.

Utöver detta ska du bygga ut programmet med en ny funktion. Detta är att läsa in data från ytterligare en endpoint (https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json). Denna data ska slås ihop med datan vi redan har och kunna presenteras på samma sätt. Det ska inte förekomma dubbletter av filmer i listan och den ska gå att sortera på samma villkor.

## Hjälpmedel
Alla hjälpmedel är tillåtna: internet, böcker, egenskrivet material och tidigare labbar/annan kod är godkänt exempelvis. Det enda ni inte får göra är att kommunicera med en annan människa under tentans gång, det inkluderar bland annat fysiska personer, telefon och chat.

## Redovisning
Källkoden ska vara pushad till ett eget publikt repository på GitHub. Ert fullständiga namn, samt en *kort* reflektion över dina arkitekturella val, såsom:

- Vad du valt att testa och varför?
- Vilket/vilka designmönster har du valt, varför? Hade det gått att göra på ett annat sätt?
- Hur mycket valde du att optimera koden, varför är det en rimlig nivå för vårt program?

ska finnas med i README.md i repots main-branch (master).

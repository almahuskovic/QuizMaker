# QuizMaker

Projekt je kreiran u Visual Studio 2022, korišten je .NET 6. Za mapiranje entiteta korišten je Automapper. Za komunikaciju s bazom korišten je Code first pristup.
Entiteti u bazi se kreiraju putem migracija. Za implementaciju exportera korišten je MEF (Managed Extensibility Framework).

Za lakše snalaženje sa API-jem uključen je Swagger, a u nastavku ću obrazložiti dodatno.  

*Dohvat svih dosad stvorenih kvizova*  

    GET metoda /quiz

*Stvaranje novog kviza*  

   
      POST metoda /quiz, koja prihvata naziv kviza i pitanja koja ce biti u tom kvizu, i sve dalje se odvija u POST metodama /quizquestion i /quizzesquestions.

*Uređivanje kviza*  

    PUT metoda /quiz. Šalje se slično kao i kod inserta. S tim da prilikom recikliranja pitanja potrebno je setovati property IsRecycled(bool) na true.
    Lista pitanja koja se mogu reciklirati se učitavaju preko GET metode /quizquestion.

*Brisanje kviza*  

    DELETE metoda /quiz. Dalje se iz nje poziva DELETE metoda za brisanje zapisa iz /quizzesquestions.

*Export kviza*  

    GET metoda /quizzesquestions/export/{id}/{extension}, kojoj se prosljeđuje id kviza i ekstenzija. Poziv metode /quizzesquestions/exportformats će trenutno vratiti samo CVS format.

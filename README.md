# Fiscal Code Finder
A simple C# class to find a fiscal code 


## Istruzioni:
Inizializzando il codice, viene richiesto dal costruttore il percorso del CSV con i codici catastali delle città, strutturati in CSV in questo modo:
```
Codice;Città
```
Ad esempio:
```
Bologna;A944
Rimini;H294
```


Inizializzando la classe invece indicheremo il percorso del file:
```C#
CF code = new CF("Catastali.csv");
```

Una volta dichiarata la classe, i metodi utilizzabili saranno i seguenti (e per elencarli userò un'identità di fantasia :):
### GetName
Ritorna una stringa con all'interno il nome in CF in maiuscolo:
`GetName("Paolo");` avrà come stringa di output `"PLA"`

### GetSurname
Ritorna una stringa con all'interno il cognome in CF in maiuscolo:
`GetSurname("Alemanno");` avrà come stringa di output `"LMN"`

### GetDate
Ritorna una stringa con all'interno la data in CF
`GetDate(1981/05/23);` avrà come stringa di output `"81E23"`</br>
**N.B.** Purtroppo non essendo stato previsto l'utilizzo pubblico del metodo, avendo creato il programma per altri scopi, finora non c'è un modo per scegliere il sesso senza comporre il CF completo. Quindi qualunque data uscirà sarà sempre di sesso maschile...

### GetCity
Ritorna una stringa con all'interno la città
`GetCity("Bologna");` avrà come stringa di output `"A944"`</br>
**N.B.** Per ottenere il risultato il programma si basa sul file CSV inizializzato con il costruttore, quindi non è il top del top (paesi recenti o stati esteri possono non essere riconosciuti). Non essendoci una vera e propria gestione degli errori in caso di città non trovata verrà restituito in output "0000"

### GetCIN
Ritorna il carattere di controllo dati i caratteri precedenti:
`GetCIN("LMNPLA81E23A944");` avrà come stringa di output `"X"`

### GetCF
Il più divertente e funzionale, ovviamente
```C#
GetCF("Alemanno", "Paolo", "M", 1981/05/23, "Bologna");
```
restituirà
```
"LMNPLA81E23A944X"
```

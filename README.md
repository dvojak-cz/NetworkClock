# NetworkClock
NetworkClock je servrová aplikace pro sdílení času po síti. Serverová část má možnost zobrazit systémový čas ve vybraném formátu a změnit systémový čas.

Aplikace reaguje na `GET` `HTTP` request, kde poskytuje serverový systémový čas. Request může obsahovat volitelným parametrem `format`, kde může klient nastavit požadovaný formát odpovědi.
Specifikaci dotazu neleznete v `Server/Documentation/Endpoints/GetTimeReqest.yaml`

Aby aplikace spávně běžela, pak na systému nesmí běžet žádný deamon, který synchornizuje čas. 
## Instalace a používání (docker)
Všechy ukázané příkazy jsou prováděny "root" složce řešení - tam, kde se nachází tento soubor.
```
# docker build -t network_clock .
# docker run -it --rm --privileged -- network_clock
```
## Instalace a používání (lokálně)
Všechy ukázané příkazy jsou prováděny "root" složce řešení - tam, kde se nachází tento soubor.
### Potřebné prerekvizity
- DLL: `WhiteListCaps.so`
  - Toto DLL musí být při spuštění aplikace nalezitelné operačnímsystémem (například v `/etc/lib`)
  ```
  $ make -C TimeChanger/src/ WhiteListCaps.so
  # cp TimeChanger/src/WhiteListCaps.so /usr/lib/
  # chmod 755 /usr/lib/WhiteListCaps.so
  ```
- Konfigurační soubor: `/etc/NetworkClock.json`
  ```
  # cp Server/config.json /etc/NetworkClock.json
  # chmod 644 /etc/NetworkClock.json
  ```
  V konfiguračním souboru musí být specifikovaná cesta na aplikaci _ChangeTime_
- Spustitelná aplikace: `ChangeTime`
  ```
  $ make -C TimeChanger/src/ ChangeTime
  # chmod +x TimeChanger/src/SetSUID.sh
  # TimeChanger/src/SetSUID.sh #Nastavý potřebná práva
  ```

### Vytvoření a spuštění aplikace
```
dotnet run --configuration Release --project Server/
```
---
## Klient
Server reahuje na `GET HTTP` požadavky. Příjmá parametr format, který určuje požadovaný formát odpovědi. Jako klient lze využí nástroj `curl`

Příklady požadavků:
```
$ curl 'http://localhost:<port>'
$ curl 'http://localhost:<port>?format=<format>' 
```

## Upozornění
Před kompilací a spuštěním aplikace si zkontrolujte, že máte správně nastavenou volací konveci DLLka, které bude aplikace importovat. Nastavení volací konvence je v `Server/Program.cs` - `line 9`
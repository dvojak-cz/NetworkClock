# NetworkClock
Všechy ukázané příkazy jsou prováděny "root" složce řešení - tam, kde se nachází tento soubor

Aby aplikace spávně běžela, pak na systému nesmí běžet žádný deamon, který synchornizuje čas. 
## Instalace a používání (docker)
```
# docker build -t network_clock .
# docker run -it --rm --privileged -- network_clock
```


## Instalace a používání (lokálně)
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

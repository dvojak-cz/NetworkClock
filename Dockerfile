FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        gcc-multilib \
        libcap-dev \
        make \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*
    
RUN mkdir /app

COPY . /app

WORKDIR /app

RUN make -C TimeChanger/src/ WhiteListCaps.so \
    && cp TimeChanger/src/WhiteListCaps.so /usr/lib/ \
    && chmod 755 /usr/lib/WhiteListCaps.so
    
RUN cp Server/config.json /etc/NetworkClock.json \
    && sed -ie 's/^\s*"ChangeTimeBin"\s*:\s*"[^"]*"\s*$/    "ChangeTimeBin": "\/app\/TimeChanger\/src\/ChangeTime"/' /etc/NetworkClock.json \
    && chmod 644 /etc/NetworkClock.json
    
RUN make -C TimeChanger/src/ ChangeTime \
    && chmod +x TimeChanger/src/SetSUID.sh \
    && ./TimeChanger/src/SetSUID.sh #Nastavý potřebná práva
 
RUN dotnet build --configuration Release Server/

CMD ["dotnet", "run", "--configuration", "Release", "--project", "Server/"]

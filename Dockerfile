# Based off Debian 10 / buster
FROM mcr.microsoft.com/dotnet/sdk:3.1
COPY ./ /app
WORKDIR /app
# see https://stackoverflow.com/questions/59657499/unable-to-bind-to-http-localhost5000-on-the-ipv6-loopback-interface-cannot
# ENV ASPNETCORE_URLS=http://127.0.0.1:5002
EXPOSE 5002
RUN dotnet restore

CMD ["dotnet", "watch", "run"]
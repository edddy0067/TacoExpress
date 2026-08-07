FROM alpine:3.20

WORKDIR /app

LABEL application="TacoExpress"
LABEL environment="staging"
LABEL framework=".NET MAUI 9"

COPY TacoExpress/ ./TacoExpress/

CMD ["sh", "-c", "echo 'TacoExpress - imagen de staging iniciada correctamente' && echo 'Proyecto disponible en /app/TacoExpress'"]
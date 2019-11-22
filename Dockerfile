FROM nagendragillalu/angularfront:initial AS frontend
RUN mkdir app
WORKDIR /app
EXPOSE 80/tcp
EXPOSE 4200/tcp
EXPOSE 8080/tcp
COPY ./EmployeeDirectory/. /app/

ENTRYPOINT ng serve --host 0.0.0.0 --port 4200 --aot --proxy-config proxy.conf.json
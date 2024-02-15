FROM nginx:alpine AS base
EXPOSE 80
EXPOSE 443

FROM base AS final
# RUN rm /etc/nginx/conf.d/default.conf
COPY ["nginx.conf", "/etc/nginx/"]

WORKDIR /usr/share/nginx/html
RUN rm -rf *
COPY ["dist", "."]
COPY ["entrypoint.sh", "."]

RUN chmod +x entrypoint.sh
ENTRYPOINT ["./entrypoint.sh"]
CMD ["nginx", "-g", "daemon off;"]
